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
            if (input == null) 
            {
                return;
            }
            
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

            // Split strings into separate items based on newline
            var splitStr = SplitStringByNewLine(input);
            foreach (var str in splitStr)
            {
                if (str == "\n")
                {
                    Console.WriteLine();
                }
                else 
                {
                    PrintLineAscii(input,bannerDict);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to read file {banner}.txt : ");
            Console.WriteLine(e.Message);
        }
    }

    public static List<string> SplitStringByNewLine(string input) 
    {
        var charArr = input.ToCharArray();
        var res = new List<string>();

        int cLen = charArr.Length;
        int i = 0;
        int end = 0;
        while ( i < cLen )
        {
            if (charArr[i] == '\n') 
            {
                res.Add(charArr[i].ToString());
                i++;
                end++;
                continue;
            }

            // Console.WriteLine($"Hello i : {i}, end : {end}, cLen : {cLen}");
            while (charArr[end] != '\n') 
            {
                end++;
                if (end == cLen) 
                {
                    break;
                }
            }
            var group = charArr[i..end];
            res.Add(group.ToString());
            i = end;
        }

        return res;
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

    public static void PrintLineAscii(string input, Dictionary<char, List<string>> bannerDict) 
    {
        for (int i = 0; i < 8; i++) 
        {
            foreach (char charVal in input) 
            {
                List<string> group = bannerDict.GetValueOrDefault(charVal);
                if (group != null) Console.Write(group[i]);
            } 

            Console.WriteLine();
        }
    }
}
