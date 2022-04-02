using System;
using System.IO;
using NUnit.Framework;
using ToyRobot.Models;

namespace ToyRobot.IntegrationTests
{
    [TestFixture]
    public class ToyRobotIntegrationTests
    {
        private ToyRobot _toyRobot;
        private Table _table;
        StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _toyRobot = new ToyRobot();
            _table = new Table();
            _stringWriter = new StringWriter();
        }

        [Test]
        public void Move_GivenPlaceX0Y0North_ShouldReportX0Y1NORTH()
        {
            var command = "PLACE 0,0,NORTH";
            _toyRobot.Maneuver(command, _table);
            _toyRobot.Move(_table);
            
            Console.SetOut(_stringWriter);

            _toyRobot.Report();

            Assert.AreEqual(_stringWriter.ToString(), "Output: 0,1,NORTH\n");
        }

        [Test]
        public void LEFT_GivenPlaceX0Y0North_ShouldReportX0Y0WEST()
        {
            var command = "PLACE 0,0,NORTH";
            _toyRobot.Maneuver(command, _table);
            _toyRobot.Left();

            Console.SetOut(_stringWriter);

            _toyRobot.Report();

            Assert.AreEqual(_stringWriter.ToString(), "Output: 0,0,WEST\n");
        }

        [Test]
        public void MOVES_GivenPlaceX1Y2EAST_ShouldReportX3Y3NORTH()
        {
            var command = "PLACE 1,2,EAST";
            _toyRobot.Maneuver(command, _table);
            _toyRobot.Move(_table);
            _toyRobot.Move(_table);
            _toyRobot.Left();
            _toyRobot.Move(_table);

            Console.SetOut(_stringWriter);

            _toyRobot.Report();

            Assert.AreEqual(_stringWriter.ToString(), "Output: 3,3,NORTH\n");
        }
    }
}
