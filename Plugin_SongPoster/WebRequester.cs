using rdjInterface;
using System;
using System.Net;
using System.Reflection;
using System.IO;


namespace Plugin_SongPoster
{
    class WebRequester
    {
        public void sendRequest(SongData nowPlaying, string template, string[] networks, string userId, string password)
        {
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Plugin_SongPoster.log";

            // Parse variable message template and fill in data from nowPlaying
            string sendTextVars = Variables.Update(template, nowPlaying, false);

            // For each selected network, build custom URL and start a "send" task
            foreach (string network in networks)
            {
                string sendText = "http://songposter.net/send-post/" + network + "/0/" + userId + "/" + password + "/" + Uri.EscapeDataString(sendTextVars);
                try
                {
                    WebClient client = new WebClient();
                    client.DownloadStringCompleted += (sender, e) =>
                    {
                        if (!e.Cancelled && e.Error == null)
                        {
                            using (StreamWriter outputFile = new StreamWriter(filename, true))
                            {
                                outputFile.WriteLine(sendText);
                                outputFile.WriteLine((string) e.Result);
                            }
                        }
                    };
                    client.DownloadStringAsync(new Uri(sendText));
                    // @ToDo save the response to a log file or some internal RadioDJ log (investigate Utils.LogMe method)
                }
                catch (Exception e)
                {
                    // @ToDo do some proper error handling
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }
}
