using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipmentTracker.Domain;

namespace ShipmentTracker.Application.DTO
{
    public class UpdateShipmentDto : IValidatableObject
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Shipment name must be between 3 and 100 characters.")]
        public string? ShipmentName { get; set; }
        public Status? Status { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Domain.Status.Delivered)
            {
                if (DeliveredAt == null)
                {
                    yield return new ValidationResult("Delivered at is required when status is Delivered.", new[] { nameof(DeliveredAt) });
                }
                else if (DeliveredAt <= DateTime.Now)
                {
                    yield return new ValidationResult("Delivered at must be in the future.", new[] { nameof(DeliveredAt) });
                }
            }
        }
    }
}
