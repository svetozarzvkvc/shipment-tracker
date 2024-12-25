using Microsoft.AspNetCore.Mvc;
using ShipmentTracker.Application;
using ShipmentTracker.Application.DTO;
using ShipmentTracker.Application.UseCases;
using ShipmentTracker.Application.UseCases.Commands.Shipments;
using ShipmentTracker.Application.UseCases.Queries;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure;
using ShipmentTracker.Infrastructure.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipmentTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private InMemoryShipmentStorage _data;
        private UseCaseHandler _handler;

        public ShipmentsController(InMemoryShipmentStorage data, UseCaseHandler handler)
        {
            _data = data;
            _handler = handler;
        }

        // GET: api/<ShipmentsController>

        /// <summary>
        /// Returns a list of shipments based on provided search criteria.
        /// </summary>
        /// <param name="query">
        /// A service for executing the shipment search query. This service handles the logic for filtering shipments.
        /// </param>
        /// <param name="search">
        /// An object containing search criteria, such as shipment name and status.
        /// </param>
        /// <returns> A list of shipments that match the specified criteria. </returns>
        /// <remarks>
        /// Example usage:
        /// GET /api/shipments?ShipmentName=SampleShipment&amp;Status=1
        /// </remarks>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),nameof(DefaultApiConventions.Get))]
        public IActionResult Get([FromServices] ISearchShipmentQuery query, [FromQuery] ShipmentSearchDto search)
        {
            var rezultat = _handler.HandleQuery(query,search);
            return Ok(rezultat);
        }


        // GET api/<ShipmentsController>/5

        /// <summary>
        /// Retrieves a shipment based on the provided ID.
        /// </summary>
        /// <param name="query">
        /// A service for executing the shipment retrieval query. This service handles the logic for fetching a shipment based on its ID.
        /// </param>
        /// <param name="id">
        /// The unique identifier (GUID) of the shipment to retrieve.
        /// </param>
        /// <returns>
        /// Returns an HTTP 200 OK response with the shipment details if the shipment is found.
        /// If the shipment with the provided ID does not exist, it returns a 404 Not Found response.
        /// </returns>
        /// <remarks>
        /// Example usage:
        /// GET /api/shipments/{id}
        /// </remarks>
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]

        public IActionResult Get([FromServices] IGetShipmentQuery query, Guid id)
        {
            var rezultat = _handler.HandleQuery(query, id);
            return Ok(rezultat);
        }

        // POST api/<ShipmentsController>

        /// <summary>
        /// Creates a new shipment based on the provided data.
        /// </summary>
        /// <param name="command">
        /// A service for handling the creation of a shipment. This service processes the shipment creation logic.
        /// </param>
        /// <param name="dto">
        /// An object containing the data for creating the shipment, including shipment details like name, status, etc.
        /// </param>
        /// <returns>
        /// Returns a 201 Created response if the shipment is created successfully, 
        /// with the location of the newly created shipment in the response headers.
        /// If validation fails, it returns a 422 Unprocessable Entity response.
        /// In case of an unexpected error, it returns a 500 Internal Server Error response.
        /// </returns>
        /// <remarks>
        /// Example usage:
        /// POST /api/shipments
        /// Body:
        /// {
        ///     "shipmentName": "NewShipment",
        ///     "status": 1
        /// }
        /// </remarks>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]

        public IActionResult Post([FromServices] ICreateShipmentCommand command, [FromBody] CreateShipmentDto dto)
        {
            _handler.HandleCommand(command, dto);
            return Created();
        }

        // PUT api/<ShipmentsController>/5

        /// <summary>
        /// Updates an existing shipment based on the provided data.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the shipment to be updated.
        /// </param>
        /// <param name="dto">
        /// An object containing the updated shipment details, such as shipment name, status, and delivery date.
        /// </param>
        /// <param name="command">
        /// A service for handling the update operation of the shipment. This service processes the update logic.
        /// </param>
        /// <returns>
        /// Returns a 204 No Content response if the shipment is updated successfully.
        /// If the shipment with the specified ID does not exist, it returns a 404 Not Found response.
        /// In case of validation failure, it returns a 422 Unprocessable Entity response.
        /// If an unexpected error occurs, it returns a 500 Internal Server Error response.
        /// </returns>
        /// <remarks>
        /// Example usage:
        /// PUT /api/shipments/{id}
        /// Body:
        /// {
        ///     "shipmentName": "UpdatedShipment",
        ///     "status": 2,
        ///     "deliveredAt": "2024-12-25T00:00:00"
        /// }
        /// </remarks>
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]

        public IActionResult Put(Guid id, [FromBody] UpdateShipmentDto dto, [FromServices] IUpdateShipmentCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ShipmentsController>/5

        /// <summary>
        /// Deletes an existing shipment by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the shipment to be deleted.
        /// </param>
        /// <param name="command">
        /// A service for handling the delete operation of the shipment. This service processes the deletion logic.
        /// </param>
        /// <returns>
        /// Returns a 204 No Content response if the shipment is deleted successfully.
        /// If the shipment with the specified ID does not exist, it returns a 404 Not Found response.
        /// In case of an unexpected error, it returns a 500 Internal Server Error response.
        /// </returns>
        /// <remarks>
        /// Example usage:
        /// DELETE /api/shipments/{id}
        /// </remarks>
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]

        public IActionResult Delete(Guid id, [FromServices] IDeleteShipmentCommand command)
        {
           _handler.HandleCommand(command, id);
           return NoContent();
        }
    }
}
