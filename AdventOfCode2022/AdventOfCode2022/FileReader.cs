using System;
using System.IO;

namespace AdventOfCode2022
{
    internal static class FileReader
    {
        public static string Read(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new FormatException("path must be provided");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The provided {path} was not found");
            }
            
            using (StreamReader reader = new StreamReader(path))
            {
                string input = reader.ReadToEnd();
                if (String.IsNullOrEmpty(input))
                {
                    throw new Exception("read input file is empty");
                }
                return input;
            }
        } 
    }
}
