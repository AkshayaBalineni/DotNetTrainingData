using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
    public class FileStreamOperation
    {
       public void Main()
        {
            string filePath = @"D:\filrStreamOperations\createFile.txt";
            string newPath = @"D:\filrStreamOperations\copiedFile.txt";
            string oldFile = @"D:\filrStreamOperations\oldFile.txt";
            string renameFile = @"D:\filrStreamOperations\renamedFile.txt";
            string deleteFile = @"D:\filrStreamOperations\deleteFile.txt";
            string dircectory = @"D:\filrStreamOperations\CreateDirectory";
            int ch = 0;
            bool loop = true;
            while(loop)
            {
                Console.WriteLine("File  Menu");
                DrawLine(50, "*");
                Console.WriteLine("1.Create File");
                Console.WriteLine("2.Copy File");
                Console.WriteLine("3.Remane File");
                Console.WriteLine("4.Delete File");
                Console.WriteLine("5.Create Directory");
                Console.WriteLine("6.Delete Directory");
                Console.WriteLine("7.Write in to File");
                Console.WriteLine("8.Read in to File");
                Console.WriteLine("9. Exit");
                DrawLine(40, "*");
                Console.Write("Enter the choice :  ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1 : CreateFile(filePath);break;
                    case 2 : CopyFile(filePath, newPath);break;
                    case 3 : RenameFile(oldFile, renameFile);break;
                    case 4 : DeleteFile(deleteFile);break;
                    case 5 : CreateDirectory(dircectory);break;
                    case 6 : DeleteDirectory(dircectory);break;
                    case 7 : WriteIntoFile(filePath);break;
                    case 8: ReadIntoFile(filePath);break;
                    case 9: loop = false;break;
                }
            }
        
        }

        private void ReadIntoFile(string filePath)
        {
            if (!File.Exists(filePath))
                Console.WriteLine("There is no file to read");
            Console.WriteLine("reading the file");
            DrawLine(50, "*");
            string line = string.Empty;
            using(StreamReader sr = new StreamReader(filePath,true))
            {
                while ((line = sr.ReadLine()) != null)
                    Console.WriteLine(line);
            }
            DrawLine(50, "*");
        }

        private void WriteIntoFile(string filePath)
        {
            if (!File.Exists(filePath))
                CreateFile(filePath);
             string line = string.Empty;
			Console.WriteLine("Enter the content to write to the file. Enter 0 to exit.");
			using(StreamWriter sw = new StreamWriter(filePath, true))
			{
				line = Console.ReadLine();
				while (line != "0")
				{
					sw.WriteLine(line);
					line = Console.ReadLine();
				}
			}
			Console.WriteLine("Completed writing to file");
            DrawLine(50, "*");
        }

        private void DeleteDirectory(string dircectory)
        {
            if (Directory.Exists(dircectory))
            {
                Directory.Delete(dircectory);
                Console.WriteLine("Directory deleted");
            }
            else
                Console.WriteLine("There is no such directory found");
            DrawLine(50, "*");
        }

        private void CreateDirectory(string dircectory)
        {
            if (Directory.Exists(dircectory))
                Console.WriteLine("Directory exists");
            Directory.CreateDirectory(dircectory);
            Console.WriteLine("Directory Created");   
             DrawLine(50, "*");
        }

        private void DeleteFile(string deleteFile)
        {
            CreateFile(deleteFile);
            File.Delete(deleteFile);
            Console.WriteLine($"{deleteFile} is deleted");
            DrawLine(50, "*");
        }
        private void RenameFile(string oldFile, string renameFile)
        {
            using (FileStream fs = File.Create(oldFile)) 
            {
            }

            File.Move(oldFile, renameFile);
            Console.WriteLine("File Renamed");
            DrawLine(50, "*");
        }

        private void CopyFile(string filePath,string newPath)
        {
            if (File.Exists(filePath))
            {
                if (File.Exists(newPath))
                    File.Delete(newPath);
                File.Copy(filePath, newPath);
                Console.WriteLine($"{Path.GetFullPath(filePath)} is copied to {newPath}");
            }
            else
                Console.WriteLine("File not found");
            DrawLine(50, "*");
        }
        private void CreateFile(string filePath)
        {
            if(File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} already exists");
            }
            else
            {
                using (FileStream fs = File.Create(filePath))
                {
                    Console.WriteLine($"{filePath} is created");
                }
            }
            DrawLine(50, "*");
        }
        private void DrawLine(int v1, string v2)
        {
            for (int i = 0; i <= v1; i++)
                Console.Write(v2);
            Console.WriteLine();
        }
    }
}
