using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application.UseCases.Commands.Shipments
{
    public interface IDeleteShipmentCommand : ICommand<Guid>
    {
    }
}
