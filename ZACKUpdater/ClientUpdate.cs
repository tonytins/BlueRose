using System;
using System.Net;
using System.ComponentModel;
using System.IO.Compression;
using System.IO;

namespace ZACKUpdater
{
    class ClientUpdate
    {
        WebClient client = new WebClient();

        private string downloadedFile { get; set; }

        public void Install(Uri address, string compressedFile)
        {
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);
            client.DownloadFileAsync(address, compressedFile);
            downloadedFile = compressedFile;
        }

        private void Extract(object sender, AsyncCompletedEventArgs e)
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
