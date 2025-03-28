﻿using SimpleTravelManagement.Application.Exceptions;
using SimpleTravelManagement.Application.Services;
using SimpleTravelManagement.Domain.Factories;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Domain.ValueObjects;
using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands.Handlers;

internal sealed class CreateTravelerCheckListWithItemsHandler : ICommandHandler<CreateTravelerCheckListWithItems>
{
    private readonly ITravelerCheckListRepository _repository;
    private readonly ITravelerCheckListFactory _factory;
    private readonly ITravelerCheckListReadService _readService;
    private readonly IWeatherService _weatherService;

    public CreateTravelerCheckListWithItemsHandler
        (ITravelerCheckListRepository repository
        , ITravelerCheckListFactory factory 
        ,ITravelerCheckListReadService readService
        , IWeatherService weatherService)
    {
        _repository = repository;
       _factory = factory;
        _readService = readService;
        _weatherService = weatherService;
    }
    public async Task HandleAsync(CreateTravelerCheckListWithItems command)
    {
         var (id , name , days , gender , DestinationWriteModel) = command;

        if(await _readService.ExistsByNameAsync(name)) 
        {
            throw new TravelerCheckListAlreadyExistsException(name);
        }

        var destination = new Destination(DestinationWriteModel.City, DestinationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(destination);

        if (weather is null) 
        {
            throw new MissingDestinationWeatherException(destination);
        }
        var TravelerCheckList = _factory.CreateWithDefaultItems(id,name,days,gender,weather.Temperature,destination);

        await _repository.AddAsync(TravelerCheckList);

    }
}
