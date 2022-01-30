using System;
using System.Linq;
using NUnit.Framework;
using RandomPetLib;

namespace RandomPetLibTest
{
    public class DefaultListTests
    {
        protected PetGenerator petGenerator;

        [SetUp]
        public virtual void Setup()
        {
            petGenerator = new PetGenerator();
        }

        [Test]
        public void CanCreateRandomPetGenerator()
        {
            PetGenerator petGenerator = new PetGenerator();
        }

        [Test]
        public void CanCreateRandomPet()
        {
            string myPet = petGenerator.NextPet();
            Assert.IsNotNull(myPet);
            Assert.IsNotEmpty(myPet);
        }

        [Test]
        public void SuccessiveNameGenerationYieldsDifferentResults()
        {
            string myPet = petGenerator.NextPet();
            int i = 0;
            int threshold = 100;
            while (myPet.Equals(petGenerator.NextPet()) && i <= threshold)
                i++;
            Assert.Greater(threshold, i, @"Could not generate new name with {0} tries", threshold);
        }

        [Test]
        public void CanbeSplitBySeparator()
        {
            string myPet = petGenerator.NextPet();
            Assert.AreEqual(2, myPet.Split('-').Length);
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('c')]
        [TestCase('f')]
        [TestCase('j')]
        [TestCase('o')]
        [TestCase('q')]
        [TestCase('y')]
        public void CanGetAlliteration(char startChar)
        {       
            string myPet = petGenerator.NextPet(startChar);
            
            Assert.IsNotNull(myPet);
            Assert.IsNotEmpty(myPet);
            Assert.IsTrue(myPet.StartsWith(startChar));
        }

        [TestCase('x')]
        public void XAsStartCharThrowsArgumentException(char startChar)
        {
            Assert.Throws<ArgumentException>(() => petGenerator.NextPet(startChar));
        }

        [TestCase('z')]
        public void ZAsStartCharThrowsArgumentException(char startChar)
        {
            Assert.Throws<ArgumentException>(() => petGenerator.NextPet(startChar));
        }

        [Test]
        public void PetNameContainsPetFromList()
        {
            string myPet = petGenerator.NextPet();
            Assert.Contains(myPet.Split('-')[1], petGenerator.PetNames);
        }

        [Test]
        public void PetNameContainsAdjectiveFromList()
        {
            string myPet = petGenerator.NextPet();
            Assert.Contains(myPet.Split('-')[0], petGenerator.Adjectives);
        }
    }

    public class ShortListTests : DefaultListTests
    {
        protected string[] petList = new string[] { "Ape", "bear", "cat", "dOg", "frog", "Jaguar", "Opossum", "Quail", "Yak" };
        [SetUp]
        public override void Setup()
        {
            petGenerator = new PetGenerator(petList);
        }
    }
}