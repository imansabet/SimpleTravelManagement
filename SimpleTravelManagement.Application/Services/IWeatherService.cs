using SimpleTravelManagement.Application.DTO.External;
using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Destination localization);
}
