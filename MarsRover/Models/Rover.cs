using MarsRover.Models.Enums;

namespace MarsRover.Models
{
    public class Rover
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Direction Direction { get; set; }

        public Rover(float xpos, float ypos, Direction direction)
        {
            X = xpos;
            Y = ypos;
            Direction = direction;
        }
    }
}
