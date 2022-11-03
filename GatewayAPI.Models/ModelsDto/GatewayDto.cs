using GatewayAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Models.ModelsDto
{
    public class GatewayDto
    {
        public int Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public List<PeripheralDto> Peripherals { get; set; } = new List<PeripheralDto>();
    }
}
