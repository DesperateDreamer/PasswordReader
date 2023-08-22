using System.Text.RegularExpressions;

namespace PasswordReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //use any name of file
            string fileName = "file.txt";

            Reader.ReadTheFile(fileName);
        }
    }
}