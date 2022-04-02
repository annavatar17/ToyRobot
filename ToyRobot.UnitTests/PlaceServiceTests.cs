using NUnit.Framework;
using ToyRobot.Common.Interfaces;
using ToyRobot.Models;

namespace ToyRobot.UnitTests
{
    [TestFixture]
    public class PlaceServiceTests
    {
        private IPlaceService _placeService;
        private Table _table;

        [SetUp]
        public void Setup()
        {
            _placeService = new PlaceService();
            _table = new Table();
        }

        [Test]
        public void GetPlaceValidValues_GivenNoPLACEInCommand_ShouldReturnInvalid()
        {
            var command = "0,0,NORTH";
            var place = _placeService.GetPlaceValidValues(command,_table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenCommandWithMoreThan2Commas_ShouldReturnInvalid()
        {
            var command = "PLACE 0,0,NORTH,SOUTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenCommandWithInvalidX_ShouldReturnInvalid()
        {
            var command = "PLACE A,0,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenCommandWithInvalidY_ShouldReturnInvalid()
        {
            var command = "PLACE 0,A,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenCommandWithInvalidFace_ShouldReturnInvalid()
        {
            var command = "PLACE 0,0,NORTHERN";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenCommandWithNegativeX_ShouldReturnInvalid()
        {
            var command = "PLACE -1,0,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenCommandWithNegativeY_ShouldReturnInvalid()
        {
            var command = "PLACE 0,-1,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenXGreaterThanTableWidth_ShouldReturnInvalid()
        {
            var command = "PLACE 6,0,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenYGreaterThanTableHeight_ShouldReturnInvalid()
        {
            var command = "PLACE 0,6,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }

        [Test]
        public void GetPlaceValidValues_GivenValidPlaceCommand_ShouldReturnValid()
        {
            var command = "PLACE 0,0,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsTrue(place.Valid);
        }

        [Test]
        public void TryPlace_GivenValidPlaceCommand_ShouldReturnTrue()
        {
            var command = "PLACE 0,0,NORTH";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsTrue(place.Valid);
        }

        [Test]
        public void TryPlace_GivenInValidPlaceCommand_ShouldReturnFalse()
        {
            var command = "PLACE 0,0,NORTHERN";
            var place = _placeService.GetPlaceValidValues(command, _table);

            Assert.IsFalse(place.Valid);
        }
    }
}