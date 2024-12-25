using ShipmentTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application.DTO
{
    public class ShipmentSearchDto
    {
        public string ShipmentName { get; set; }
        public Status? Status { get; set; }
    }
}
