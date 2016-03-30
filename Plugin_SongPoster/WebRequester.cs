using rdjInterface;
using System;
using System.Net;
using System.Threading;
using System.Web;


namespace Plugin_SongPoster
{
    class WebRequester
    {
        public void sendRequest(SongData nowPlaying, string template, string[] networks, string userId, string password)
        {
            // Parse variable message template and fill in data from nowPlaying
            string sendText = Variables.Update(template, nowPlaying, false);

            // For each selected network, build custom URL and start a "send" task
            foreach (string network in networks)
            {
                sendText = "http://songposter.net/send-post/" + network + "/" + userId + "/1/" + password + "/" + HttpUtility.UrlEncode(sendText);
                try
                {
                    WebClient client = new WebClient();
                    client.DownloadStringCompleted += (sender, e) =>
                    {
                        if (!e.Cancelled && e.Error == null)
                        {
                            Utils.LogMe((string)e.Result, false);
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
