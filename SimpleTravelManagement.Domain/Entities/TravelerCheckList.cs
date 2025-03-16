using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Entities;

public class TravelerCheckList
{
    public TravelerCheckListId Id { get; private set; }
    private TravelerCheckListName _name;
    private Destination _destination;

    private readonly LinkedList<TravelerItem> _items = new ();

    public TravelerCheckList()
    {
        
    }

    internal TravelerCheckList(TravelerCheckListId id,
        TravelerCheckListName name ,
        Destination destination)
    {
        Id = id;
        _name = name;
        _destination = destination;
    }

    private TravelerCheckList(TravelerCheckListId id,
        TravelerCheckListName name,
        Destination destination , LinkedList<TravelerItem> items) 
        : this(id,name,destination)
    {
        _items = items;
    }
}



