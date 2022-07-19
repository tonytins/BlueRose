using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Net;
using System.Linq;
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
        /// Returns all files by their extensions within the current directory.
        /// You only need to type in the name of the extension.
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static FileInfo[] FileWildCard(string fileExt)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
            FileInfo[] files = dir.GetFiles("*." + fileExt.ToLower()).Where(p => p.Extension == "." + fileExt.ToLower()).ToArray();
            return files;
        }

        /// <summary>
        /// Returns all files by their extensions in the selected directory.
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static FileInfo[] FileWildCard(string fileExt, string fileDir)
        {
            DirectoryInfo dir = new DirectoryInfo(fileDir);
            FileInfo[] files = dir.GetFiles("*." + fileExt.ToLower()).Where(p => p.Extension == "." + fileExt.ToLower()).ToArray();
            return files;
        }

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
        /// Cleans up any ZIP files.
        /// Uses Code Project's Wildcard class.
        /// </summary>
        public static void ZipGcCompat()
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
        /// Cleans up any ZIP files.
        /// </summary>
        public static void ZipGC()
        {
            FileInfo[] files = FileWildCard("zip");

            foreach (FileInfo file in files)
            {
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Detects for any present zips and unpacks them.
        /// Uses Code Project's Wildcard class.
        /// </summary>
        public static void WildUnZipCompat()
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
        /// Detects for any present zips and unpacks them.
        /// </summary>
        public static void wildUnZip()
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
            FileInfo[] files = dir.GetFiles("*.zip").Where(p => p.Extension == ".zip").ToArray();

            foreach (FileInfo file in files)
            {
                using (ZipFile zip2 = ZipFile.Read(file.FullName))
                {
                    foreach (ZipEntry ex in zip2)
                    {
                        ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
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
