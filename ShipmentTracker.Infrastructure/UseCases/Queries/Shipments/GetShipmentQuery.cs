using ShipmentTracker.Application.DTO;
using ShipmentTracker.Application.Exceptions;
using ShipmentTracker.Application.UseCases.Queries;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShipmentTracker.Infrastructure.UseCases.Queries.Shipments
{
    public class GetShipmentQuery : IGetShipmentQuery
    {
        public int Id => 2;

        public string Name => "Get shipment by id";

        private readonly InMemoryShipmentStorage _context;
        public GetShipmentQuery(InMemoryShipmentStorage context)
        {
            _context = context;
        }
        public InMemoryShipmentStorage Context => _context;
        public ShipmentDto Execute(Guid search)
        {
            Shipment s = _context.Data.FirstOrDefault(sh => sh.Id == search);
           
            if (s == null)
            {
                throw new NotFoundException("Shipment", search);
            }
            ShipmentDto dto = new()
            {
                Id = s.Id,
                Name = s.ShipmentName,
                DateCreated = s.CreatedAt,
                DeliveredAt = s.DeliveredAt,
                Status = s.Status.ToString()
            };
            return dto;
        }
    }
}
