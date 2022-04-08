using System;
using System.IO;

namespace Fast_Rename
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Fast Rename - Program by Vladyslav Diachenko";

            while (true)
            {
                RenameFilesMenu();

                Console.Clear();
                Console.WriteLine("(?) Press \"esc\" to exit, or any other key to continue.");
                Console.Write("> ");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    return;

                Console.Clear();
            }
        }

        private static void RenameFilesMenu()
        {
            string path = String.Empty;         // The path to the directory with the necessary files
            string currentPart = String.Empty;  // The part of the file name that needs to be renamed
            string newPart = String.Empty;      // The part of the filename that needs to be written in the filename

            Console.WriteLine("(i) Enter the path where you want to rename the files.");
            do
            {
                Console.Write("> ");
                path = Console.ReadLine();

                // Check if a directory exists
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("(!) The specified directory does not exist.");
                    Console.WriteLine("(i) Try again.");
                }
            }
            while (!Directory.Exists(path));

            Console.WriteLine("(i) Enter the part of the file name(s) you want to rename.");
            Console.Write("> ");
            currentPart = Console.ReadLine();

            Console.WriteLine("(i) Enter the new part of the file name(s).");
            Console.Write("> ");
            newPart = Console.ReadLine();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles("*" + currentPart + "*.*");

            // Check if the necessary files are found
            if (files.Length == 0)
            {
                Console.WriteLine("(i) Files with this part of the name were not found.");
                Console.WriteLine("(i) Press any key for exit...");
                Console.ReadKey();

                return;
            }

            Console.WriteLine("(i) Renaming in progress...");
            for (uint i = 0; i < files.Length; i++)
            {
                string newName = files[i].Name.Replace(currentPart, newPart);
                File.Move(files[i].FullName, $"{path}\\{newName}");
            }

            Console.WriteLine("(i) Renaming is complete.");
            Console.WriteLine("(i) Press any key for exit...");
            Console.ReadKey();
        }
    }
}
