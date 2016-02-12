using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Plugin_SongPoster
{
    public partial class SongPoster_Config : Form
    {
        private SongPoster spRef;

        private string message = null;
        private string prefix = null;
        private string postfix = null;

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
        }

        private void SongPoster_Config_Load(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogPAL.ShowDialog() == DialogResult.OK)
            {
                string palFileName = openFileDialogPAL.FileName;

                string palText = System.IO.File.ReadAllText(palFileName);
                textBoxPAL.Text = palText;

                Regex r1 = new Regex(@"statusmessage := Song\['(\w+)'\] \+ ' - ' \+ Song\['(\w+)'\];$", RegexOptions.IgnoreCase);
                Regex r2 = new Regex(@"prefix : String = '(.*)';");
                Regex r3 = new Regex(@"prefix : String = '(.*)';");

                foreach (string element in palText.Split(new[] { '\r', '\n' }))
                {
                    if (string.IsNullOrEmpty(message))
                    {
                        Match m1 = r1.Match(element);
                        if (m1.Success)
                        {
                            message = "$" + m1.Groups[1].Value + "$ - $" + m1.Groups[2].Value + "$";
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(prefix))
                    {
                        Match m2 = r1.Match(element);
                        if (m2.Success)
                        {
                            prefix = m2.Groups[1].Value;
                        }
                    }
                    
                    if (string.IsNullOrEmpty(postfix))
                    {
                        Match m3 = r1.Match(element);
                        if (m3.Success)
                        {
                            postfix = m3.Groups[1].Value;
                        }
                    }
                }

                textBoxResult.Text = prefix + message + postfix;
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

            spRef.MyHost.SaveSetting(spRef.PluginFileName, "networks", string.Join(";", spRef.Networks));
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "UserId", spRef.UserId);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Password", spRef.Password);
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "Enabled", spRef.Enabled ? "true" : "false");
            spRef.MyHost.SaveSetting(spRef.PluginFileName, "CustomData", spRef.CustomData);

            Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }
    }
}
