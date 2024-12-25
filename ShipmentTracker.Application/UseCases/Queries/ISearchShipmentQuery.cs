using ShipmentTracker.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application.UseCases.Queries
{
    public interface ISearchShipmentQuery : IQuery<List<ShipmentDto>,ShipmentSearchDto>
    {
    }
}
