using MarsRover.DTOs;
using MarsRover.Models;
using MarsRover.Models.Enums;
using MarsRover.Services.Abstractions;
using System.Security.Cryptography;

namespace MarsRover.Service
{
    public class RoverService : IRoverService
    {
        private readonly Rover _rover;
        private float maxX = 10f;
        private float maxY = 10f;

        public RoverService(Rover rover)
        {
            _rover = rover;
        }
        public Rover GetRover() => _rover;

        public string Move(RoverMovementRequestDTO command)
        {
            if (command == null || command?.Commands == null)
                return "Comando non riconosciuto";

            foreach (var cmd in command.Commands)
            {
                switch (cmd.ToString().ToLower())
                {
                    case ("f"):
                        MoveFB(_rover.Direction, true);
                        break;
                    case ("b"):
                        MoveFB(_rover.Direction, false);
                        break;
                    case ("l"):
                        MoveLR(_rover.Direction, true);
                        break;
                    case ("r"):
                        MoveLR(_rover.Direction, false);
                        break;
                    default:
                        break;
                }
            }

            return $"Rover spostato in posizione {_rover.X}x, {_rover.Y}y ; \n Direzione : {_rover.Direction}";

        }

        private void MoveFB(Direction direction, bool forward = true)
        {
            var speed = 1 * (forward ? 1 : -1);
                switch (direction)
                {
                    case (Direction.North):
                        _rover.Y += speed;
                        break;
                    case (Direction.South):
                        _rover.Y -= speed;
                        break;
                    case (Direction.East):
                        _rover.X += speed;
                        break;
                    case (Direction.West):
                        _rover.X -= speed;
                        break;
                    default:
                        break;
                }
            _rover.X = Wrapping(_rover.X, maxX);
            _rover.Y = Wrapping(_rover.Y, maxY);
        }

        private void MoveLR(Direction direction, bool turnLeft = true)
        {
            var directionMap = new Dictionary<(Direction, bool), Direction>
            {
                { (Direction.North, true), Direction.West },
                { (Direction.North, false), Direction.East },
                { (Direction.South, true), Direction.East },
                { (Direction.South, false), Direction.West },
                { (Direction.East, true), Direction.North },
                { (Direction.East, false), Direction.South },
                { (Direction.West, true), Direction.South },
                { (Direction.West, false), Direction.North }
            };

            _rover.Direction = directionMap[(direction, turnLeft)];
        }

        private float Wrapping(float roverCoordinates, float edge)
        {
            if (roverCoordinates > edge)
            {
                roverCoordinates = -edge;
            }
            else if (roverCoordinates < -edge)
            {
                roverCoordinates = edge;
            }
            return roverCoordinates;
        }

        private void ObstacleDetection() { 
        }
    }
}
