using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Repositories;

public interface ITravelerCheckListRepository
{
    Task<TravelerCheckList> GetAsync(TravelerCheckListId id);
    Task AddAsync(TravelerCheckList travelerCheckList );
    Task UpdateAsync(TravelerCheckList travelerCheckList );
    Task DeleteAsync(TravelerCheckList travelerCheckList );
}
 