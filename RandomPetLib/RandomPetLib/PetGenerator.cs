using System;

namespace RandomPetLib
{
    public class PetGenerator
    {
        string[] petNames;
        Random rnd = new Random();
        public PetGenerator(string[] petNames)
        {
            this.petNames = petNames;
        }
        public string NextPet()
        {
            int index = rnd.Next(petNames.Length);
            return petNames[index];
        }
    }
}
