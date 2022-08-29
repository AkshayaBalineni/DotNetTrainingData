using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFileToSubFolder
{
   public class FileToSubFolder
    {
        public void Main()
        {
            string path = @"D:\filrStreamOperations\temp\file1.txt";
            string newPath = @"D:\filrStreamOperations\temp\subTemp\";
            if (!File.Exists(path))
            { 
            using (FileStream fs = File.Create(path))
                {
                    Console.WriteLine("file created.");
                }
            }
            if(!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (File.Exists(newPath + "copiedFile.txt"))
                File.Delete(newPath + "copiedFile.txt");
            File.Copy(path, newPath+"copiedFile.txt");
            Console.WriteLine("File copied from root to sub dirctory");
        }
    }
}
