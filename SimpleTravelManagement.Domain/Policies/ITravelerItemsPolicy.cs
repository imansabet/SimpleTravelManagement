using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies;

public interface ITravelerItemsPolicy
{
    bool IsApplicable(PolicyData data);
    IEnumerable<TravelerItem> GenerateItems(PolicyData data);
}
