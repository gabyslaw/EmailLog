using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmailLog.Helpers
{
    public class FileConverter
    {
        public static string GetFilePath(string path)
        {
            string envPath = HttpRuntime.AppDomainAppPath;
            string fileName = $"{envPath}{path}";
            return fileName;
        }
        public static Byte[] Convert(string fullpath)
        {
            byte[] fileData = null;
            FileInfo fileInfo = new FileInfo(fullpath);
            long fileLength = fileInfo.Length;
            FileStream fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            fileData = br.ReadBytes((int)fileLength);
            return fileData;
        }
    }
}