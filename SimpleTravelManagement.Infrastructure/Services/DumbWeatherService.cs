using SimpleTravelManagement.Application.DTO.External;
using SimpleTravelManagement.Application.Services;
using SimpleTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravelManagement.Infrastructure.Services;
internal sealed class DumbWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Destination destination)
        => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
}