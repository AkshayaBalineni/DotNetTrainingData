using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsOperations
{
    public class FileOperationsPractice
    {
        public void Main()
        {
            var drives = DriveInfo.GetDrives();
            foreach(var drive in drives)
            {
                Console.WriteLine($"Drive Name : {drive.Name} , Free Space : {drive.AvailableFreeSpace}," +
                    $"total space : {drive.TotalFreeSpace}");
                var directories = Directory.GetDirectories(drive.Name);
                foreach(var dir in directories)
                {
                    Console.WriteLine(dir);
                    try
                    {
                        var files = Directory.GetFiles(dir);
                        Console.WriteLine("****************");
                        foreach(var file in files)
                        {
                            Console.WriteLine(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("no access");
                    }


                }
            }

        }

    }
}
