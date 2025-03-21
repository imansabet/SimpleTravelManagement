using SimpleTravelManagement.Domain.ValueObjects;
using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Application.Exceptions;

public class MissingDestinationWeatherException : TravelerCheckListException
{
    public Destination Destination { get; }
    public MissingDestinationWeatherException(Destination destination) 
        : base($"Couldn't fetch weather data for destination `{destination.Country}/{destination.City}` . ")
    {
        Destination = destination;
    }
}
