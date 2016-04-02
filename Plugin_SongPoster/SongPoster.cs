using rdjInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Plugin_SongPoster
{
    // This is our main class and entrypoint for RadioDJ
    public class SongPoster : IPlugin
    {
        // Declaration required for AvailableActions method from IPlugin interface, no idea what that does, though
        private List<Events.EventAction> MyEvents;

        // Reference to the IHost interface by which we interact with the RadioDJ main program
        public IHost MyHost;

        // This is the class where the actual web requests are sent
        private WebRequester Requester;

        // Counter for PlayCount Timer.
        private int counter;

        // Base time from which to count minutes for the "Time" timer
        private DateTime startTimer;

        // Interval (minutes/playcounts) after which a track is sent
        public int Interval;

        // Defines the kind of timing for the Interval, either WaitForPlayCount or WaitForTime
        public string Timing;

        // Message (Template) to send out
        public string Message;

        // Array of networks to use and send the track info to
        public string[] Networks;

        // SongPoster Userid
        public string UserId;

        // SongPoster Password
        public string Password;

        // Plugin must be enabled by hand (after configuration)
        public bool Enabled = false;

        // Reference by which Settings are stored and loaded
        public string PluginFileName;

        // Constructor
        public SongPoster()
        {
            MyEvents = new List<Events.EventAction>();
        }

        // required by IHost interface, no idea what it's good for
        public bool HasActions
        {
            get
            {
                return true;
            }
        }

        // required by IHost interface, we're not interested in what you do with your Playlist
        public bool NotifyOnPlaylistChange
        {
            get
            {
                return false;
            }
        }

        // required by IHost interface, let us know when the current track changes so we can send a message to SongPoster
        public bool NotifyOnTrackChange
        {
            get
            {
                return true;
            }
        }

        // required by IHost interface, no idea what it's good for
        public bool NotifyOnUIChange
        {
            get
            {
                return true;
            }
        }

        // required by IHost interface, Meta Data
        public string PluginDescription
        {
            get
            {
                return "SongPoster.net Webservice to Share Now Playing Info to social networks";
            }
        }

        // required by IHost interface, Meta Data
        public string PluginName
        {
            get
            {
                return "SongPoster";
            }
        }

        // required by IHost interface, Meta Data
        public string PluginTitle
        {
            get
            {
                return "SongPoster";
            }
        }

        // required by IHost interface, Meta Data
        public string PluginVersion
        {
            get
            {
                return "0.4";
            }
        }

        // required by IHost interface, no idea what it's good for or what Zones are available at all
        public int PluginZone
        {
            get
            {
                return 2;
            }
        }

        // required by IHost interface, I think this has to do with the PlayListChange Event
        public void AddTrack2Plugin(TrackPlayer trackData, long TriggerOn, int Position = -1)
        {
            //throw new NotImplementedException();
        }

        // required by IHost interface, I think this has to do with the PlayListChange Event
        public void AddTrack2Plugin(int trackID, long TriggerOn, int Position = -1)
        {
            //throw new NotImplementedException();
        }

        // required by IHost interface, I think this has to do with the UIChange Event
        public void AssistedStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        // required by IHost interface, I think this has to do with the UIChange Event
        public void AutoDJStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        // To be honest: I've got no idea what this does
        public List<Events.EventAction> AvailableActions()
        {
            return MyEvents;
        }

        // I don't think you can "close" a plugin without closing RadioDJ
        public void Closing()
        {
            //throw new NotImplementedException();
        }

        // Get settings from the XML storage
        private void LoadSettings()
        {
            string networks = MyHost.GetSetting(PluginFileName, "networks", "");
            Networks = networks.Split(new Char[] { ';' });
            UserId = MyHost.GetSetting(PluginFileName, "UserId", "");
            Password = MyHost.GetSetting(PluginFileName, "Password", "");
            Enabled = (MyHost.GetSetting(PluginFileName, "Enabled", "false") == "true");
            Message = MyHost.GetSetting(PluginFileName, "CustomData", "$artist$ - $title$");
            Interval = Int32.Parse(MyHost.GetSetting(PluginFileName, "Interval", "0"));
            Timing = MyHost.GetSetting(PluginFileName, "Timing", "WaitForPlayCount");
        }

        // Initialize with sensible defaults and load settings
        public void Initialize(IHost Host)
        {
            MyHost = Host;
            PluginFileName = Assembly.GetExecutingAssembly().GetName().Name;
            LoadSettings();
            Requester = new WebRequester();
            counter = 0;
            startTimer = DateTime.Now;
        }

        // To be honest: I've got no idea what this does
        public void InputStateChanged(bool newState)
        {
            //throw new NotImplementedException();
        }

        // No Keyboard shortcuts for this plugin
        public void KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        // To be honest: I've got no idea what this does
        public UserControl LoadGUI()
        {
            return null;
        }

        // required by IHost interface, we're not interested in what you do with your Playlist
        public void PlaylistChanged()
        {
            //throw new NotImplementedException();
        }

        // required by IHost interface, we're not interested in what you do with your Categories
        public void ReloadCategories()
        {
            //throw new NotImplementedException();
        }

        // required by IHost interface, we're not interested in what you do with your Language settings
        public void ReloadLanguage()
        {
            //throw new NotImplementedException();
        }

        // To be honest: I've got no idea what this does
        public bool RunAction(string ActionName, string[] args)
        {
            return true;
        }

        // Show the About box for this plugin
        public void ShowAbout()
        {
            MessageBox.Show("\u00a9" + DateTime.Now.Year.ToString() + " Xenzilla", PluginTitle);
        }

        // Show our Config screen
        public void ShowConfig()
        {
            SongPoster_Config configWindow = new SongPoster_Config(this);
            configWindow.setCheckBoxEnable(Enabled);
            configWindow.Show();
        }

        // Show our "Main" screen? When is this fired? Is double-clicking the plugin list and clicking the config button different?
        public void ShowMain()
        {
            SongPoster_Config configWindow = new SongPoster_Config(this);
            configWindow.setCheckBoxEnable(Enabled);
            configWindow.Show();
        }

        // This is where the magic happens. Fired on track change
        public void TrackChanged(TrackPlayer Player)
        {
            // Check if the plugin is enabled (We trust you to have the config done properly)
            if (Enabled)
            {
                // increase counter for PlayCount Timing (if we're on "Time" timing, this won't hurt either. Worst that could happen is the number overflowing)
                counter++;
                // compare NOW and startTime + Interval minutes
                int compareTimes = DateTime.Compare(DateTime.Now, startTimer.AddMinutes(Interval));

                // Send a message if PlayCount counter is greater than the interval
                if (Timing == "WaitForPlayCount" && counter > Interval)
                {
                    // Disable Plugin if the webservice reports a problem
                    if (!Requester.sendRequest(Player.TrackData, Message, Networks, UserId, Password))
                    {
                        Enabled = false;
                    }
                    // reset counter
                    counter = 0;
                }
                // Send message if "Time" comparison results in the NOW time being greater than the base time + interval
                else if (Timing == "WaitForTime" && compareTimes >= 0)
                {
                    // Disable Plugin if the webservice reports a problem
                    if (!Requester.sendRequest(Player.TrackData, Message, Networks, UserId, Password))
                    {
                        Enabled = false;
                    }
                    // reset base time
                    startTimer = DateTime.Now;
                    // reset counter to prevent integer overflow
                    counter = 0;
                }
            }
        }
    }
}
