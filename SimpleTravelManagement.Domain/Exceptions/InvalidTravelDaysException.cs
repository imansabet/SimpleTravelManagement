using SimpleTravelManagement.Shared.Abstractions.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace SimpleTravelManagement.Domain.Exceptions;

public class InvalidTravelDaysException : TravelerCheckListException
{
    public ushort Days { get; }
    public InvalidTravelDaysException(ushort days) : base($"Value '{days}' is Invalid ") => 
       Days = days;
     
    
}
 