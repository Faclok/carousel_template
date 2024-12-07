using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            args = args.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();

            if(args.Length == 0)
            {
                Console.WriteLine("Не увидел ваши картинки");
                return;
            }

            var isValidCount = false;
            do
            {
                Console.WriteLine($"Кол-во картинок равна: {args.Length}? (y/n)");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input == "n")
                    Environment.Exit(1513); // for phone last numbers

                if (input == "y")
                    isValidCount = true;
            }
            while (!isValidCount);

            var result = string.Empty;
            result += HTMLProperties.GetStyleOnCount(args.Length);
            result += HTMLProperties.GetBody(args.Select((s, i) => HTMLProperties.GetItemImage(s, i == 0)).ToArray());
            result += HTMLProperties.SCRIPT;

            File.WriteAllText("./script.txt", result);
        }
    }
}
