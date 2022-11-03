using GatewayAPI.Data.Context;
using GatewayAPI.Models.Entities;
using GatewayAPI.Models.Interfaces.IGRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Data.Repositories.GatewayRepository
{
    public class GatewaysR : GenericRepository<Gateway>, IGatewaysR
    {
        public GatewaysR(GatewayApiContext context) : base(context) { }
        public void AddPeripheralsForGateway(int idg, Peripheral p) {
            var gateway = GetById(idg);
            gateway.Peripherals.Add(p);
        }

        public Gateway GetGateway(int idg, bool includePeripherals)
        {
            if(includePeripherals)
                return _context.Gateways.Include(g => g.Peripherals).Where(g => g.Id == idg).FirstOrDefault();
            
            return GetById(idg);
        }


    }
}
