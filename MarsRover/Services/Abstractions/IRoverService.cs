using MarsRover.DTOs;

namespace MarsRover.Services.Abstractions
{
    public interface IRoverService
    {
        string Move(RoverMovementRequestDTO command);
    }
}
