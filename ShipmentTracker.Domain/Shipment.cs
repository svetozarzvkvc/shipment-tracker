using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShipmentTracker.Domain
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public string ShipmentName {  get; set; }
        public Status Status { get; set; } = Status.Away;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeliveredAt { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Away,
        Delivered,
        Storage
    }
}
