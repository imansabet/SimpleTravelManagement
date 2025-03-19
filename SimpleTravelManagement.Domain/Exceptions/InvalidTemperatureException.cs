using SimpleTravelManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravelManagement.Domain.Exceptions;

public  class InvalidTemperatureException : TravelerCheckListException
{
    public double Value { get;  }
    public InvalidTemperatureException(double value) : base($"Value : `{value}` is invalid temperature") => Value = value;
    
}
