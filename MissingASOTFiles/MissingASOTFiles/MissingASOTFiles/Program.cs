using System;
using System.Collections.Generic;
using System.IO;

namespace MissingASOTFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileEntries = Directory.GetFiles(@"X:\ASOT");
            int lastEpisodeNumber = 0;

            var asotNumber = "";
            bool lastFounded = false;
            List<string> unavailableEpisodes = new List<string>();

            Console.WriteLine("=============================");
            Console.WriteLine("== find ASOT missing files ==");
            Console.WriteLine("=============================\n");

            while (lastEpisodeNumber == 0)
            {
                Console.Write("Enter last episode number: ");
                string lastEpisodeNumberString = Console.ReadLine();
                int.TryParse(lastEpisodeNumberString, out lastEpisodeNumber);

                if (lastEpisodeNumber == 0)
                {
                    Console.WriteLine("The number is incorrect.");
                }
            }

            for (int i = 0; i < lastEpisodeNumber; i++)
            {
                lastFounded = false;
                asotNumber = i.ToString("D3");

                foreach (string fileName in fileEntries)
                {
                    if (fileName.Contains(asotNumber))
                    {
                        lastFounded = true;
                        break;
                    }
                }

                if (!lastFounded)
                {
                    unavailableEpisodes.Add(asotNumber);
                }
            }

            unavailableEpisodes.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
