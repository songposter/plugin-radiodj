using rdjInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Plugin_SongPoster
{
    public class SongPoster : IPlugin
    {
        private List<Events.EventAction> MyEvents;

        public IHost MyHost;

        private WebRequester Requester;

        public string CustomData;

        public string[] Networks;

        public string UserId;

        public string Password;

        public bool Enabled = false;

        public string PluginFileName;

        public SongPoster()
        {
            MyEvents = new List<Events.EventAction>();
        }

        public bool HasActions
        {
            get
            {
                return true;
            }
        }

        public bool NotifyOnPlaylistChange
        {
            get
            {
                return false;
            }
        }

        public bool NotifyOnTrackChange
        {
            get
            {
                return true;
            }
        }

        public bool NotifyOnUIChange
        {
            get
            {
                return true;
            }
        }

        public string PluginDescription
        {
            get
            {
                return "Send NowPlaying Information to Facebook, Google+ and Twitter via the songposter.net Web Application";
            }
        }

        public string PluginName
        {
            get
            {
                return "SongPoster";
            }
        }

        public string PluginTitle
        {
            get
            {
                return "SongPoster";
            }
        }

        public string PluginVersion
        {
            get
            {
                return "0.0.2";
            }
        }

        public int PluginZone
        {
            get
            {
                return 2;
            }
        }

        public void AddTrack2Plugin(TrackPlayer trackData, long TriggerOn, int Position = -1)
        {
            //throw new NotImplementedException();
        }

        public void AddTrack2Plugin(int trackID, long TriggerOn, int Position = -1)
        {
            //throw new NotImplementedException();
        }

        public void AssistedStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        public void AutoDJStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        public List<Events.EventAction> AvailableActions()
        {
            Events.EventAction item = new Events.EventAction(PluginName, "Enable Auto Title", PluginActionTypes.WithoutArguments, "Enables the automatic title display.");
            MyEvents.Add(item);
            item = new Events.EventAction(PluginName, "Set Custom Title", PluginActionTypes.Other, "Add new title as argument. Don't use semicolon!");
            MyEvents.Add(item);
            return MyEvents;
        }

        public void Closing()
        {
            //throw new NotImplementedException();
        }

        private void LoadSettings()
        {
            string networks = MyHost.GetSetting(PluginFileName, "networks", "");
            Networks = networks.Split(new Char[] { ';' });
            UserId = MyHost.GetSetting(PluginFileName, "UserId", "");
            Password = MyHost.GetSetting(PluginFileName, "Password", "");
            Enabled = (MyHost.GetSetting(PluginFileName, "Enabled", "false") == "true");
            CustomData = MyHost.GetSetting(PluginFileName, "CustomData", "$artist$ - $title$");
        }

        public void Initialize(IHost Host)
        {
            MyHost = Host;
            PluginFileName = Assembly.GetExecutingAssembly().GetName().Name;
            LoadSettings();
            Requester = new WebRequester();
        }

        public void InputStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public UserControl LoadGUI()
        {
            return null;
        }

        public void PlaylistChanged()
        {
            //throw new NotImplementedException();
        }

        public void ReloadCategories()
        {
            //throw new NotImplementedException();
        }

        public void ReloadLanguage()
        {
            //throw new NotImplementedException();
        }

        public bool RunAction(string ActionName, string[] args)
        {
            if (ActionName == "Enable Auto Title")
            {
                MyHost.titleMain = null;
            }
            else if (ActionName == "Set Custom Title")
            {
                MyHost.titleMain = args[0].ToString();
            }

            return true;
        }

        public void ShowAbout()
        {
            MessageBox.Show("\u00a9" + DateTime.Now.Year.ToString() + " Xenzilla", PluginTitle);
        }

        public void ShowConfig()
        {
            SongPoster_Config configWindow = new SongPoster_Config(this);
            configWindow.Show();
        }

        public void ShowMain()
        {
            SongPoster_Config configWindow = new SongPoster_Config(this);
            configWindow.Show();
        }

        public void TrackChanged(TrackPlayer Player)
        {
            if (Enabled)
                Requester.sendRequest(Player.TrackData, CustomData, Networks, UserId, Password);
        }
    }
}
