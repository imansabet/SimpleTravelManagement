using SimpleTravelManagement.Domain.Exceptions;
using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Domain.ValueObjects;

public  record TravelerItem
{
    public string Name  { get; }
    public uint Quantity  { get;  }
    public bool IsTaken { get; init; }
    public TravelerItem(string name , uint quantity , bool isTaken  = false) 
    {
        if (string.IsNullOrEmpty(name)) 
        {
            throw new TravelerItemNameException();
        } 
        Name = name;
        Quantity = quantity;
        IsTaken = isTaken;
    }
   
        
   
}
