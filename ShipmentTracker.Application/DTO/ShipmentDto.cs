using ShipmentTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application.DTO
{
    public class ShipmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
