using ShipmentTracker.Application.DTO;
using ShipmentTracker.Application.UseCases.Queries;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Infrastructure.UseCases.Queries.Shipments
{
    public class SearchShipmentQuery : ISearchShipmentQuery
    {
        public int Id => 1;

        public string Name => "Search shipment";

        private readonly InMemoryShipmentStorage _context;
        public SearchShipmentQuery(InMemoryShipmentStorage context)
        {
            _context = context;
        }
        public InMemoryShipmentStorage Context => _context;

        public List<ShipmentDto> Execute(ShipmentSearchDto search)
        {
            IQueryable<Shipment> query = _context.Data.AsQueryable();

            if (!string.IsNullOrEmpty(search.ShipmentName))
            {
                query = query.Where(x => x.ShipmentName.ToLower().Contains(search.ShipmentName.ToLower()));
            }

            if (search.Status.HasValue)
            {
                query = query.Where(x => x.Status == search.Status);
            }

            List<ShipmentDto> shipments = query.Select(s => new ShipmentDto
            {
                Id = s.Id,
                Name = s.ShipmentName,
                DateCreated = s.CreatedAt,
                DeliveredAt = s.DeliveredAt,
                Status = s.Status.ToString()
            }).ToList();

            return shipments;
        }
    }
}
