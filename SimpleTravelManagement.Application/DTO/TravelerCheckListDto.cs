using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Application.DTO;

public class TravelerCheckListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DestinationDto Destination { get; set; }
    public IEnumerable<TravelerItemDto> Items { get; set; }

}
