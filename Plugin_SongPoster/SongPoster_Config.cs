using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Plugin_SongPoster
{
    // This is our GUI class, called when the Config window is opened
    public partial class SongPoster_Config : Form
    {
        // reference to the Main class
        private SongPoster spRef;

        // constructor, initialize some form elements with values from the Config storage
        public SongPoster_Config(SongPoster sp)
        {
            // Initialize the Window and it's components
            InitializeComponent();
            spRef = sp;

            listBoxNetworks1.ClearSelected();
            // select each network in the listBox which has a corresponding entry in the Networks array
            foreach (string network in spRef.Networks)
            {
                int index = listBoxNetworks1.FindStringExact(network);
                if (index >= 0)
                {
                    listBoxNetworks1.SetSelected(index, true);
                }
            }

            // set textbox values and check the Enable Box if the Plugin should run
            textBoxUserId.Text = spRef.UserId;
            textBoxPassword.Text = spRef.Password;
            textBoxResult.Text = spRef.Message;

            // If timing is WaitForPlayCount, check the corresponding Radio Button
            if (spRef.Timing == "WaitForPlayCount")
            {
                radioButtonWaitForPlayCount.Checked = true;
            }
            // else check the one for WaitForTime
            else
            {
                radioButtonWaitForTime.Checked = true;
            }

            // set the NumericUpDown Field to the Interval value from config
            numericUpDownInterval.Value = spRef.Interval;

            listBoxTrackTypes.DataSource = spRef.trackTypes;
            listBoxTrackTypes.ClearSelected();

            foreach (string trackType in spRef.SelectedTrackTypes)
            {
                int index = listBoxTrackTypes.FindStringExact(trackType);
                if (index >= 0)
                {
                    listBoxTrackTypes.SetSelected(index, true);
                }
            }
        }

        // Handler for the Browse button on the PAL tab
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            // Only handle something if the user successfully picked something, we don't need any handling for the cancel button
            if (openFileDialogPAL.ShowDialog() != DialogResult.OK) return;
            // initialize a few local variables
            string message = null;
            string prefix = null;
            string postfix = null;
            string interval = null;
            string timing = null;
            string scopeid = null;
            string userid = null;
            string password = null;
            string types = null;

            // get the selected filename and read the file into a string variable
            string palFileName = openFileDialogPAL.FileName;
            string palText = System.IO.File.ReadAllText(palFileName);
            string[] palLines = palText.Split(new[] { '\r', '\n' });
            // set the PAL preview box content
            textBoxPAL.Lines = palLines;

            // Regex for parsing the settings from the PAL file
            Regex r1 = new Regex(@"statusmessage := Song\['(\w+)'\] \+ ' - ' \+ Song\['(\w+)'\];$", RegexOptions.IgnoreCase);
            Regex r2 = new Regex(@"prefix : String = '(.*)';");
            Regex r3 = new Regex(@"prefix : String = '(.*)';");
            Regex r4 = new Regex(@"Pos\(Song\['songtype'\],'([A-Z]+)'\)");
            // Timing format is either PAL.WaitForPlayCount(123); or PAL.WaitForTime('+12:34:56');
            Regex r5 = new Regex(@"PAL.WaitFor(Time|PlayCount)\((?:(\d+)|'\+(\d{2}:\d{2}:\d{2})')\);");
            // URL line 2 may leave out the picture part at the end
            Regex r6 = new Regex(@"\+ '(?:twitter|facebook|google)' \+ '/' \+ '(\d+)' \+ '/' \+ '(\d+)' \+ '/' \+ '(.+?)' \+ '/' \+ status(?: \+ '/' \+ picture)?;");

            // count if we found all the settings
            int found = 0;

            foreach (string element in palLines)
            {
                // Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(message))
                {
                    Match m1 = r1.Match(element);
                    if (m1.Success)
                    {
                        // grab the matches and enclose them with $ to build RadioDJ template variables
                        message = "$" + m1.Groups[1].Value + "$ - $" + m1.Groups[2].Value + "$";
                        found++;
                    }
                }

                // Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(prefix))
                {
                    Match m2 = r2.Match(element);
                    if (m2.Success)
                    {
                        prefix = m2.Groups[1].Value;
                        found++;
                    }
                }

                // Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(postfix))
                {
                    Match m3 = r3.Match(element);
                    if (m3.Success)
                    {
                        postfix = m3.Groups[1].Value;
                        found++;
                    }
                }

                // Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(types))
                {
                    Match m4 = r4.Match(element);
                    if (m4.Success && m4.Groups.Count == 2)
                    {
                        types = m4.Groups[1].Value;
                    }
                }

                // Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(interval) && string.IsNullOrEmpty(timing))
                {
                    Match m5 = r5.Match(element);
                    if (m5.Success && m5.Groups.Count == 4)
                    {
                        timing = m5.Groups[1].Value;
                        interval = string.IsNullOrEmpty(m5.Groups[3].Value) ? m5.Groups[2].Value : m5.Groups[3].Value;
                        found++;
                    }
                }

                // Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(scopeid) && string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(password))
                {
                    Match m6 = r6.Match(element);
                    if (m6.Success && m6.Groups.Count == 4)
                    {
                        scopeid = m6.Groups[1].Value;
                        userid = m6.Groups[2].Value;
                        password = m6.Groups[3].Value;
                        found++;
                    }
                }

                // each match increases the found counter, once we found all 4 setting groups, there's no need to parse the rest of the PAL file anymore
                if (found >= 5)
                {
                    break;
                }
            }

            // set the result textbox to include prefix, message and postfix - just like in SAMBC the 3 are concatenated without any extra whitespace
            textBoxResult.Text = prefix + message + postfix;

            // PlayCount Timing can be applied directly by parsing the interval string into a number
            if (timing == "PlayCount")
            {
                radioButtonWaitForPlayCount.Checked = true;
                numericUpDownInterval.Value = int.Parse(interval);
            }
            // "Time" Timing is a bit more complex
            else
            {
                radioButtonWaitForTime.Checked = true;
                // split the interval on the : symbol
                string[] intervalParts = interval.Split(new char[] { ':' });
                // then parse each part into a number, convert each part into minutes and add them up
                numericUpDownInterval.Value = int.Parse(intervalParts[0]) * 60 + int.Parse(intervalParts[1]) + int.Parse(intervalParts[2]) / 60;
            }

            listBoxTrackTypes.ClearSelected();
            int index = -1;
            foreach (char samType in types)
            {
                index = -1;

                switch (samType)
                {
                    // S - Normal song
                    case 'S':
                        index = listBoxTrackTypes.FindStringExact("Music");
                        break;

                    // I - Station ID
                    case 'I':
                        index = listBoxTrackTypes.FindStringExact("Sweeper");
                        break;

                    // P - Promo
                    case 'P':
                        break;

                    // J - Jingle
                    case 'J':
                        index = listBoxTrackTypes.FindStringExact("Jingle");
                        break;

                    // A - Advertisement
                    case 'A':
                        index = listBoxTrackTypes.FindStringExact("Commercial");
                        break;

                    // N - Syndicated news
                    case 'N':
                        index = listBoxTrackTypes.FindStringExact("News");
                        break;

                    // X - Sound FX
                    case 'X':
                        break;

                    // C - Unknown content
                    case 'C':
                        index = listBoxTrackTypes.FindStringExact("Other");
                        break;

                    // ? - Unknown
                    case '?':
                        index = listBoxTrackTypes.FindStringExact("Other");
                        break;
                }

                if (index >= 0)
                {
                    listBoxTrackTypes.SetSelected(index, true);
                }
            }

            // set the userId and password fields
            textBoxUserId.Text = userid;
            textBoxPassword.Text = password;
            // @ToDo add scopeId field and set that as well
            // textBoxScopeId = scopeid;
        }

        // Close the Window if user clicks cancel
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Save settings, then close the Window
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Set message to the parsed result (with optional user modifications)
            spRef.Message = textBoxResult.Text;

            // We used "nicer" names for the Networks ListBox, but need the normalized name for sending to SongPoster
            spRef.Networks = new string[listBoxNetworks1.SelectedItems.Count];
            listBoxNetworks1.SelectedItems.CopyTo(spRef.Networks, 0);

            // Copy selected items from TrackTypes ListBox to spRef variable
            spRef.SelectedTrackTypes = new string[listBoxTrackTypes.SelectedItems.Count];
            listBoxTrackTypes.SelectedItems.CopyTo(spRef.SelectedTrackTypes, 0);

            // Grab "simple" data from textboxes, radio buttons and numericUpDown fields
            spRef.UserId = textBoxUserId.Text;
            spRef.Password = textBoxPassword.Text;
            spRef.Enabled = checkBoxEnable.Checked;
            spRef.Timing = radioButtonWaitForPlayCount.Checked ? "WaitForPlayCount" : "WaitForTime";
            spRef.Interval = (int)numericUpDownInterval.Value;

            // normalize values into strings and save to XML via RadioDJ SaveSetting operation
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "networks", string.Join(";", spRef.Networks));
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "UserId", spRef.UserId);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Password", spRef.Password);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Enabled", spRef.Enabled ? "true" : "false");
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CustomData", spRef.Message);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Timing", spRef.Timing);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Interval", spRef.Interval.ToString());
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Types", string.Join(";", spRef.SelectedTrackTypes));

            Close();
        }

        public void setCheckBoxEnable(bool Enabled)
        {
            checkBoxEnable.Checked = Enabled;
        }
    }
}
