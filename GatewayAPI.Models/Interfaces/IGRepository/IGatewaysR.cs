using GatewayAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Models.Interfaces.IGRepository
{
    public interface IGatewaysR : IGenericRepository<Gateway>
    {
        void AddPeripheralsForGateway(int idg, Peripheral p) { }
        Gateway GetGateway(int idg,bool includePeripherals);

    }

}
