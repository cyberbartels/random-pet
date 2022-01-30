using System;
using NUnit.Framework;
using RandomPet;

namespace RandomPetTest
{
    public class ConsoleTests
    {

        [SetUp]
        public virtual void Setup()
        {

        }

        [Test]
        public void ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => RandomPet.RandomPet.Main(null));
            Assert.Throws<ArgumentException>(() => RandomPet.RandomPet.Main(new string[2]));
            Assert.Throws<ArgumentException>(() => RandomPet.RandomPet.Main(new string[3]));
        }

        [Test]
        public void CanCreateRandomPet()
        {
            string[] args = new string[0];
            RandomPet.RandomPet.Main(args);
        }

        [Test]
        public void CanCreateRandomPetStartingWithGivenChar()
        {
            string[] args = new string[] { "s" };
            RandomPet.RandomPet.Main(args);
        }
    }
}