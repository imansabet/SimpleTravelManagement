using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies.Universal;

internal sealed class BasicPolicy : ITravelerItemsPolicy
{
    private const uint MaximumQuantityOfClothes = 7;
    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>
            {
                new("Pants", Math.Min(data.Days, MaximumQuantityOfClothes)),
                new("Socks", Math.Min(data.Days, MaximumQuantityOfClothes)),
                new("T-Shirt", Math.Min(data.Days, MaximumQuantityOfClothes)),
                new("Trousers", data.Days < 7 ? 1u : 2u),
                new("Shampoo", 1),
                new("Toothbrush", 1),
                new("Toothpaste", 1),
                new("Towel", 1),
                new("Bag pack", 1),
                new("Passport", 1),
                new("Phone Charger", 1)
            };


    public bool IsApplicable(PolicyData data) => true;
   
}
