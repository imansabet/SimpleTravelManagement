using SimpleTravelManagement.Application.DTO;
using SimpleTravelManagement.Shared.Abstractions.Queries;

namespace SimpleTravelManagement.Application.Queries;

public  class GetTravelerCheckList : IQuery<TravelerCheckListDto>
{
    public Guid Id { get; set; }
}
