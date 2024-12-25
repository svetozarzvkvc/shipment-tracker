using FluentValidation;
using ShipmentTracker.Application.DTO;
using ShipmentTracker.Application.Exceptions;
using ShipmentTracker.Application.UseCases.Commands.Shipments;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure.DataAccess;
using ShipmentTracker.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Infrastructure.UseCases.Commands.Shipments
{
    public class UpdateShipmentCommand : IUpdateShipmentCommand
    {
        public int Id => 3;

        public string Name => "Update shipment";

        private readonly InMemoryShipmentStorage _context;
        private UpdateShipmentDtoValidator _validator;

        public UpdateShipmentCommand(InMemoryShipmentStorage context, UpdateShipmentDtoValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public InMemoryShipmentStorage Context => _context;

        public void Execute(UpdateShipmentDto data)
        {
            _validator.ValidateAndThrow(data);

            Shipment s = _context.Data.FirstOrDefault(sh => sh.Id == data.Id);
            if (s == null)
            {
                throw new NotFoundException("Shipment", data.Id);
            }
            s.ShipmentName = data.ShipmentName ?? s.ShipmentName;
            s.Status = data.Status ?? s.Status;
            if (s.Status != Status.Delivered)
            {
                s.DeliveredAt = null;
            }
            else
            {
                s.DeliveredAt = data.DeliveredAt ?? s.DeliveredAt;
            }
        }
    }
}
