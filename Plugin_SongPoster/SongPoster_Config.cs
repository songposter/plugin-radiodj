using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Plugin_SongPoster
{
    public partial class SongPoster_Config : Form
    {
        private SongPoster spRef;

        public SongPoster_Config(SongPoster sp)
        {
            InitializeComponent();
            spRef = sp;

            foreach(string network in spRef.Networks)
            {
                listBoxNetworks1.SetSelected(listBoxNetworks1.FindString(network), true);
            }

            textBoxUserId.Text = spRef.UserId;
            textBoxPassword.Text = spRef.Password;
            textBoxResult.Text = spRef.CustomData;
            checkBoxUsePAL.Checked = spRef.Enabled;
            if (spRef.Timing == "WaitForPlayCount")
            {
                radioButtonWaitForPlayCount.Checked = true;
            }
            else
            {
                radioButtonWaitForTime.Checked = true;
            }
            numericUpDownInterval.Value = spRef.Interval;
        }

        private void SongPoster_Config_Load(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogPAL.ShowDialog() == DialogResult.OK)
            {
                string palFileName = openFileDialogPAL.FileName;

                string message = null;
                string prefix = null;
                string postfix = null;
                string interval = null;
                string timing = null;

                string palText = System.IO.File.ReadAllText(palFileName);
                textBoxPAL.Text = palText;

                Regex r1 = new Regex(@"statusmessage := Song\['(\w+)'\] \+ ' - ' \+ Song\['(\w+)'\];$", RegexOptions.IgnoreCase);
                Regex r2 = new Regex(@"prefix : String = '(.*)';");
                Regex r3 = new Regex(@"prefix : String = '(.*)';");
                Regex r4 = new Regex(@"PAL.WaitFor(Time|PlayCount)\((?:(\d+)|'\+(\d{2}:\d{2}:\d{2})')\);");

                int found = 0;

                foreach (string element in palText.Split(new[] { '\r', '\n' }))
                {
                    if (string.IsNullOrEmpty(message))
                    {
                        Match m1 = r1.Match(element);
                        if (m1.Success)
                        {
                            message = "$" + m1.Groups[1].Value + "$ - $" + m1.Groups[2].Value + "$";
                            found++;
                        }
                    }

                    if (string.IsNullOrEmpty(prefix))
                    {
                        Match m2 = r2.Match(element);
                        if (m2.Success)
                        {
                            prefix = m2.Groups[1].Value;
                            found++;
                        }
                    }
                    
                    if (string.IsNullOrEmpty(postfix))
                    {
                        Match m3 = r3.Match(element);
                        if (m3.Success)
                        {
                            postfix = m3.Groups[1].Value;
                            found++;
                        }
                    }

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

                    if (found >=4)
                    {
                        found = 0;
                        break;
                    }
                }

                textBoxResult.Text = prefix + message + postfix;

                if (timing == "PlayCount")
                {
                    radioButtonWaitForPlayCount.Checked = true;
                    numericUpDownInterval.Value = int.Parse(interval);
                }
                else
                {
                    radioButtonWaitForTime.Checked = true;
                    string[] intervalParts = interval.Split(new char[] { ':' });
                    numericUpDownInterval.Value = int.Parse(intervalParts[0]) * 60 + int.Parse(intervalParts[1]) + int.Parse(intervalParts[2]) / 60;
                }
             }
        }

        // Close the Window if user clicks cancel
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Handle checkChange of the 2 enable Checkboxes
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (checkBoxUsePAL.Checked)
            {
                spRef.CustomData = textBoxResult.Text;
            }
            else if (checkBoxEnable.Checked)
            {
                spRef.CustomData = textBoxCustomData.Text;
            }

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

            spRef.UserId = textBoxUserId.Text;
            spRef.Password = textBoxPassword.Text;
            spRef.Enabled = checkBoxUsePAL.Checked | checkBoxEnable.Checked;
            spRef.Timing = radioButtonWaitForTime.Checked ? "WaitForTime" : "WaitForPlayCount";
            spRef.Interval = (int) numericUpDownInterval.Value;

            spRef.MyHost.SaveSetting(spRef.PluginFileName, "networks", string.Join(";", spRef.Networks));
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "UserId", spRef.UserId);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Password", spRef.Password);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Enabled", spRef.Enabled ? "true" : "false");
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CustomData", spRef.CustomData);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Timing", spRef.Timing);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Interval", spRef.Interval.ToString());

            Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }
    }
}
