using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Plugin_SongPoster
{
    ///<summary>
    ///This is our GUI class, called when the Config window is opened
    ///</summary>
    public partial class SongPoster_Config : Form
    {
        ///<summary>
        ///reference to the Main class
        ///</summary>
        private SongPoster spRef;

        ///<summary>
        ///ErrorProvider for E-Mail Field
        ///</summary>
        private ErrorProvider eMailErrorProvider;

        ///<summary>
        ///ErrorProvider for Password Field
        ///</summary>
        private ErrorProvider passwordErrorProvider;

        ///<summary>
        ///constructor, initialize some form elements with values from the Config storage
        ///</summary>
        public SongPoster_Config(SongPoster sp)
        {
            //Initialize the Window and it's components
            InitializeComponent();
            spRef = sp;

            listBoxNetworks1.ClearSelected();
            //select each network in the listBox which has a corresponding entry in the Networks array
            foreach (string network in spRef.Networks)
            {
                int index = listBoxNetworks1.FindStringExact(network);
                if (index >= 0)
                {
                    listBoxNetworks1.SetSelected(index, true);
                }
            }

            //set textbox values and check the Enable Box if the Plugin should run
            textBoxUserId.Text = spRef.UserId.ToString();
            textBoxEmail.Text = spRef.Email;
            textBoxPassword.Text = spRef.Password;
            textBoxResult.Text = spRef.Message;

            //If timing is WaitForPlayCount, check the corresponding Radio Button
            if (spRef.Timing == "WaitForPlayCount")
            {
                radioButtonWaitForPlayCount.Checked = true;
            }
            //else check the one for WaitForTime
            else
            {
                radioButtonWaitForTime.Checked = true;
            }

            //set the NumericUpDown Field to the Interval value from config
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

            checkBoxSendCoverArt.Checked = spRef.SendCoverArt;

            if (spRef.SendCoverArtPictureLocation == "picturesOnline")
            {
                radioButtonPictureLocationOnline.Checked = true;
            }
            else if (spRef.SendCoverArtPictureLocation == "picturesTag")
            {
                radioButtonPictureLocationTag.Checked = true;
            }

            eMailErrorProvider = new ErrorProvider();
            eMailErrorProvider.SetIconAlignment(textBoxEmail, ErrorIconAlignment.MiddleRight);
            eMailErrorProvider.SetIconPadding(textBoxEmail, -20);
            eMailErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            passwordErrorProvider = new ErrorProvider();
            passwordErrorProvider.SetIconAlignment(textBoxPassword, ErrorIconAlignment.MiddleRight);
            passwordErrorProvider.SetIconPadding(textBoxPassword, -20);
            passwordErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        ///<summary>
        ///Handler for the Browse button on the PAL tab
        ///</summary>
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            //Only handle something if the user successfully picked something, we don't need any handling for the cancel button
            if (openFileDialogPAL.ShowDialog() != DialogResult.OK) return;
            //initialize a few local variables
            string message = null;
            string prefix = null;
            string postfix = null;
            string interval = null;
            string timing = null;
            string scopeid = null;
            string userid = null;
            string password = null;
            string types = null;

            //get the selected filename and read the file into a string variable
            string palFileName = openFileDialogPAL.FileName;
            string palText = System.IO.File.ReadAllText(palFileName);
            string[] palLines = palText.Split(new[] { '\r', '\n' });
            //set the PAL preview box content
            textBoxPAL.Lines = palLines;

            //Regex for parsing the settings from the PAL file
            Regex r1 = new Regex(@"statusmessage := Song\['(\w+)'\] \+ ' - ' \+ Song\['(\w+)'\];$", RegexOptions.IgnoreCase);
            Regex r2 = new Regex(@"prefix : String = '(.*)';");
            Regex r3 = new Regex(@"prefix : String = '(.*)';");
            Regex r4 = new Regex(@"Pos\(Song\['songtype'\],'([A-Z]+)'\)");
            //Timing format is either PAL.WaitForPlayCount(123); or PAL.WaitForTime('+12:34:56');
            Regex r5 = new Regex(@"PAL.WaitFor(Time|PlayCount)\((?:(\d+)|'\+(\d{2}:\d{2}:\d{2})')\);");
            //URL line 2 may leave out the picture part at the end
            Regex r6 = new Regex(@"\+ '(?:twitter|facebook|google|instagram)' \+ '/' \+ '(\d+)' \+ '/' \+ '(\d+)' \+ '/' \+ '(.+?)' \+ '/' \+ status(?: \+ '/' \+ picture)?;");

            //count if we found all the settings
            int found = 0;

            foreach (string element in palLines)
            {
                //Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(message))
                {
                    Match m1 = r1.Match(element);
                    if (m1.Success)
                    {
                        //grab the matches and enclose them with $ to build RadioDJ template variables
                        message = "$" + m1.Groups[1].Value + "$ - $" + m1.Groups[2].Value + "$";
                        found++;
                    }
                }

                //Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(prefix))
                {
                    Match m2 = r2.Match(element);
                    if (m2.Success)
                    {
                        prefix = m2.Groups[1].Value;
                        found++;
                    }
                }

                //Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(postfix))
                {
                    Match m3 = r3.Match(element);
                    if (m3.Success)
                    {
                        postfix = m3.Groups[1].Value;
                        found++;
                    }
                }

                //Only try to match if we haven't found this element yet
                if (string.IsNullOrEmpty(types))
                {
                    Match m4 = r4.Match(element);
                    if (m4.Success && m4.Groups.Count == 2)
                    {
                        types = m4.Groups[1].Value;
                    }
                }

                //Only try to match if we haven't found this element yet
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

                //Only try to match if we haven't found this element yet
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

                //each match increases the found counter, once we found all 4 setting groups, there's no need to parse the rest of the PAL file anymore
                if (found >= 5)
                {
                    break;
                }
            }

            //set the result textbox to include prefix, message and postfix - just like in SAMBC the 3 are concatenated without any extra whitespace
            textBoxResult.Text = prefix + message + postfix;

            //PlayCount Timing can be applied directly by parsing the interval string into a number
            if (timing == "PlayCount")
            {
                radioButtonWaitForPlayCount.Checked = true;
                numericUpDownInterval.Value = int.Parse(interval);
            }
            //"Time" Timing is a bit more complex
            else
            {
                radioButtonWaitForTime.Checked = true;
                //split the interval on the : symbol
                string[] intervalParts = interval.Split(new char[] { ':' });
                //then parse each part into a number, convert each part into minutes and add them up
                numericUpDownInterval.Value = int.Parse(intervalParts[0]) * 60 + int.Parse(intervalParts[1]) + int.Parse(intervalParts[2]) / 60;
            }

            listBoxTrackTypes.ClearSelected();
            int index = -1;
            foreach (char samType in types)
            {
                index = -1;

                switch (samType)
                {
                    //S - Normal song
                    case 'S':
                        index = listBoxTrackTypes.FindStringExact("Music");
                        break;

                    //I - Station ID
                    case 'I':
                        index = listBoxTrackTypes.FindStringExact("Sweeper");
                        break;

                    //P - Promo
                    case 'P':
                        break;

                    //J - Jingle
                    case 'J':
                        index = listBoxTrackTypes.FindStringExact("Jingle");
                        break;

                    //A - Advertisement
                    case 'A':
                        index = listBoxTrackTypes.FindStringExact("Commercial");
                        break;

                    //N - Syndicated news
                    case 'N':
                        index = listBoxTrackTypes.FindStringExact("News");
                        break;

                    //X - Sound FX
                    case 'X':
                        break;

                    //C - Unknown content
                    case 'C':
                        index = listBoxTrackTypes.FindStringExact("Other");
                        break;

                    //? - Unknown
                    case '?':
                        index = listBoxTrackTypes.FindStringExact("Other");
                        break;
                }

                if (index >= 0)
                {
                    listBoxTrackTypes.SetSelected(index, true);
                }
            }

            //set the userId and password fields
            textBoxUserId.Text = userid;
            textBoxPassword.Text = password;
            //@ToDo add scopeId field and set that as well
            //textBoxScopeId = scopeid;

            //@ToDo add Email to PAL or standalone config file and validate credentials are still good
            buttonSave.Enabled = true;
        }

        ///<summary>
        ///Close the Window if user clicks cancel
        ///</summary>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        ///<summary>
        ///Save settings, then close the Window
        ///</summary>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            if (!ValidateCredentials(textBoxEmail.Text, textBoxPassword.Text))
            {
                return;
            }
                
            
            //Set message to the parsed result (with optional user modifications)
            spRef.Message = textBoxResult.Text;

            //We used "nicer" names for the Networks ListBox, but need the normalized name for sending to SongPoster
            spRef.Networks = new string[listBoxNetworks1.SelectedItems.Count];
            listBoxNetworks1.SelectedItems.CopyTo(spRef.Networks, 0);

            //Copy selected items from TrackTypes ListBox to spRef variable
            spRef.SelectedTrackTypes = new string[listBoxTrackTypes.SelectedItems.Count];
            listBoxTrackTypes.SelectedItems.CopyTo(spRef.SelectedTrackTypes, 0);

            //Grab "simple" data from textboxes, radio buttons and numericUpDown fields
            Int32.TryParse(textBoxUserId.Text, out spRef.UserId);
            spRef.Email = textBoxEmail.Text;
            spRef.Password = textBoxPassword.Text;
            spRef.Enabled = checkBoxEnable.Checked;
            spRef.SendCoverArt = checkBoxSendCoverArt.Checked;
            spRef.Timing = radioButtonWaitForPlayCount.Checked ? "WaitForPlayCount" : "WaitForTime";
            spRef.SendCoverArtPictureLocation = radioButtonPictureLocationOnline.Checked ? "picturesOnline" : "picturesTag";
            spRef.Interval = (int)numericUpDownInterval.Value;

            //normalize values into strings and save to XML via RadioDJ SaveSetting operation
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "networks", string.Join(";", spRef.Networks));
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "UserId", spRef.UserId.ToString());
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Email", spRef.Email);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Password", spRef.Password);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Enabled", spRef.Enabled ? "true" : "false");
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CustomData", spRef.Message);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Timing", spRef.Timing);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Interval", spRef.Interval.ToString());
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Types", string.Join(";", spRef.SelectedTrackTypes));
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CoverArtEnabled", spRef.SendCoverArt ? "true" : "false");
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CoverArtPictureLocation", spRef.SendCoverArtPictureLocation);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CoverArtFallbackFile", spRef.SendCoverArtFallbackFile);

            Cursor.Current = currentCursor;
        }

        ///<summary>
        ///setter for global checkBoxEnable Enabled state
        ///</summary>
        public void SetCheckBoxEnable(bool Enabled)
        {
            checkBoxEnable.Checked = Enabled;
        }


        ///<summary>
        ///setter for global checkBoxSendCoverArt Enabled state
        ///</summary>
        public void SetChekBoxSendCoverArt(bool sendCoverArt)
        {
            checkBoxSendCoverArt.Checked = sendCoverArt;
        }


        private void GroupBoxCredentials_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            buttonSave.Enabled = ValidateCredentials(textBoxEmail.Text, textBoxPassword.Text);
        }

        private bool ValidateCredentials(string email, string password)
        {
            WebClient client = new WebClient
            {
                Credentials = new NetworkCredential(email, password)
            };

            try
            {
                string reply = client.DownloadString("https://songposter.net/api/validate");
                eMailErrorProvider.SetError(textBoxEmail, "");
                passwordErrorProvider.SetError(textBoxPassword, "");
                textBoxUserId.Text = reply;

                return true;
            }
            catch (WebException)
            {
                eMailErrorProvider.SetError(textBoxEmail, "E-Mail or Password incorrect");
                passwordErrorProvider.SetError(textBoxPassword, "E-Mail or Password incorrect");
                buttonSave.Enabled = false;

                return false;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the configuration without saving? All unsaved progress will be lost!", "Close without saving?",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }

        private void ButtonBrowseCover_Click(object sender, EventArgs e)
        {
            //Only handle something if the user successfully picked something, we don't need any handling for the cancel button
            if (openFileDialogCover.ShowDialog() != DialogResult.OK) return;

            spRef.SendCoverArtFallbackFile = openFileDialogCover.FileName;
        }

        private void CheckBoxSendCoverArt_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendCoverArt = sender as CheckBox;

            groupBoxPictureLocation.Enabled = sendCoverArt.Checked;
            groupBoxDefaultImage.Enabled = sendCoverArt.Checked;

            spRef.SendCoverArt = sendCoverArt.Checked;
        }

        private void listBoxNetworks1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
