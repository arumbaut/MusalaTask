using GatewayAPI.Data.Context;
using GatewayAPI.Models.Entities;
using GatewayAPI.Models.Interfaces.IPRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Data.Repositories.PeripheralRepository
{
    public class PeripheralsR : GenericRepository<Peripheral>, IPeripheralsR
    {
        public PeripheralsR(GatewayApiContext context) : base(context) { }

    }
}
