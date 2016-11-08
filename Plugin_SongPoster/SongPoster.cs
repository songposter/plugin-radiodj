using rdjInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Plugin_SongPoster
{
    ///<summary>
    ///This is our main class and entrypoint for RadioDJ
    ///</summary>
    public class SongPoster : IPlugin
    {
        ///<summary>
        ///Declaration required for AvailableActions method from IPlugin interface, no idea what that does, though
        ///</summary>
        private List<Events.EventAction> MyEvents;

        ///<summary>
        ///Reference to the IHost interface by which we interact with the RadioDJ main program
        ///</summary>
        public IHost MyHost;

        ///<summary>
        ///This is the class where the actual web requests are sent
        ///</summary>
        private WebRequester Requester;

        ///<summary>
        ///Counter for PlayCount Timer.
        ///</summary>
        private int counter;

        ///<summary>
        ///Base time from which to count minutes for the "Time" timer
        ///</summary>
        private DateTime startTimer;

        ///<summary>
        ///Array of TrackType Strings from RadioDJ
        ///</summary>
        public string[] trackTypes;

        ///<summary>
        ///Array of TrackTypes selected by User
        ///</summary>
        public string[] SelectedTrackTypes;

        ///<summary>
        ///Interval (minutes/playcounts) after which a track is sent
        ///</summary>
        public int Interval;

        ///<summary>
        ///Defines the kind of timing for the Interval, either WaitForPlayCount or WaitForTime
        ///</summary>
        public string Timing;

        ///<summary>
        ///Message (Template) to send out
        ///</summary>
        public string Message;

        ///<summary>
        ///Array of networks to use and send the track info to
        ///</summary>
        public string[] Networks;

        ///<summary>
        ///SongPoster Userid
        ///</summary>
        public int UserId;

        ///<summary>
        ///SongPoster Userid
        ///</summary>
        public string Email;

        ///<summary>
        ///SongPoster Password
        ///</summary>
        public string Password;

        ///<summary>
        ///Plugin must be enabled by hand (after configuration)
        ///</summary>
        public bool Enabled = false;

        ///<summary>
        ///Reference by which Settings are stored and loaded
        ///</summary>
        public string PluginFileName;

        ///<summary>
        ///Constructor
        ///</summary>
        public SongPoster()
        {
            MyEvents = new List<Events.EventAction>();
        }

        ///<summary>
        ///required by IHost interface, no idea what it's good for
        ///</summary>
        public bool HasActions
        {
            get
            {
                return true;
            }
        }

        ///<summary>
        ///required by IHost interface, we're not interested in what you do with your Playlist
        ///</summary>
        public bool NotifyOnPlaylistChange
        {
            get
            {
                return false;
            }
        }

        ///<summary>
        ///required by IHost interface, let us know when the current track changes so we can send a message to SongPoster
        ///</summary>
        public bool NotifyOnTrackChange
        {
            get
            {
                return true;
            }
        }

        ///<summary>
        ///required by IHost interface, no idea what it's good for
        ///</summary>
        public bool NotifyOnUIChange
        {
            get
            {
                return true;
            }
        }

        ///<summary>
        ///required by IHost interface, Meta Data
        ///</summary>
        public string PluginDescription
        {
            get
            {
                return "SongPoster.net Webservice to Share Now Playing Info to social networks";
            }
        }

        ///<summary>
        ///required by IHost interface, Meta Data
        ///</summary>
        public string PluginName
        {
            get
            {
                return "SongPoster";
            }
        }

        ///<summary>
        ///required by IHost interface, Meta Data
        ///</summary>
        public string PluginTitle
        {
            get
            {
                return "SongPoster";
            }
        }

        ///<summary>
        ///required by IHost interface, Meta Data
        ///</summary>
        public string PluginVersion
        {
            get
            {
                return "0.6";
            }
        }

        ///<summary>
        ///required by IHost interface, no idea what it's good for or what Zones are available at all
        ///</summary>
        public int PluginZone
        {
            get
            {
                return 2;
            }
        }

        ///<summary>
        ///required by IHost interface, I think this has to do with the PlayListChange Event
        ///</summary>
        public void AddTrack2Plugin(TrackPlayer trackData, long TriggerOn, int Position = -1)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///required by IHost interface, I think this has to do with the PlayListChange Event
        ///</summary>
        public void AddTrack2Plugin(int trackID, long TriggerOn, int Position = -1)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///required by IHost interface, I think this has to do with the UIChange Event
        ///</summary>
        public void AssistedStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///required by IHost interface, I think this has to do with the UIChange Event
        ///</summary>
        public void AutoDJStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///To be honest: I've got no idea what this does
        ///</summary>
        public List<Events.EventAction> AvailableActions()
        {
            return MyEvents;
        }

        ///<summary>
        ///I don't think you can "close" a plugin without closing RadioDJ
        ///</summary>
        public void Closing()
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///Get settings from the XML storage
        ///</summary>
        private void LoadSettings()
        {
            string networks = MyHost.GetSetting(PluginFileName, "networks", "");
            Networks = networks.Split(new Char[] { ';' });
            Int32.TryParse(MyHost.GetSetting(PluginFileName, "UserId", ""), out UserId);
            Email = MyHost.GetSetting(PluginFileName, "Email", "");
            Password = MyHost.GetSetting(PluginFileName, "Password", "");
            Enabled = (MyHost.GetSetting(PluginFileName, "Enabled", "false") == "true");
            Message = MyHost.GetSetting(PluginFileName, "CustomData", "$artist$ - $title$");
            Int32.TryParse(MyHost.GetSetting(PluginFileName, "Interval", "0"), out Interval);
            Timing = MyHost.GetSetting(PluginFileName, "Timing", "WaitForPlayCount");
            string types = MyHost.GetSetting(PluginFileName, "Types", "");
            SelectedTrackTypes = types.Split(new Char[] { ';' });
        }

        ///<summary>
        ///Initialize with sensible defaults and load settings
        ///</summary>
        public void Initialize(IHost Host)
        {
            MyHost = Host;
            PluginFileName = Assembly.GetExecutingAssembly().GetName().Name;
            LoadSettings();
            Requester = new WebRequester();
            counter = 0;
            startTimer = DateTime.Now;
            trackTypes = Enum.GetNames(typeof(Tracks.TrackTypes));
        }

        ///<summary>
        ///To be honest: I've got no idea what this does
        ///</summary>
        public void InputStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///No Keyboard shortcuts for this plugin
        ///</summary>
        public void KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///To be honest: I've got no idea what this does
        ///</summary>
        public UserControl LoadGUI()
        {
            return null;
        }

        ///<summary>
        ///required by IHost interface, we're not interested in what you do with your Playlist
        ///</summary>
        public void PlaylistChanged()
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///required by IHost interface, we're not interested in what you do with your Categories
        ///</summary>
        public void ReloadCategories()
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///required by IHost interface, we're not interested in what you do with your Language settings
        ///</summary>
        public void ReloadLanguage()
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///To be honest: I've got no idea what this does
        ///</summary>
        public bool RunAction(string ActionName, string[] args)
        {
            return true;
        }

        ///<summary>
        ///Show the About box for this plugin
        ///</summary>
        public void ShowAbout()
        {
            MessageBox.Show("\u00a9" + DateTime.Now.Year.ToString() + " Xenzilla", PluginTitle);
        }

        ///<summary>
        ///Show our Config screen
        ///</summary>
        public void ShowConfig()
        {
            SongPoster_Config configWindow = new SongPoster_Config(this);
            configWindow.setCheckBoxEnable(Enabled);
            configWindow.Show();
        }

        ///<summary>
        ///Show our "Main" screen? When is this fired? Is double-clicking the plugin list and clicking the config button different?
        ///</summary>
        public void ShowMain()
        {
            SongPoster_Config configWindow = new SongPoster_Config(this);
            configWindow.setCheckBoxEnable(Enabled);
            configWindow.Show();
        }

        ///<summary>
        ///This is where the magic happens. Fired on track change
        ///</summary>
        public void TrackChanged(TrackPlayer Player)
        {
            //Check if the plugin is enabled (We trust you to have the config done properly)
            //AND 
            //Current Track's type is part of the user-selected Track types
            if (Enabled && (SelectedTrackTypes.Length == 0 || Array.Exists(SelectedTrackTypes, delegate (string s) { return s.Equals(Player.TrackData.TrackType.ToString()); })))
            {
                //increase counter for PlayCount Timing (if we're on "Time" timing, this won't hurt either. Worst that could happen is the number overflowing)
                counter++;
                //compare NOW and startTime + Interval minutes
                int compareTimes = DateTime.Compare(DateTime.Now, startTimer.AddMinutes(Interval));

                //Send a message if PlayCount counter is greater than the interval
                if (Timing == "WaitForPlayCount" && counter > Interval)
                {
                    //Disable Plugin if the webservice reports a problem
                    if (!Requester.sendRequest(Player.TrackData, Message, Networks, UserId, Password))
                    {
                        Enabled = false;
                    }
                    //reset counter
                    counter = 0;
                }
                //Send message if "Time" comparison results in the NOW time being greater than the base time + interval
                else if (Timing == "WaitForTime" && compareTimes >= 0)
                {
                    //Disable Plugin if the webservice reports a problem
                    if (!Requester.sendRequest(Player.TrackData, Message, Networks, UserId, Password))
                    {
                        Enabled = false;
                    }
                    //reset base time
                    startTimer = DateTime.Now;
                    //reset counter to prevent integer overflow
                    counter = 0;
                }
            }
        }
    }
}
