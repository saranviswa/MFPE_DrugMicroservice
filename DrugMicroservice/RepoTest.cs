using DrugsMicroservice.Repository;
using NUnit.Framework;

namespace DrugMicroservice.UnitTest
{
    [TestFixture]
    public class Tests
    {
        DrugRepository drugRepository;
        [SetUp]
        public void Setup()
        {
            drugRepository = new DrugRepository();
        }

        [TestCase(1001)]
        [TestCase(1002)]
        public void GetDrugsById_IfTheIdExists_ReturnsTheObject(int id)
        {
            var result = drugRepository.GetDrugById(id);
            Assert.That(result, Is.Not.Null);
        }

        [TestCase(9000)]
        public void GetDrugsByIdTest_IfTheIdDoesNotExist_ReturnsNull(int id)
        {
            var result = drugRepository.GetDrugById(id);
            Assert.That(result, Is.Null);
        }

        [TestCase("Crocin")]
        [TestCase("Paracetamol")]
        public void GetDrugsByName_IfTheNameExists_ReturnsTheObject(string name)
        {
            var result = drugRepository.GetDrugByName(name);
            Assert.That(result, Is.Not.Null);
        }

        [TestCase("Aspirin")]
        public void GetDrugsByName_IfTheNameDoesNotExists_ReturnsNull(string name)
        {
            var result = drugRepository.GetDrugByName(name);
            Assert.That(result, Is.Null);
        }

        [TestCase(1001, "Chennai")]
        public void GetDrugByLocation_IfTheIdAndLocationIsValid_ReturnObject(int id, string location)
        {
            var result = drugRepository.GetDrugByLocation(id, location);
            Assert.That(result, Is.Not.Null);
        }

        [TestCase(1001, "Asia")]
        public void GetDrugByLocation_IfTheIdAndLocationIsNotValid_ReturnsNull(int id, string location)
        {
            var result = drugRepository.GetDrugByLocation(id, location);
            Assert.That(result, Is.Null);
        }
    }
}