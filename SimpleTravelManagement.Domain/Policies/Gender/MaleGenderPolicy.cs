using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies.Gender;

internal sealed class MaleGenderPolicy : ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Gender is Consts.Gender.Male;
    

    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
           => new List<TravelerItem>
        {
            new("AirSoft Gun",1),
            new("Drink",10),
            new("Book",(uint) Math.Ceiling(data.Days/7m))
        };

}
