using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Models.Entities
{
    public class Peripheral
    {
       
        public int Id { get; set; }
        public int UID { get; set; }
        public string? Vendor { get; set; }
        public DateTime DateTime { get; set; }
        public string? Status { get; set; }
        
        [ForeignKey("GatewayId")]
        public Gateway? Gateway { get; set; }
        public int GatewayId { get; set; }

    }
}
