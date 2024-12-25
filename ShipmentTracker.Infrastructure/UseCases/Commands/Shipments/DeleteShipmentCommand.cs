using ShipmentTracker.Application.Exceptions;
using ShipmentTracker.Application.UseCases.Commands.Shipments;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Infrastructure.UseCases.Commands.Shipments
{
    public class DeleteShipmentCommand : IDeleteShipmentCommand
    {
        public int Id => 4;

        public string Name => "Delete shipment";

        private readonly InMemoryShipmentStorage _context;
        public DeleteShipmentCommand(InMemoryShipmentStorage context)
        {
            _context = context;
        }
        public InMemoryShipmentStorage Context => _context;

        public void Execute(Guid data)
        {
            Shipment s = _context.Data.FirstOrDefault(sh => sh.Id == data);
            if (s == null)
            {
                throw new NotFoundException("Shipment", data);
            }
            _context.Data.Remove(s);
        }
    }
}
