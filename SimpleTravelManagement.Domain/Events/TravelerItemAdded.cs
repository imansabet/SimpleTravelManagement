using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.ValueObjects;
using SimpleTravelManagement.Shared.Abstractions.Domain;

namespace SimpleTravelManagement.Domain.Events;

public record TravelerItemAdded(TravelerCheckList TravelerCheckList,TravelerItem TravelerItem):IDomainEvent;
