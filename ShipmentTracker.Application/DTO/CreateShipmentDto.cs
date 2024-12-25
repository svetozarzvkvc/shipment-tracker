using ShipmentTracker.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application.DTO
{
    public class CreateShipmentDto : IValidatableObject
    {
        [Required(ErrorMessage = "Shipment name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Shipment name must be between 3 and 100 characters.")]
        public string ShipmentName { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public Status Status { get; set; }
        
        public DateTime? DeliveredAt { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Status.Delivered)
            {
                if (DeliveredAt == null)
                {
                    yield return new ValidationResult("Delivered at is required when status is Delivered.", new[] { nameof(DeliveredAt) });
                }
                else if (DeliveredAt <= DateTime.Now)
                {
                    yield return new ValidationResult("Delivered at must in the future.", new[] { nameof(DeliveredAt) });
                }
            }
        }
    }
}
