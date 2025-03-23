using NSubstitute;
using Shouldly;
using SimpleTravelManagement.Application.Commands;
using SimpleTravelManagement.Application.DTO.External;
using SimpleTravelManagement.Application.Exceptions;
using SimpleTravelManagement.Application.Services;
using SimpleTravelManagement.Domain.Consts;
using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.Factories;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Domain.ValueObjects;
using SimpleTravelManagement.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravelManagement.UnitTests.Application;
public class CreateTravelerCheckListWithItemsHandlerTests
{
    Task Act(CreateTravelerCheckListWithItems command)
        => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_TravelerCheckListAlreadyExistsException_When_List_With_same_Name_Already_Exists()
    {
        var command = new CreateTravelerCheckListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, default);
        _readService.ExistsByNameAsync(command.Name).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<TravelerCheckListAlreadyExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Throws_MissingDestinationWeatherException_When_Weather_Is_Not_Returned_From_Service()
    {
        var command = new CreateTravelerCheckListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
            new DestinationWriteModel("ESF", "Iran"));

        _readService.ExistsByNameAsync(command.Name).Returns(false);
        _weatherService.GetWeatherAsync(Arg.Any<Destination>()).Returns(default(WeatherDto));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MissingDestinationWeatherException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_On_Success()
    {
        var command = new CreateTravelerCheckListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
            new DestinationWriteModel("ESF", "Iran"));

        _readService.ExistsByNameAsync(command.Name).Returns(false);
        _weatherService.GetWeatherAsync(Arg.Any<Destination>()).Returns(new WeatherDto(12));
        _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender,
            Arg.Any<Temperature>(), Arg.Any<Destination>()).Returns(default(TravelerCheckList));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldBeNull();
        await _repository.Received(1).AddAsync(Arg.Any<TravelerCheckList>());
    }

    #region ARRANGE

    private readonly ICommandHandler<CreateTravelerCheckListWithItems> _commandHandler;
    private readonly ITravelerCheckListRepository _repository;
    private readonly IWeatherService _weatherService;
    private readonly ITravelerCheckListReadService _readService;
    private readonly ITravelerCheckListFactory _factory;

    public CreateTravelerCheckListWithItemsHandlerTests()
    {
        _repository = Substitute.For<ITravelerCheckListRepository>();
        _weatherService = Substitute.For<IWeatherService>();
        _readService = Substitute.For<ITravelerCheckListReadService>();
        _factory = Substitute.For<ITravelerCheckListFactory>();
        _commandHandler = new CreateTravelerCheckListWithItemsHandler(_repository, _factory, _weatherService, _readService);
    }

    #endregion
}