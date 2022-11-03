using AutoMapper;
using GatewayAPI.Data.Repositories.GatewayRepository;
using GatewayAPI.Data.UnitOfWork;
using GatewayAPI.Models.Entities;
using GatewayAPI.Models.Interfaces;
using GatewayAPI.Models.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers
{
    [Route("api/gateways")]
    public class GatewaysControlller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GatewaysControlller(IUnitOfWork unitOfWork,IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet(Name = "GetAllGateways")]
        public ActionResult GetGateways() {

            var gateways = _unitOfWork.Gateways.GetAll();
            IEnumerable<GatewayDto> gatewayResult = _mapper.Map<IEnumerable<GatewayDto>>(gateways) ;
            
            return Ok(gatewayResult);

        }
        [HttpGet("{gid}",Name = "GetGateway")]
        public ActionResult GetGateway(int gid, bool includePeripherals = false) {
            var gateway = _unitOfWork.Gateways.GetGateway(gid,includePeripherals);
            if (gateway == null) {
                return NotFound();
            }
            //Para mapear en caso sin automapper
            //if (gateway.Peripherals.Count != 0) { 
            //    var gatewayResult = new GatewayDto()
            //    {
            //        Address=gateway.Address,
            //        Name = gateway.Name,
            //        SerialNumber = gateway.SerialNumber,
            //    };
            //    foreach (var item in gateway.Peripherals)
            //    {
            //        gatewayResult.Peripherals.Add(
            //                new PeripheralDto() 
            //                {
            //                    UID=item.UID,
            //                    Id=item.Id,
            //                    DateTime= item.DateTime,
            //                    Status=item.Status,
            //                    Vendor = item.Vendor
            //                }
            //            );
            //    }
            //    return Ok(gatewayResult);
            //}
            if (includePeripherals)
            {
                var gatewayResult = _mapper.Map<GatewayDto>(gateway);
                return Ok(gatewayResult);
            }

            var gatewayNotPeripherals = _mapper.Map<GatewayDtoNotPeripherals>(gateway);
            return Ok(gatewayNotPeripherals);
            
        }

        [HttpPost("create",Name ="CreateGateway")]
        public ActionResult CreateGateways([FromBody] GatewayDtoForCreation gateway) 
        {

            if (gateway == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }


            var gateway1 = _mapper.Map<Gateway>(gateway);
            //Gateway gateway1 = new Gateway() { 
            //    SerialNumber=gateway.SerialNumber,
            //    Name=gateway.Name,
            //    Address=gateway.Address,

            //};

            _unitOfWork.Gateways.Add(gateway1);
            if (!(_unitOfWork.Complete() >= 0))
            {
                return StatusCode(500, "A problem happened when handling request");
            }

            return StatusCode(201, $"Se creo con exito el periferioc con id {gateway1.Id}");

        }

        [HttpDelete("delete/{gid}")]
        public ActionResult DeleteGateway(int gid) { 
            var gateway = _unitOfWork.Gateways.GetById(gid);

            if (gateway == null) {
                return NotFound($"El gateway con id {gid} no existe");
            }
            _unitOfWork.Gateways.Remove(gateway);
            _unitOfWork.Complete();
            
            return NoContent();

        }
    }
}
