// Copyright(c) 2016 Blue Rose Project

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
//  associated documentation files (the "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
//  copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to 
//  the following conditions:

// The above copyright notice and this permission notice shall be included in all copies or substantial 
//  portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
//  PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
//  FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//  ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Ionic.Zip;
using System;
using System.IO;
using System.Net;

namespace BlueRose.Distro
{
    public class TeamCity
    {
        /// <summary>
        /// Downloads and extracts teamcity.zip into the current directory.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static void tcManaged(string address, string buildType, string distFile = "teamcity.zip")
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
