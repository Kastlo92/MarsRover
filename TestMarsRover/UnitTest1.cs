using MarsRover.DTOs;
using MarsRover.Models;
using MarsRover.Models.Enums;
using MarsRover.Service;

namespace TestMarsRover
{
    [TestClass]
    public class UnitTest1
    {
        private Rover _rover;
        private RoverService _roverService;
        private const float maxX = 10f;
        private const float maxY = 10f;

        [TestInitialize]
        public void Setup()
        {
            _rover = new Rover(0f, 0f, Direction.North);
            _roverService = new RoverService(_rover);
        }

        [TestMethod]
        public void MoveFBTest()
        {
            var request = new RoverMovementRequestDTO()
            {
                Commands = new char[]
                {
                    'f'
                }
            };

            var result = _roverService.Move(request);
        }

        [TestMethod]
        public void MoveLRTest()
        {
            var request = new RoverMovementRequestDTO
            {
                Commands = new char[] { 'l' }
            };

            var result = _roverService.Move(request);
        }

        [TestMethod]
        public void ObstacleDetectionTest()
        {
            var request = new RoverMovementRequestDTO
            {
                Commands = new char[] { 'f', 'f'}
            };

            var result = _roverService.Move(request);
        }

    }
}
