using DrugsMicroservice.Controllers;
using DrugsMicroservice.Models;
using DrugsMicroservice.Repository;
using Moq;
using NUnit.Framework;

namespace DrugMicroservice.UnitTest
{
    [TestFixture]
    public class ControllerTest
    {
        Mock<IRepository> _repository;
        DrugController drugController;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IRepository>();
            drugController = new DrugController(_repository.Object);
        }

        [TestCase(1001)]
        public void GetDrugById_WhenTheIdPassedIsValid_ReturnsObject(int id)
        {
            _repository.Setup(x => x.GetDrugById(id)).Returns(new DrugList());
            var res = _repository.Object.GetDrugById(id);
            Assert.That(res, Is.Not.Null);
        }

        [TestCase(9000)]
        public void GetDrugById_WhenTheIdPassesIsNotValid_ReturnsNull(int id)
        {
            var res = _repository.Object.GetDrugById(id);

            Assert.That(res, Is.Null);
        }

        [TestCase("Crocin")]
        public void GetDrugByName_WhenTheNameIsValid_ReturnsObject(string name)
        {
            _repository.Setup(x => x.GetDrugByName(name)).Returns(new DrugList());
            var res = _repository.Object.GetDrugByName(name);
            Assert.That(res, Is.Not.Null);
        }

        [TestCase("Aspirin")]
        public void GetDrugByName_WhenTheNameIsNotValid_ReturnsNull(string name)
        {
            var res = _repository.Object.GetDrugByName(name);
            Assert.That(res, Is.Null);
        }

        [TestCase(1001, "Chennai")]
        public void GetDrugByLocation_WhenTheIdAndLocationAreValid_ReturnsObject(int id, string location)
        {
            _repository.Setup(x => x.GetDrugByLocation(id, location)).Returns(new DrugLocationWise());
            var res = _repository.Object.GetDrugByLocation(id, location);
            Assert.That(res, Is.Not.Null);
        }

        [TestCase(9000, "Asia")]
        public void GetDrugByLocation_WhenTheIdAndLocationAreNotValid_ReturnsNull(int id, string location)
        {
            var res = _repository.Object.GetDrugByLocation(id, location);
            Assert.That(res, Is.Null);
        }


    }
}
