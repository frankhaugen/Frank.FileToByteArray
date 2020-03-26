using System;
using System.IO;
using System.Timers;

namespace Frank.FileToByteArray
{
    class Program
    {
        private static string _outputDirectory = "output";

        static void Main(string[] args)
        {
            Console.WriteLine("File to byte-array");

            Console.WriteLine("Path to file, (leave empty to convert all files in current directory):");
            var filepath = Console.ReadLine();


            Console.WriteLine("Starting");
            var timer = new Timer();
            timer.Start();

            if (!Directory.Exists(_outputDirectory))
            {
                Console.WriteLine("Creating output directory...");
                Directory.CreateDirectory(_outputDirectory);
            }

            if (string.IsNullOrWhiteSpace(filepath))
            {
                var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
                foreach (var file in files)
                {
                    Console.WriteLine($"Processing '{Path.GetFileName(file)}'");
                    var bytes = File.ReadAllBytes(file);
                    var byteString = Convert.ToBase64String(bytes);
                    var filename = Path.GetFileName(file) + ".txt";
                    Console.WriteLine($"Writing '{filename}' to the output directory...");
                    File.WriteAllText($"{_outputDirectory}/{filename}", byteString);
                }
            }

            if (File.Exists(filepath))
            {
                Console.WriteLine($"Processing '{Path.GetFileName(filepath)}'");
                var bytes = File.ReadAllBytes(filepath);
                var byteString = Convert.ToBase64String(bytes);
                var filename = Path.GetFileName(filepath) + ".txt";
                Console.WriteLine($"Writing '{filename}' to the output directory...");
                File.WriteAllText($"{_outputDirectory}/{filename}", byteString);
            }
            else
            {
                Console.WriteLine($"The file '{filepath}' does not exist!");
            }

            timer.Stop();
            Console.WriteLine("Application stopped after: " + timer.Interval);
            Console.WriteLine("Press enter to close application");
            Console.ReadLine();
        }
    }
}
