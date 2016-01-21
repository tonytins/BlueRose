using System;
using System.Diagnostics;
using SysIO = System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace BlueRoseWinForms
{
    public class BlueRose : Form1
    {

        /// <summary>
        /// Returns a given URL. If it isn't there,
        /// defualt to Google.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri webPage(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch
            {
                return new Uri("https://google.com");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri webURL(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch
            {
                return new Uri(null);
            }
        }

        /// <summary>
        /// Fetches RSS feed
        /// </summary>
        /// <param name="feedurl"></param>
        /// <returns></returns>
        public static string ParseRSSFeed(string feedurl)
        {
            try
            {
                XmlDocument rssXmlDoc = new XmlDocument();
                rssXmlDoc.Load(feedurl);
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
                StringBuilder rssContent = new StringBuilder();
                foreach (XmlNode rssNode in rssNodes)
                {
                    XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                    string title = rssSubNode != null ? rssSubNode.InnerText : "";
                    rssContent.AppendFormat(title + Environment.NewLine);

                }
                return rssContent.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// If FreeSO isn't found, alert the user.
        /// If OpenAL isn't installed, show downloads address.
        /// </summary>
        /// <param name="fso"></param>
        public static void StartFSO(string fso)
        {
            string notFoundTitle = "Not found";
            string openAL3264 = @"C:\Program Files (x86)\OpenAL";
            string openAL = @"C:\Program Files\OpenAL";

            bool openALDir = SysIO.Directory.Exists(openAL3264) || SysIO.Directory.Exists(openAL);

            try
            {
                if (!openALDir)
                {
                    MessageBox.Show("OpenAL not found!" + Environment.NewLine + "Go to openal.org/downloads and get the Windows installer...", notFoundTitle);
                }
                else
                {
                    Process fsoProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo(fso)
                    };

                    fsoProcess.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fso + " not found.");
            }
        }
    }
}
