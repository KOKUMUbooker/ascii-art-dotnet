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
            // Get input from user
            Console.Write("Enter your string : ");
            var input = Console.ReadLine();
            
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
                if (i != 0 && (i+1) % 8 == 0) 
                {
                    curRune++;
                    if (curRune <= 126) bannerDict.Add(curRune, new List<string>());
                }
                i++;
            }

            // PrintBannerMap(bannerDict);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to read file {banner}.txt : ");
            Console.WriteLine(e.Message);
        }
    }


    public static void PrintBannerMap(Dictionary<char, List<string>> bannerDict) 
    {
        Console.WriteLine($"Dictionary count: {bannerDict.Count}");
        foreach (KeyValuePair<char, List<string>> dictPair in bannerDict) 
        {
            Console.WriteLine("key {0}",dictPair.Key);
            foreach (var layer in dictPair.Value)
            {
                Console.WriteLine(layer);
            }
        }
    }
}
