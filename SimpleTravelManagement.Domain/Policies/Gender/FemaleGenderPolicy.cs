using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies.Gender;

internal sealed class FemaleGenderPolicy : ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Gender is Consts.Gender.Female;


    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Lipstick",1),
            new("Creame Powder",1),
            new("EyeLiner",1)
        };


}
