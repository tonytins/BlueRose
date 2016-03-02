using System;
using System.Net;
using System.ComponentModel;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;

namespace ZACKUpdater
{
    public class SelfUpdate
    {
        WebClient client = new WebClient();

        private string downloadedFile { get; set; }
        public static string newProccessInfo { get; set; }

        public void Install(Uri address, string compressedFile, string newProcess)
        {
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(ExtractExit);
            client.DownloadFileAsync(address, compressedFile);
            newProccessInfo = newProcess;
            downloadedFile = compressedFile;
        }

        private void ExtractExit(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(downloadedFile))
                {
                    foreach (ZipArchiveEntry ex in archive.Entries)
                    {
                        ex.ExtractToFile(Path.Combine(Environment.CurrentDirectory, ex.FullName), true);
                    }
                }

                UpdateGC.GC();

                try {
                    ProcessStartInfo newProccess = new ProcessStartInfo(newProccessInfo);
                    newProccess.UseShellExecute = true;
                    newProccess.Verb = "runas";
                    Process.Start(newProccess);
                    Environment.Exit(0);
                }
                catch (Exception ex )
                { Console.WriteLine(ex.Message);  }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
