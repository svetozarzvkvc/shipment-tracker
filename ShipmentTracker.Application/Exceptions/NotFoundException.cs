using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityType, Guid id) :
            base($"Record of type {entityType} with an id of {id} doesn't exist.")
        {

        }
    }
}
