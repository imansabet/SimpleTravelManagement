using SimpleTravelManagement.Application.DTO;
using SimpleTravelManagement.Shared.Abstractions.Queries;

namespace SimpleTravelManagement.Application.Queries;

public class SearchTravelerCheckList : IQuery<IEnumerable<TravelerCheckListDto>>
{
    public string SearchPhrase { get; set; }
}