using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ZACKUpdater
{
    public class UpdateInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processInfo"></param>
        /// <param name="address"></param>
        /// <param name="compressedFile"></param>
        public static void SelfUpdate(string processInfo, Uri address, string compressedFile)
        {
            SelfUpdate install = new SelfUpdate();
            install.Install(address, compressedFile, processInfo);
        }

        public static void ClientUpdate()
        {

        }
    }
}
