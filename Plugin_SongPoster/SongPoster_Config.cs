﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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

            // select each network in the listBox which has a corresponding entry in the Networks array
            foreach(string network in spRef.Networks)
            {
                listBoxNetworks1.SetSelected(listBoxNetworks1.FindString(network), true);
            }

            // set textbox values and check the Enable Box if the Plugin should run
            textBoxUserId.Text = spRef.UserId;
            textBoxPassword.Text = spRef.Password;
            textBoxResult.Text = spRef.Message;
            checkBoxUsePAL.Checked = spRef.Enabled;

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
        }

        // Handler for the Browse button on the PAL tab
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            // Only handle something if the user successfully picked something, we don't need any handling for the cancel button
            if (openFileDialogPAL.ShowDialog() == DialogResult.OK)
            {
                // initialize a few local variables
                string message = null;
                string prefix = null;
                string postfix = null;
                string interval = null;
                string timing = null;

                // get the selected filename and read the file into a string variable
                string palFileName = openFileDialogPAL.FileName;
                string palText = System.IO.File.ReadAllText(palFileName);
                // set the PAL preview box content
                textBoxPAL.Text = palText;

                // Regex for parsing the settings from the PAL file
                // statusmessage => currently only determine the order of artist and title
                // @ToDo generalize to add more possible fields using the custom box on the website
                Regex r1 = new Regex(@"statusmessage := Song\['(\w+)'\] \+ ' - ' \+ Song\['(\w+)'\];$", RegexOptions.IgnoreCase);
                Regex r2 = new Regex(@"prefix : String = '(.*)';");
                Regex r3 = new Regex(@"prefix : String = '(.*)';");
                // Timing format is either PAL.WaitForPlayCount(123); or PAL.WaitForTime('+12:34:56');
                Regex r4 = new Regex(@"PAL.WaitFor(Time|PlayCount)\((?:(\d+)|'\+(\d{2}:\d{2}:\d{2})')\);");

                // count if we found all the settings
                int found = 0;

                foreach (string element in palText.Split(new[] { '\r', '\n' }))
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
                    if (string.IsNullOrEmpty(interval) && string.IsNullOrEmpty(timing))
                    {
                        Match m4 = r4.Match(element);
                        if (m4.Success && m4.Groups.Count == 4)
                        {
                            timing = m4.Groups[1].Value;
                            interval = m4.Groups[3].Value;
                            found++;
                        }
                    }

                    // each match increases the found counter, once we found all 4 setting groups, there's no need to parse the rest of the PAL file anymore
                    if (found >=4)
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
             }
        }

        // Close the Window if user clicks cancel
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Handle checkChange of the 2 enable Checkboxes (1 on the hidden custom tab)
        // Enabling one box automatically disables the other box
        private void checkBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox1 = (CheckBox) sender;
            CheckBox checkbox2;
            if (checkbox1 == checkBoxEnable)
            {
                checkbox2 = checkBoxUsePAL;
            }
            else
            {
                checkbox2 = checkBoxEnable;
            }
            
            // Change Checked of self
            if (checkbox1.Checked)
            {
                checkbox1.Checked = false;
            }
            else
            {
                checkbox1.Checked = true;
                checkbox2.Checked = false;
            }
        }

        // Save settings, then close the Window
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Set message to either the parsed result (with optional user modifications) or the fully custom part from the (currently disabled) "custom" tab
            if (checkBoxUsePAL.Checked)
            {
                spRef.Message = textBoxResult.Text;
            }
            else if (checkBoxEnable.Checked)
            {
                spRef.Message = textBoxCustomData.Text;
            }

            // We used "nicer" names for the Networks ListBox, but need the normalized name for sending to SongPoster
            spRef.Networks = new string[listBoxNetworks1.SelectedItems.Count];
            listBoxNetworks1.SelectedItems.CopyTo(spRef.Networks, 0);
            for(int key = 0; key < spRef.Networks.Length; ++key)
            {
                switch (spRef.Networks[key])
                {
                    case "Facebook":
                        spRef.Networks[key] = "facebook";
                        break;

                    case "Google+":
                        spRef.Networks[key] = "google";
                        break;

                    case "Twitter":
                        spRef.Networks[key] = "twitter";
                        break;
                }
            }

            // Grab "simple" data from textboxes, radio buttons and numericUpDown fields
            spRef.UserId = textBoxUserId.Text;
            spRef.Password = textBoxPassword.Text;
            spRef.Enabled = checkBoxUsePAL.Checked | checkBoxEnable.Checked;
            spRef.Timing = radioButtonWaitForPlayCount.Checked ? "WaitForPlayCount" : "WaitForTime";
            spRef.Interval = (int) numericUpDownInterval.Value;

            // normalize values into strings and save to XML via RadioDJ SaveSetting operation
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "networks", string.Join(";", spRef.Networks));
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "UserId", spRef.UserId);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Password", spRef.Password);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Enabled", spRef.Enabled ? "true" : "false");
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CustomData", spRef.Message);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Timing", spRef.Timing);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Interval", spRef.Interval.ToString());

            Close();
        }

        // disable the custom tab
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }
    }
}
