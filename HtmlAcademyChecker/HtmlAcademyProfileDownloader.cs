using System;
using System.Net;
using System.Text;

namespace HtmlAcademyChecker
{
    public class HtmlAcademyProfileDownloader : IProfileDownloader
    {
        public string Download(int profileId)
        {
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                try
                {
                    return webClient.DownloadString(String.Format("http://htmlacademy.ru/public_profiles/id{0}", profileId));
                }
                catch (WebException ex)
                {
                    // log
                    return null;
                }
            }
        }
    }
}