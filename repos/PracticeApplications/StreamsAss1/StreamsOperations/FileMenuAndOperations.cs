using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsOperations
{
    public class FileMenuAndOperations
    {
        public void Main()
        {
            int ch;
            bool looping = true;
            while(looping)
            {
                Console.WriteLine("1.List of Drives");
                Console.WriteLine("2.list of all Directories");
                Console.WriteLine("3.list of all files");
                Console.WriteLine("4.Searching a file");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter the choice :");
                DrawLine(40, "*");
                ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1: ListOfDrives();
                        break;
                    case 2: ListOfAllDirectories();
                        break;
                    case 3: ListOfFiles();
                        break;
                    case 4: SearchFile();
                        break;
                    case 5 : looping = false;
                        break;
                }

            }
        }

        private void SearchFile()
        {
            Console.WriteLine("Enter the drive name :");
            var drive = Console.ReadLine();
            Console.WriteLine("Enter the Diectory");
            var dir = Console.ReadLine();
            Console.WriteLine("Enter file to be Searched");
            var file = Console.ReadLine();

            /* var dirs = Directory.GetDirectories(drive + "" + dir);
             foreach(var dire in dirs)
             {
                 var files = Directory.GetFiles(dire);
                 foreach (var searchFile in files)
                 {
                     if (file.Equals(searchFile))
                     {
                         Console.WriteLine($"Search file :{searchFile}");
                         break;
                     }
                 }
             }*/

            DirectoryInfo startDir = new DirectoryInfo(drive+""+dir);
            FindFile(drive+""+dir, file);
            DrawLine(30, "-");

        }

        private void FindFile(string directory, string file)
        {
            
            //file = "test.txt";
            var files = Directory.GetFiles(directory);
            foreach (var searchFile in files)
            {
                var filename = Path.GetFileName(searchFile);
                if (file.Equals(filename))
                {
                    Console.WriteLine($"Search file :{searchFile}");
                    break;
                }
            }
            var subDir = Directory.GetDirectories(directory);
            foreach (var subdirectory in subDir)
            {                
                FindFile(subdirectory,file);
            }
        }

        private void ListOfFiles()
        {
            Console.WriteLine("Enter the drive name :");
            var drive = Console.ReadLine();
            // var directories = Directory.GetDirectories(drive);
            Console.WriteLine("Enter the Diectory");
            var dir = Console.ReadLine();
            var dirs = Directory.GetDirectories(drive+""+dir);
            
            foreach (var d in dirs)
            {
                var files = Directory.GetFiles(d);
                foreach (var file in files)
                    Console.WriteLine(file);
            }
           var dirfiles = Directory.GetFiles(drive + "" + dir);
            foreach (var file in dirfiles)
                Console.WriteLine(file);

            DrawLine(30, "-");
        }

        private void ListOfAllDirectories()
        {
            Console.WriteLine("Enter the drive name :");
            var drive = Console.ReadLine();
            //var drives = DriveInfo.GetDrives();
            Console.WriteLine("2.List of Directories");
            DrawLine(30, "-");
            /*foreach (var drive in drives)
            {
                var directories = Directory.GetDirectories(drive.Name);
                foreach (var dir in directories)
                    Console.WriteLine(dir);
            }*/
            var directories = Directory.GetDirectories(drive);
            foreach (var dir in directories)
                 Console.WriteLine(dir);

            DrawLine(30, "-");

        }

        private void ListOfDrives()
        {
            var drives = DriveInfo.GetDrives();
            Console.WriteLine("1.List of Drives");
            DrawLine(30, "-");
            foreach(var drive in drives)
            {
                Console.WriteLine(drive);
            }
            DrawLine(30, "-");
        }

        private void DrawLine(int v1, string v2)
        {
            for (int i = 0; i < v1; i++)
                Console.Write(v2);
            Console.WriteLine();
        }
    }
}
