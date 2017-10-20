using rdjInterface;
using System;
using System.Net;
using System.Reflection;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using TagLib;

namespace Plugin_SongPoster
{
    class WebRequester
    {
        public Boolean SendRequest(SongPoster spRef, SongData nowPlayingData, string template, string[] networks, int userId, string password, bool coverArtEnabled)
        {
            string logFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Plugin_SongPoster.log";

            // Parse variable message template and fill in data from nowPlaying
            string sendTextVars = Variables.Update(template, nowPlayingData, false).Replace("/", "___SLASHslashSLASH___");
            string pictureVars = Variables.Update("$album_cover$", nowPlayingData, false);

            Boolean success = true;

            // For each selected network, build custom URL and start a "send" task
            foreach (string network in networks)
            {
                string sendText = "http://songposter.net/send-post/" + network.ToLower() + "/0/" + userId.ToString() + "/" + Uri.EscapeDataString(password) + "/" + Uri.EscapeDataString(sendTextVars);

                if (coverArtEnabled)
                {
                    if (spRef.SendCoverArtPictureLocation == "picturesOnline")
                    {
                        sendText = sendText + "/" + Uri.EscapeDataString(pictureVars);
                    }
                    else if (spRef.SendCoverArtPictureLocation == "picturesTag")
                    {
                        string base64Picture = "data:";

                        try
                        {
                            string filePath = nowPlayingData.Path;
                            TagLib.File trackFile = TagLib.File.Create(filePath);

                            if (trackFile.Tag.Pictures.Length > 0)
                            {
                                IPicture picture = trackFile.Tag.Pictures.First();
                                base64Picture += picture.MimeType + ";base64,";
                                base64Picture += Convert.ToBase64String(picture.Data.Data);
                                base64Picture.Replace('+', '-').Replace('/', '_');
                                sendText = sendText + "/" + base64Picture;
                            }
                        }
                        catch(FileNotFoundException e)
                        {
                            using (StreamWriter logFile = new StreamWriter(logFileName, true))
                            {
                                logFile.WriteLine("Error loading:" + e.FileName);
                            }
                        }
                    }
                    
                }

                try
                {
                    WebClient client = new WebClient
                    {
                        Encoding = Encoding.UTF8
                    };
                    client.Headers.Add("user-agent", "SongPoster/0.6 (RadioDJ)");

                    client.DownloadStringCompleted += (sender, e) =>
                    {
                        if (!e.Cancelled && e.Error == null)
                        {
                            using (StreamWriter logFile = new StreamWriter(logFileName, true))
                            {
                                logFile.WriteLine(sendText);
                                logFile.WriteLine(e.Result);
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

                            // Only show the messagebox if the success variable was previously set
                            if (success)
                            {
                                success = false;
                                MessageBox.Show(responseText, "SongPoster Plugin Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            using (StreamWriter logFile = new StreamWriter(logFileName, true))
                            {
                                logFile.WriteLine(sendText);
                                logFile.WriteLine("[" + DateTime.Now.ToString("u") + "] ERROR: " + responseText);
                            }
                        }
                    };
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Log_completedDownload);
                    client.DownloadStringAsync(new Uri(sendText));
                }
                catch (Exception e)
                {
                    // @ToDo do some proper error handling
                    Console.WriteLine(e.Message);
                    success = false;
                }
            }

            return success;

        }

        private void Log_completedDownload(object sender, DownloadStringCompletedEventArgs args)
        {
            Utils.LogMe(args.Result, true);
        }
    }
}
