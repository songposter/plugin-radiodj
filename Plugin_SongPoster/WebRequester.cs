using rdjInterface;
using System;
using System.Net;
using System.Reflection;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Plugin_SongPoster
{
    class WebRequester
    {
        public Boolean sendRequest(SongData nowPlaying, string template, string[] networks, int userId, string password)
        {
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Plugin_SongPoster.log";

            // Parse variable message template and fill in data from nowPlaying
            string sendTextVars = Variables.Update(template, nowPlaying, false);

            Boolean error = false;

            // For each selected network, build custom URL and start a "send" task
            foreach (string network in networks)
            {
                string sendText = "http://songposter.net/send-post/" + network.ToLower() + "/0/" + userId.ToString() + "/" + Uri.EscapeDataString(password) + "/" + Uri.EscapeDataString(sendTextVars);
                try
                {
                    WebClient client = new WebClient();
                    client.Headers.Add("user-agent", "SongPoster/0.4 (RadioDJ)");
                    client.DownloadStringCompleted += (sender, e) =>
                    {
                        if (!e.Cancelled && e.Error == null)
                        {
                            using (StreamWriter outputFile = new StreamWriter(filename, true))
                            {
                                outputFile.WriteLine(sendText);
                                outputFile.WriteLine(e.Result);
                            }
                        }
                        else
                        {
                            HttpWebResponse response = (HttpWebResponse)((WebException)e.Error).Response;
                            int statusCode = (int)response.StatusCode;
                            string responseText;
                            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                            {
                                responseText = reader.ReadToEnd();
                            }

                            // Only show the messagebox if the error variable isn't set
                            if (!error)
                            {
                                error = true;
                                MessageBox.Show(responseText, "SongPoster Plugin Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            using (StreamWriter outputFile = new StreamWriter(filename, true))
                            {
                                outputFile.WriteLine(sendText);
                                outputFile.WriteLine("[" + DateTime.Now.ToString("u") + "] ERROR: " + responseText);
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

            return error;

        }
    }
}
