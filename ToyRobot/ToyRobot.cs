using System;
using ToyRobot.Models;
using ToyRobot.Common.Constants;
using ToyRobot.Common.Enum;
using ToyRobot.Common.Interfaces;

namespace ToyRobot
{
    public class ToyRobot
    {
        public Position Position { get; set; }
        public FaceEnum Face { get; set; }

        private static IPlaceService _placeService = new PlaceService();

        public ToyRobot()
        {
            Position = new Position(0, 0);
            Face = FaceEnum.NORTH;
        }

        public void Left()
        {
            switch (Face)
            {
                case FaceEnum.NORTH:
                    {
                        Face = FaceEnum.WEST;
                        break;
                    }
                case FaceEnum.SOUTH:
                    {
                        Face = FaceEnum.EAST;
                        break;
                    }
                case FaceEnum.EAST:
                    {
                        Face = FaceEnum.NORTH;
                        break;
                    }
                case FaceEnum.WEST:
                    {
                        Face = FaceEnum.SOUTH;
                        break;
                    }
            }
        }

        public void Right()
        {
            switch (Face)
            {
                case FaceEnum.NORTH:
                    {
                        Face = FaceEnum.EAST;
                        break;
                    }
                case FaceEnum.SOUTH:
                    {
                        Face = FaceEnum.WEST;
                        break;
                    }
                case FaceEnum.EAST:
                    {
                        Face = FaceEnum.SOUTH;
                        break;
                    }
                case FaceEnum.WEST:
                    {
                        Face = FaceEnum.NORTH;
                        break;
                    }
            }
        }

        public void Report()
        {
            Console.WriteLine($"Output: {Position.X},{Position.Y},{Face.ToString()}");
        }

        public void Move(Table table)
        {
            switch (Face)
            {
                case FaceEnum.NORTH:
                    {
                        if (table.Height > Position.Y)
                        {
                            Position.Y++;
                        }

                        break;
                    }
                case FaceEnum.EAST:
                    {
                        if (table.Width > Position.X)
                        {
                            Position.X++;
                        }

                        break;
                    }
                case FaceEnum.SOUTH:
                    {
                        if (Position.Y > 0)
                        {
                            Position.Y--;
                        }

                        break;
                    }
                case FaceEnum.WEST:
                    {
                        if (Position.X > 0)
                        {
                            Position.X--;
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void TryPlace((int X, int Y, FaceEnum face, bool Valid) place)
        {
            if (place.Valid)
            {
                Position = new Position(place.X, place.Y);
                Face = place.face;
            }
        }

        public bool Maneuver(string commandInput, Table table)
        {
            bool maneuver = true;

            switch (commandInput)
            {

                case Constants.MOVE:
                    {
                        Move(table);
                        break;
                    }
                case Constants.LEFT:
                    {
                        Left();
                        break;
                    }
                case Constants.RIGHT:
                    {
                        Right();
                        break;
                    }
                case Constants.REPORT:
                    {
                        Report();
                        break;
                    }
                case Constants.EXIT:
                    {
                        maneuver = false;
                        break;
                    }
                default:
                    {
                        _placeService.TryPlace(commandInput, this, table);
                        break;
                    }
            }

            return maneuver;
        }
        
    }
}
