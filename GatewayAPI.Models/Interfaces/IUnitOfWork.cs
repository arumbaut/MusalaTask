using GatewayAPI.Models.Interfaces.IGRepository;
using GatewayAPI.Models.Interfaces.IPRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGatewaysR Gateways { get; }
        IPeripheralsR Peripherals { get; }
        int Complete();
    }
}
