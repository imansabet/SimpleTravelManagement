using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies;

public record PolicyData
    (
        TravelDays Days ,
        Consts.Gender Gender,
        ValueObjects.Temperature Temperature,
        Destination Destination
    );
