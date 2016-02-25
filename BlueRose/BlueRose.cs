// Copyright(C) 2016  Blue Rose Project

// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.Diagnostics;
using SysIO = System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Net;
using BlueRose.Distro;

namespace BlueRose
{
    public class BlueRose
    {

        public static string[] fsoParmas { get; set; }

        public static Uri teamCityUri(string address = "servo.freeso.org", string buildType = "ProjectDollhouse_TsoClient", string buildId = "316")
        {
            // http://servo.freeso.org/repository/download/ProjectDollhouse_TsoClient/316:id/dist-241.zip
            return new Uri(@"http://" + address + @"/repository/download/" + buildType + @"/" + buildId + @":id/dist-" + distNum() + ".zip?guest=1");
        }

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
        /// If FreeSO isn't found, alert the user.
        /// If OpenAL isn't installed, show downloads address.
        /// </summary>
        /// <param name="fso"></param>
        public static void StartFSO(string fso)
        {
            
            try
            {
                Process fsoProcess = new Process();

                fsoProcess.StartInfo.FileName = fso;
                fsoProcess.StartInfo.UseShellExecute = true;
                fsoProcess.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fso);
            }
            

        }

        /// <summary>
        /// Return the latest dist number as a string
        /// Thanks to LRB. http://forum.freeso.org/threads/974/
        /// </summary>
        /// <returns>sLine</returns>
        public static string distNum()
        {
            string url = "http://servo.freeso.org/externalStatus.html?js=1";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(url);
            SysIO.Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            SysIO.StreamReader objReader = new SysIO.StreamReader(objStream);
            string sLine = "";
            string fll;
            fll = objReader.ReadLine();
            sLine = fll.Remove(0, 855);
            sLine = sLine.Remove(sLine.IndexOf("</a>"));
            return sLine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string readBuild(string file)
        {
            string line;

            try
            {
                string buildFile = Environment.CurrentDirectory + @"/" + file;
                SysIO.StreamReader fileRead = new SysIO.StreamReader(buildFile);
                while ((line = fileRead.ReadLine()) != null)
                {
                    return "#" + line;
                }

                fileRead.Close();
            }
            catch
            {
                return "NONE";
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public static void writeBuild(string file)
        {
            string buildFile = Environment.CurrentDirectory + @"/" + file;
            string localDist = distNum();

            try
            {
                SysIO.File.WriteAllText(buildFile, localDist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cleans up downloaded files.
        /// </summary>
        public static void GC()
        {
            string htmlOutput = "downloadArtifacts.html";
            string brLegacyInstaller = "BlueRoseStable.exe";
            string brUpdateInstaller = "BlueRoseUpdate.exe";

            if (SysIO.File.Exists(brLegacyInstaller))
                SysIO.File.Delete(brLegacyInstaller);

            if (SysIO.File.Exists(brUpdateInstaller))
                SysIO.File.Delete(brUpdateInstaller);

            if (SysIO.File.Exists(htmlOutput))
                SysIO.File.Delete(htmlOutput);

            Wildcard wildZip = new Wildcard("*.zip", RegexOptions.IgnoreCase);
            string[] files = SysIO.Directory.GetFiles(Environment.CurrentDirectory);

            foreach (string file in files)
            {
                if (wildZip.IsMatch(file))
                {
                    SysIO.File.Delete(file);
                }
            }
        }

        /// <summary>
        /// Detects for any present zips and unpacks them.
        /// </summary>
        public static void wildUnZip()
        {
            Wildcard unpacker = new Wildcard("*.zip", RegexOptions.IgnoreCase);

            // Get a list of files in the My Documents folder
            string[] files = SysIO.Directory.GetFiles(Environment.CurrentDirectory);

            foreach (string file in files)
            {
                if (unpacker.IsMatch(file))
                {
                    using (ZipFile zip2 = ZipFile.Read(file))
                    {
                        foreach (ZipEntry ex in zip2)
                        {
                            ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                }
            }
        }



    }
}
