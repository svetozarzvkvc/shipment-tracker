using ShipmentTracker.Application;
using ShipmentTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Infrastructure.DataAccess
{
    public class InMemoryShipmentStorage : IDataStorage<Shipment>
    {
        private readonly List<Shipment> _shipments;

        public InMemoryShipmentStorage()
        {
            _shipments = new List<Shipment>
            {
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Express Delivery - Tokyo",
                    Status = Status.Away,
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Urgent Shipment - Berlin",
                    Status = Status.Delivered,
                    CreatedAt = DateTime.Now.AddDays(-3),
                    DeliveredAt = DateTime.Now.AddDays(2)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Cargo - New York to London",
                    Status = Status.Away,
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Freight Package - Sydney",
                    Status = Status.Storage,
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Time-Sensitive Shipment - Paris",
                    Status = Status.Delivered,
                    CreatedAt = DateTime.Now.AddDays(-7),
                    DeliveredAt = DateTime.Now.AddDays(4)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Large Equipment - São Paulo",
                    Status = Status.Away,
                    CreatedAt = DateTime.Now.AddDays(-12)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "International Cargo - Mumbai",
                    Status = Status.Storage,
                    CreatedAt = DateTime.Now.AddDays(-8)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Medical Supplies - Johannesburg",
                    Status = Status.Away,
                    CreatedAt = DateTime.Now.AddDays(-6)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Perishable Goods - Los Angeles",
                    Status = Status.Delivered,
                    CreatedAt = DateTime.Now.AddDays(-4),
                    DeliveredAt = DateTime.Now.AddDays(3)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Sensitive Equipment - Moscow",
                    Status = Status.Storage,
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Personal Belongings - Istanbul",
                    Status = Status.Away,
                    CreatedAt = DateTime.Now.AddDays(-9)
                },
                new Shipment
                {
                    Id = Guid.NewGuid(),
                    ShipmentName = "Luxury Goods - Dubai",
                    Status = Status.Delivered,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    DeliveredAt = DateTime.Now.AddDays(1)
                }
            };
        }
        public List<Shipment> Data => _shipments;
    }
}
