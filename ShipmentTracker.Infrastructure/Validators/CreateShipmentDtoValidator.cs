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
    public class CreateShipmentDtoValidator : AbstractValidator <CreateShipmentDto>
    {
        public CreateShipmentDtoValidator(InMemoryShipmentStorage context)
        {
            RuleFor(x => x.ShipmentName)
                .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Shipment name can't be empty.")
            .Length(3, 100).WithMessage("Shipment name must be between 3 and 100 characters.");

            RuleFor(x => x.Status)
                .Cascade(CascadeMode.Stop)
                .IsInEnum().WithMessage("Invalid status value.");

            RuleFor(x => x.DeliveredAt)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .When(x => x.Status == Status.Delivered)
                .WithMessage("DeliveredAt must be provided if status is 'Delivered' .");

            RuleFor(x => x.DeliveredAt)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(DateTime.Now)
                .When(x => x.Status == Status.Delivered && x.DeliveredAt.HasValue)
                .WithMessage("DeliveredAt must be in the future.");
        }
    }
}
