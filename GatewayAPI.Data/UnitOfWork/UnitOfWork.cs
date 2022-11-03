using GatewayAPI.Data.Context;
using GatewayAPI.Data.Repositories.GatewayRepository;
using GatewayAPI.Data.Repositories.PeripheralRepository;
using GatewayAPI.Models.Interfaces;
using GatewayAPI.Models.Interfaces.IGRepository;
using GatewayAPI.Models.Interfaces.IPRepository;

namespace GatewayAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GatewayApiContext _context;
        public UnitOfWork(GatewayApiContext context)
        {
            _context = context;
            Gateways = new GatewaysR(_context);
            Peripherals = new PeripheralsR(_context);
        }
        public IGatewaysR Gateways { get; private set; }
        public IPeripheralsR Peripherals { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
