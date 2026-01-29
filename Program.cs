using System.IO;

namespace ascii_art_dotnet;

class Program
{
    static void Main(string[] args)
    {
        string banner = "standard";
        try 
        {
            IEnumerable<string> lines = File.ReadLines(@$"./BannerFiles/{banner}.txt");

            foreach (string line in lines) 
            {
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
