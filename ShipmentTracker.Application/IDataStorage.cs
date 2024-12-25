using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracker.Application
{
    public interface IDataStorage<TData>
    {
        List<TData> Data { get; }
    }
}
