using SimpleTravelManagement.Domain.Exceptions;
using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Domain.ValueObjects;

public record TravelerCheckListName
{
    public string Value { get; }
    public TravelerCheckListName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new TravelerCheckListNameException();
        }
        Value = value.Trim();
    }

    public static implicit operator string(TravelerCheckListName name) => name.Value;


    public static implicit operator TravelerCheckListName(string name) => new(name);
}
