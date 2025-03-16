using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravelManagement.Shared.Abstractions.Exceptions;

public class TravelerCheckListNameException : Exception
{
    public TravelerCheckListNameException() : base("Traveler CheckList Name Cant be Null")
    {
    }
}
