using NUnit.Framework;
using RandomPetLib;

namespace RandomPetTest
{
    public class Tests
    {
        PetGenerator petGenerator;

        [SetUp]
        public void Setup()
        {
            petGenerator = new PetGenerator(new string[]{ "cat", "dog" });
        }

        [Test]
        public void CanCreateRandomPetGenerator()
        {
            PetGenerator petGenerator = new PetGenerator(null);
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
            string myName = petGenerator.NextPet();
            int i = 0;
            int threshold = 100;
            while (myName.Equals(petGenerator.NextPet()) && i <= threshold)
                i++;
            Assert.Greater(threshold, i, @"Could not generate new name with {0} tries", threshold);

        }
    }
}