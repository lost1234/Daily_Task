using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace DirectoryStatistic
{
    public class FileHandling
    {

        public void PrintFileList(string filepath, string pattern)
        {
            foreach (string files in Directory.EnumerateFiles(filepath, pattern, SearchOption.AllDirectories))
            {
                Console.WriteLine(files);
            }
        }

        public int FileCount(string filepath, string pattern)
        {
            int count = 0;
            foreach (string files in Directory.EnumerateFiles(filepath, pattern, SearchOption.AllDirectories))
            {
                count += 1;
            }
            return count;
        }

        public long FileSize(string filepath, string pattern)
        {
            long size = 0;
            DirectoryInfo directory = new DirectoryInfo(filepath);
            FileInfo[] files = directory.GetFiles(pattern, SearchOption.AllDirectories);
            foreach (FileInfo dire in files)
            {
                size += dire.Length;
            }
            return size;
        }

        public double Convert(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        /* 
       public void LoadArgs(string[] args)
       {
           Dictionary<string, string> di = new Dictionary<string, string>();
           for(int i = 0;i < args.Length - 1;i++)
           {

           }

       }
        */
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.Write("Please enter the filepath: ");
            string filepath = Console.ReadLine();
            Console.Write("Please enter the target pattern: ");
            string pattern = Console.ReadLine();
            FileHandling fi = new FileHandling();
            Console.WriteLine("File name pattern: " + pattern);
            Console.WriteLine("File count: " + fi.FileCount(filepath, pattern));
            Console.WriteLine("File list: ");
            fi.PrintFileList(filepath, pattern);
            long size = fi.FileSize(filepath, pattern);
            double msize = fi.Convert(size);
            Console.WriteLine("Total size: {0} MB ({1} bytes) ", msize, size);

            watch.Stop();
            var mSeconds = watch.ElapsedMilliseconds;

            Console.WriteLine("Time cost: {0}ms", mSeconds);

            Console.ReadKey();
        }
    }
}
