using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using RandomPetLib;

namespace RandomPet
{
    public class RandomPet
    {
        public static void Main(string[] args)
        {
            string startLetter = null;
            PetGenerator p = new PetGenerator();

            if (args == null || args.Length > 1)
                throw new ArgumentException();
            else if (args.Length > 0)
                startLetter = args[0];

            string petName = null;
            if (string.IsNullOrEmpty(startLetter))
            {
                petName = p.NextPet();
            }
            else
            {
                petName = p.NextPet(startLetter.ToCharArray()[0]);
            }

            //Log result
            Console.WriteLine($"petname={petName}"); 
            
            //Create action output
            var gitHubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
            if (!string.IsNullOrWhiteSpace(gitHubOutputFile))
            {
                using StreamWriter textWriter = new(gitHubOutputFile, true, Encoding.UTF8);
                textWriter.WriteLine($"petname={petName}");
            }

        }
    }
}
