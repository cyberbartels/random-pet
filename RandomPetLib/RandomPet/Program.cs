using System;
using RandomPetLib;

namespace RandomPet
{
    public class RandomPet
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length > 1)
                throw new ArgumentException();
            PetGenerator p = new PetGenerator();
            string petName = p.NextPet();
            Console.WriteLine($"::set-output name=petname::{petName}");
           // Console.ReadKey();
        }
    }
}
