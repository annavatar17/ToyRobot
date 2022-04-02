using ToyRobot.Common.Enum;
using ToyRobot.Models;

namespace ToyRobot.Common.Interfaces
{
    public interface IPlaceService
    {
        (int X, int Y, FaceEnum Face, bool Valid) GetPlaceValidValues(string commandInput, Table table);
        bool TryPlace(string commandInput, ToyRobot toyRobot, Table table);
    }
}
