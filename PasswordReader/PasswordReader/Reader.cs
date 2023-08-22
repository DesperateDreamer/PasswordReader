using System.Text.RegularExpressions;

namespace PasswordReader
{
    public class Reader
    {
        public static void ReadTheFile(string fileName)
        {
            try
            {
                using StreamReader streamReader = new(fileName);
                string? line;
                int count = 0;

                while ((line = streamReader.ReadLine()) != null)
                {
                    Regex regex = new(@"^([a-zA-Z]) ([\d]+)-([\d]+): ([a-zA-Z]+)$");
                    Match match = regex.Match(line);

                    if (!match.Success)
                    {
                        Console.WriteLine($"Invalid line: {line}");
                        continue;
                    }

                    string symbol = match.Groups[1].Value;
                    int minFrequency = int.Parse(match.Groups[2].Value);
                    int maxFrequency = int.Parse(match.Groups[3].Value);
                    string password = match.Groups[4].Value;

                    if (maxFrequency <= minFrequency)
                    {
                        Console.WriteLine($"Invalid line: {line}");
                        continue;
                    }

                    var countOfSymbol = Regex.Matches(password, symbol).Count;

                    if (countOfSymbol >= minFrequency && countOfSymbol <= maxFrequency)
                        count++;
                }

                Console.WriteLine($"Number of valid passwords: {count}");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while opening a file");
            }
        }
    }
}
