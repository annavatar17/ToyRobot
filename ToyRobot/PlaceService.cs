using System;
using ToyRobot.Common.Enum;
using ToyRobot.Common.Constants;
using ToyRobot.Common.Interfaces;
using ToyRobot.Models;

namespace ToyRobot
{
    public class PlaceService: IPlaceService
    {
        public (int X, int Y, FaceEnum Face, bool Valid) GetPlaceValidValues(string commandInput, Table table)
        {
            if (!commandInput.Contains(Constants.PLACE))
            {
                return (X: -1, Y: -1, Face: FaceEnum.NORTH, Valid: false);
            }

            var removedPlace = commandInput.Remove(0, Constants.PLACE.Length);
            var values = removedPlace.Split(',');

            if (values.Length == 3)
            {
                var validX = int.TryParse(values[0], out int x);
                var validY = int.TryParse(values[1], out int y);
                var validFace = Enum.TryParse<FaceEnum>(values[2], out FaceEnum face);

                var validXY = x >= 0 && y >= 0 && table.Width >= x && table.Height >= y;

                return (X: x, Y: y, Face: face, Valid: validFace && validX && validY && validXY);
            }

            return (X: -1, Y: -1, Face: FaceEnum.NORTH, Valid: false);
        }

        public  bool TryPlace(string commandInput, ToyRobot toyRobot, Table table)
        {
            var place = GetPlaceValidValues(commandInput, table);
            toyRobot.TryPlace(place);
            
            return place.Valid;
        }
    }
}
