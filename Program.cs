using System.IO;
using System.Collections.Generic;

namespace ascii_art_dotnet;

class Program
{
    static void Main(string[] args)
    {
        string banner = "standard";
        try 
        {
            Console.WriteLine("Args : ",args);
            
            // Reading files
            IEnumerable<string> lines = File.ReadLines(@$"./BannerFiles/{banner}.txt");

            int i = 0;
            char curRune = ' ';
            var bannerDict = new Dictionary<char,List<string>>();
            bannerDict.Add(' ',new List<string>());
            
            foreach (string line in lines) 
            {
                if (line.Length == 0) continue;

                bannerDict[curRune].Add(line);
                if (i != 0 && i % 8 == 0) 
                {
                    curRune++;
                    if (curRune <= 126) bannerDict.Add(curRune, new List<string>());
                }
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to read file {banner}.txt : ");
            Console.WriteLine(e.Message);
        }
    }
}
