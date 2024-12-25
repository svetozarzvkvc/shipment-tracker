using FluentValidation;
using ShipmentTracker.Application.DTO;
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
    public class CreateShipmentCommand : ICreateShipmentCommand
    {
        private readonly InMemoryShipmentStorage _context;
        private CreateShipmentDtoValidator _validator;
        public CreateShipmentCommand(InMemoryShipmentStorage context, CreateShipmentDtoValidator validator) 
        {
            _context = context;
            _validator = validator;
        }
        public InMemoryShipmentStorage Context => _context;
        public int Id => 5;

        public string Name => "Created shipment";

        public void Execute(CreateShipmentDto data)
        {
            _validator.ValidateAndThrow(data);

            Shipment shipment = new Shipment
            {
                Id = Guid.NewGuid(),
                ShipmentName = data.ShipmentName,
                CreatedAt = DateTime.Now,
                Status = data.Status,
                DeliveredAt = data.DeliveredAt
              
            };

            Context.Data.Add(shipment);
        }
    }
}
