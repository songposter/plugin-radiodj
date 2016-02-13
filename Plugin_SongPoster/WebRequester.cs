using System;
using System.Net;
using System.Web;
using System.Threading;
using rdjInterface;


namespace Plugin_SongPoster
{
    class WebRequester
    {
        private Thread webWorker;

        public void sendRequest(SongData nowPlaying, string template, string[] networks, string userId, string password)
        {
            // Parse variable message template and fill in data from nowPlaying
            string sendText = Variables.Update(template, nowPlaying, false);
            
            // Create a new thread for actually sending stuff to web, so this is non-blocking while waiting for a response from the web
            webWorker = new Thread(new ParameterizedThreadStart(doWork));
            webWorker.IsBackground = true;

            // For each selected network, build custom URL and start a "send" task
            foreach (string network in networks)
            {
                sendText = "http://songposter.net/send-post/" + network + "/" + userId + "/1/" + password + "/" + HttpUtility.UrlEncode(sendText);
                webWorker.Start(sendText);
            }
            
        }

        public void doWork(object sendObject)
        {
            string sendText = sendObject.ToString();

            try
            {
                HttpWebRequest request = WebRequest.Create(sendText) as HttpWebRequest;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "http_requester/0.2";
                request.Timeout = 5000;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // @ToDo save the response to a log file or some internal RadioDJ log (investigate Ihost.LogMe method)
                response.Close();
            }
            catch (Exception e)
            {
                // @ToDo do some proper error handling
                Console.WriteLine(e.Message);
            }
            Thread.CurrentThread.Abort();
        }
    }
}
