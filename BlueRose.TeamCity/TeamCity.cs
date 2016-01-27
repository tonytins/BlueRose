using Ionic.Zip;
using System;
using System.IO;
using System.Net;

namespace BlueRose.TeamCity
{
    public class Distro
    {
        /// <summary>
        /// Downloads and extracts teamcity.zip into the current directory.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static void tcAuto(string address, string buildType, string distFile = "teamcity.zip")
        {
            WebClient client = new WebClient();

            Uri uri = new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
            distFile = Path.GetFileName(uri.LocalPath);

            client.DownloadFileAsync(tcAddress(address, buildType), distFile);

            using (ZipFile buildUnpack = ZipFile.Read(distFile))
            {
                foreach (ZipEntry ex in buildUnpack)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distFile"></param>
        public static void tcUnpack(string distFile = "teamcity.zip")
        {
            using (ZipFile buildUnpack = ZipFile.Read(distFile))
            {
                foreach (ZipEntry ex in buildUnpack)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static string tcDistFile(string address, string buildType, string distFile = "teamcity.zip")
        {
            Uri uri = new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
            distFile = Path.GetFileName(uri.LocalPath);
            return distFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <returns></returns>
        public static Uri tcAddress(string address, string buildType)
        {
            return new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
        }
    }
}
