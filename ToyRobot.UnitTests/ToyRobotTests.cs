using System;
using System.IO;
using NUnit.Framework;
using ToyRobot.Common.Constants;
using ToyRobot.Common.Enum;
using ToyRobot.Models;

namespace ToyRobot.UnitTests
{
    [TestFixture]
    public class ToyRobotTests
    {
        private ToyRobot _toyRobot;
        private Table _table;

        [SetUp]
        public void Setup()
        {
            _toyRobot = new ToyRobot();
            _table = new Table();
        }

        [Test]
        public void Left_GivenFacingNORTH_ShouldSetFaceToWEST()
        {
            _toyRobot.Face = FaceEnum.NORTH;
            _toyRobot.Left();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.WEST);
        }

        [Test]
        public void Left_GivenFacingSOUTH_ShouldSetFaceToEAST()
        {
            _toyRobot.Face = FaceEnum.SOUTH;
            _toyRobot.Left();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.EAST);
        }

        [Test]
        public void Left_GivenFacingEAST_ShouldSetFaceToNORTH()
        {
            _toyRobot.Face = FaceEnum.EAST;
            _toyRobot.Left();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.NORTH);
        }

        [Test]
        public void Left_GivenFacingWEST_ShouldSetFaceToSOUTH()
        {
            _toyRobot.Face = FaceEnum.WEST;
            _toyRobot.Left();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.SOUTH);
        }

        [Test]
        public void Right_GivenFacingNORTH_ShouldSetFaceToEAST()
        {
            _toyRobot.Face = FaceEnum.NORTH;
            _toyRobot.Right();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.EAST);
        }

        [Test]
        public void Right_GivenFacingSOUTH_ShouldSetFaceToWEST()
        {
            _toyRobot.Face = FaceEnum.SOUTH;
            _toyRobot.Right();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.WEST);
        }

        [Test]
        public void Right_GivenFacingEAST_ShouldSetFaceToSOUTH()
        {
            _toyRobot.Face = FaceEnum.EAST;
            _toyRobot.Right();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.SOUTH);
        }

        [Test]
        public void Right_GivenFacingWEST_ShouldSetFaceToNORTH()
        {
            _toyRobot.Face = FaceEnum.WEST;
            _toyRobot.Right();

            Assert.AreEqual(_toyRobot.Face, FaceEnum.NORTH);
        }

        [Test]
        public void Report_GivenXYFacingDirection_ShouldPrintSimilarXYDirection()
        {
            _toyRobot.Position.X = 1;
            _toyRobot.Position.Y = 1;
            _toyRobot.Face = FaceEnum.NORTH;

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _toyRobot.Report();

            Assert.AreEqual(stringWriter.ToString(), $"Output: 1,1,NORTH\n"); 
        }

        [Test]
        public void Move_GivenTableHeightGreaterThanYFacingNORTH_ShouldIncrementY()
        {
            _table.Height = 5;
            _toyRobot.Position.Y = 1;
            _toyRobot.Face = FaceEnum.NORTH;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.Y, 2);
        }

        [Test]
        public void Move_GivenYNotLessThanTableHeightFacingNORTH_ShouldReturnSimilarY()
        {
            _table.Height = 5;
            _toyRobot.Position.Y = 5;
            _toyRobot.Face = FaceEnum.NORTH;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.Y, 5);
        }


        [Test]
        public void Move_GivenTableWidthGreaterThanXFacingEAST_ShouldIncrementX()
        {
            _table.Width = 5;
            _toyRobot.Position.X = 1;
            _toyRobot.Face = FaceEnum.EAST;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.X, 2);
        }

        [Test]
        public void Move_GivenXNotLessThanTableWidthFacingEAST_ShouldReturnSimilarX()
        {
            _table.Width = 5;
            _toyRobot.Position.X = 5;
            _toyRobot.Face = FaceEnum.EAST;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.X, 5);
        }

        [Test]
        public void Move_GivenYGreaterThan0FacingSOUTH_ShouldDecrementY()
        {
            _toyRobot.Position.Y = 1;
            _toyRobot.Face = FaceEnum.SOUTH;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.Y, 0);
        }

        [Test]
        public void Move_GivenYNotGreaterThan0FacingSOUTH_ShoulReturnSimilarY()
        {
            _toyRobot.Position.Y = 0;
            _toyRobot.Face = FaceEnum.SOUTH;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.Y, 0);
        }

        [Test]
        public void Move_GivenXGreaterThan0FacingWEST_ShouldDecrementX()
        {
            _toyRobot.Position.X = 1;
            _toyRobot.Face = FaceEnum.WEST;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.X, 0);
        }

        [Test]
        public void Move_GivenXNotGreaterThan0FacingWEST_ShouldReturnSimilarX()
        {
            _toyRobot.Position.X = 0;
            _toyRobot.Face = FaceEnum.WEST;
            _toyRobot.Move(_table);

            Assert.AreEqual(_toyRobot.Position.X, 0);
        }

        [Test]
        public void TryPlace_GivenValidPlace_ShouldSetPositionAndFace()
        {
            var place = (X: 1, Y: 1, Face: FaceEnum.NORTH, Valid: true);
            _toyRobot.TryPlace(place);

            Assert.AreEqual(_toyRobot.Position.X, 1);
            Assert.AreEqual(_toyRobot.Position.Y, 1);
            Assert.AreEqual(_toyRobot.Face, FaceEnum.NORTH);
        }

        [Test]
        public void TryPlace_GivenInValidPlace_ShouldNotSetPositionAndFace()
        { 
            var place = (X: -1, Y: -1, Face: FaceEnum.SOUTH, Valid: false);
            _toyRobot.TryPlace(place);

            Assert.AreNotEqual(_toyRobot.Position.X, -1);
            Assert.AreNotEqual(_toyRobot.Position.Y, -1);
            Assert.AreNotEqual(_toyRobot.Face, FaceEnum.SOUTH);
        }

        [Test]
        public void Maneuver_GivenMOVECommand_ShouldReturnTrue()
        {
            var command = Constants.MOVE;
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsTrue(maneuver);
        }

        [Test]
        public void Maneuver_GivenLEFTCommand_ShouldReturnTrue()
        {
            var command = Constants.LEFT;
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsTrue(maneuver);
        }

        [Test]
        public void Maneuver_GivenRIGHTCommand_ShouldReturnTrue()
        {
            var command = Constants.RIGHT;
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsTrue(maneuver);
        }

        [Test]
        public void Maneuver_GivenREPORTCommand_ShouldReturnTrue()
        {
            var command = Constants.REPORT;
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsTrue(maneuver);
        }

        [Test]
        public void Maneuver_GivenPlaceCommand_ShouldReturnTrue()
        {
            var command = "PLACE 0,0,NORTH";
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsTrue(maneuver);
        }

        [Test]
        public void Maneuver_GivenEXITCommand_ShouldReturnFalse()
        {
            var command = Constants.EXIT;
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsFalse(maneuver);
        }

        [Test]
        public void Maneuver_GivenNotExitCommand_ShouldReturnTrue()
        {
            var command = "NOT EXIT";
            var maneuver = _toyRobot.Maneuver(command, _table);

            Assert.IsTrue(maneuver);
        }
    }
}
