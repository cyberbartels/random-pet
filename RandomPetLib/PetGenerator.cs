using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomPetLib
{
    public partial class PetGenerator
    {
        char separator = '\u002D';
        public char[] constrainedAlphabet = "abcdefghijklmnopqrstuvwy".ToCharArray();
        Random rnd = new Random();

        public string[] PetNames { get { return Array.ConvertAll(petNames, x => x.ToLower()); }  }

        public string[] Adjectives { get { return Array.ConvertAll(adjectives, x => x.ToLower()); } }

        public PetGenerator()
        {
        }

        public PetGenerator(string[] petNames)
        {
            this.petNames = petNames;
        }

        public string NextPet()
        {
            return NextPet(this.petNames, this.adjectives);
        }

        private string NextPet(string[] petNames, string[] adjectives)
        {
            if (petNames == null || adjectives == null)
                throw new ArgumentNullException();
            if (petNames.Length == 0 || adjectives.Length == 0)
                throw new ArgumentException();
            
            int petIndex = rnd.Next(petNames.Length);
            int adjIndex = rnd.Next(adjectives.Length);
            string petName = adjectives[adjIndex] + separator + petNames[petIndex];
            return petName.ToLower();
        }

        public string NextPet(char startChar)
        {
            if (!constrainedAlphabet.Contains(startChar))
                throw new ArgumentException("Char limited to " + constrainedAlphabet);
            
            string start = startChar.ToString().ToLower();
            
            string[] filteredNames = this.PetNames.Where(x => x.StartsWith(start)).ToArray();
            string[] filteredAdjectives = adjectives.Where(x => x.StartsWith(start)).ToArray();

            return NextPet(filteredNames, filteredAdjectives);
        }
    }
}
