using System;
using System.Collections.Generic;
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

            Console.WriteLine($"\"petname={{petName}}\" >> $GITHUB_OUTPUT");
        }
    }
}
