using System;
using ToyRobot.Common.Interfaces;
using ToyRobot.Models;

namespace ToyRobot
{
    public class Program
    {
        private static string _commandInput;

        private static ToyRobot _toyRobot = new ToyRobot();
        private static Table _table = new Table();
        private static IPlaceService _placeService = new PlaceService();

        public static void Main(string[] args)
        {
            bool hasBeenPlaced = false;
            do
            {
                while (!hasBeenPlaced)
                {
                    Console.WriteLine("Enter command: PLACE X,Y,F");

                    _commandInput = Console.ReadLine();

                    hasBeenPlaced = _placeService.TryPlace(_commandInput, _toyRobot, _table);
                }

                Console.WriteLine("Enter command: [MOVE|LEFT|RIGHT|REPORT|EXIT]");

                _commandInput = Console.ReadLine();

            } while (_toyRobot.Maneuver(_commandInput.Trim(), _table));
        }

    }
}
