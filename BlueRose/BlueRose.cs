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

namespace BlueRose
{
    public class BlueRose
    {

        public static string[] fsoParmas { get; set; }

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
                    Process fsoProcess = new Process();
                    fsoProcess.StartInfo.FileName = fso;

                    /* if (fsoParmas.Length > 0)
                    {
                        int ScreenWidth = int.Parse(fsoParmas[0].Split("x".ToCharArray())[0]);
                        int ScreenHeight = int.Parse(fsoParmas[0].Split("x".ToCharArray())[1]);

                        fsoProcess.StartInfo.Arguments = ScreenWidth.ToString();
                        fsoProcess.StartInfo.Arguments = ScreenHeight.ToString();

                        if (fsoParmas.Length > 1)
                        {
                            if (fsoParmas[1].Equals("w", StringComparison.InvariantCultureIgnoreCase))
                                fsoProcess.StartInfo.Arguments = "w";
                            else if (fsoParmas[1].Equals("f", StringComparison.InvariantCultureIgnoreCase))
                                fsoProcess.StartInfo.Arguments = "f";
                        }
                    } */

                    fsoProcess.StartInfo.UseShellExecute = true;
                    fsoProcess.Start();
                }

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
            return "Get dist #" + sLine;
        }

        /// <summary>
        /// Cleans up downloaded files.
        /// </summary>
        public static void GC()
        {
            string htmlOutput = "downloadArtifacts.html";
            string brStableInstaller = "BlueRoseStable.exe";
            string brBetaInstaller = "BlueRoseBeta.exe";

            if (SysIO.File.Exists(brStableInstaller))
                SysIO.File.Delete(brStableInstaller);

            if (SysIO.File.Exists(brBetaInstaller))
                SysIO.File.Delete(brBetaInstaller);

            if (SysIO.File.Exists(htmlOutput))
                SysIO.File.Delete(htmlOutput);

            Wildcard wildZip = new Wildcard("*.zip", RegexOptions.IgnoreCase);
            string[] files = SysIO.Directory.GetFiles(Environment.CurrentDirectory);

            foreach(string file in files)
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
