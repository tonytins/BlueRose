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
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Collections;
using System.Reflection;
namespace BlueRose
{
    public class WhiteRose
    {

        public static string[] fsoParmas { get; set; }

        public static string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        
        /// <summary>
        /// Returns a given URL. If it isn't there,
        /// defualt to Google.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri WebPage(string url)
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
        public static Uri WebURI(string url)
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
                fsoProcess.StartInfo.Arguments = ConvertStringArrayToString(fsoParmas);
                fsoProcess.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fso);
            }
        }

        public static void StartFSO(string fso, string args)
        {

            try
            {
                Process fsoProcess = new Process();

                fsoProcess.StartInfo.FileName = fso;
                fsoProcess.StartInfo.UseShellExecute = true;
                fsoProcess.StartInfo.Arguments = args;
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
        public static string DistNumLegacy()
        {
            string url = "http://servo.freeso.org/externalStatus.html?js=1";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(url);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
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
        public static string ReadBuild(string file)
        {
            string line;

            try
            {
                string buildFile = Environment.CurrentDirectory + @"/" + file;
                StreamReader fileRead = new StreamReader(buildFile);
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
        public static void WriteBuild(string file)
        {
            string buildFile = Environment.CurrentDirectory + @"/" + file;
            string localDist = DistNumLegacy();

            try
            {
                File.WriteAllText(buildFile, localDist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cleans up downloaded files.
        /// </summary>
        public static void ZipGC()
        {
            
            Wildcard wildZip = new Wildcard("*.zip", RegexOptions.IgnoreCase);
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

            foreach (string file in files)
            {
                if (wildZip.IsMatch(file))
                {
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// Detects for any present zips and unpacks them.
        /// </summary>
        public static void WildUnZipLegacy()
        {
            Wildcard unpacker = new Wildcard("*.zip", RegexOptions.IgnoreCase);

            // Get a list of files in the My Documents folder
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

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

        /// <summary>
        /// 
        /// </summary>
        public static void wildUnZip()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertStringArrayToString(string[] array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertStringArrayToStringJoin(string[] array)
        {
            //
            // Use string Join to concatenate the string elements.
            //
            string result = string.Join(".", array);
            return result;
        }


        public static void distUnZip(string dist)
        {
            using (ZipFile zip2 = ZipFile.Read(dist))
            {
                foreach (ZipEntry ex in zip2)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

    }
}
