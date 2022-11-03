using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Models.ModelsDto
{
    public class PeripheralDtoForCreation
    {
       
        public int UID { get; set; }
        public string? Vendor { get; set; }
        public DateTime DateTime { get; set; }
        public string? Status { get; set; }
    }
}
