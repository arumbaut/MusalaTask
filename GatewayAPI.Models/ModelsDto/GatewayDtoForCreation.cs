using GatewayAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Models.ModelsDto
{
    public class GatewayDtoForCreation
    {
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }

        [RegularExpression("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",ErrorMessage = "Invalid Ipv4 example 10.10.1.1")]
        public string? Address { get; set; }
       
    }
}
