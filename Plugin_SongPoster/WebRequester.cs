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
            string sendText = Variables.Update(template, nowPlaying, false);
            
            webWorker = new Thread(new ParameterizedThreadStart(doWork));
            webWorker.IsBackground = true;

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
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.CurrentThread.Abort();
        }
    }
}
