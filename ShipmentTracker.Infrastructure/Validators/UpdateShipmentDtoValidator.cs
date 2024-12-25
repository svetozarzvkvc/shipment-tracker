using FluentValidation;
using ShipmentTracker.Application.DTO;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Infrastructure.Validators
{
    public class UpdateShipmentDtoValidator : AbstractValidator<UpdateShipmentDto>
    {
        public UpdateShipmentDtoValidator(InMemoryShipmentStorage context) 
        {
            RuleFor(x => x.ShipmentName)
                .Cascade(CascadeMode.Stop)
                .Length(3, 100).WithMessage("Shipment name must be between 3 and 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.ShipmentName));

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid status value.")
                .When(x => x.Status.HasValue);

            RuleFor(x => x.DeliveredAt)
                .GreaterThan(DateTime.Now)
                .WithMessage("DeliveredAt must be in the future.")
                .When(x => x.DeliveredAt.HasValue);

            RuleFor(x => x)
                .Must(dto => dto.Status != Status.Delivered || dto.DeliveredAt.HasValue)
                .WithMessage("If status is 'Delivered', DeliveredAt must be specified.")
                .When(x => x.Status == Status.Delivered);
        }
    }
}
