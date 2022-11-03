using AutoMapper;
using GatewayAPI.Data.Repositories.PeripheralRepository;
using GatewayAPI.Models.Entities;
using GatewayAPI.Models.Interfaces;
using GatewayAPI.Models.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers
{
    [Route("api/gateways")]
    public class PeripheralsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PeripheralsController(IUnitOfWork unitOfWork,IMapper mapper) { 
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        [HttpGet("peripherals")]
        public ActionResult GetPeripherals() { 
            var peripherasl = _unitOfWork.Peripherals.GetAll();
            IEnumerable<PeripheralDto> peripheralsDto = _mapper.Map<IEnumerable< PeripheralDto >> (peripherasl) ;
            return Ok(peripheralsDto);
        }
        [HttpGet("{gid}/peripherals")]
        public ActionResult GetPeripheralsFronGateway(int gid) { 
           Gateway g= _unitOfWork.Gateways.GetGateway(gid,true);
            if (g == null)
            {
                return NotFound();
            }


            //List<PeripheralDto> peripherals = new List<PeripheralDto>();
            //foreach (var item in g.Peripherals)
            //{
            //    var peripheralDto = new PeripheralDto()
            //    {
            //        Id = item.Id,
            //        DateTime = item.DateTime,
            //        Status = item.Status,
            //        UID = item.UID,
            //        Vendor = item.Vendor,

            //    };
            //    peripherals.Add(peripheralDto);
            //}
            
            var gatewayPeripherals = _mapper.Map<GatewayDto>(g);
            return Ok(gatewayPeripherals);
        }

        [HttpGet("{gid}/peripherals/{pid}",Name = "GetPeripheral")]
        public ActionResult GetPeripheral(int gid,int pid)
        {
            Gateway g = _unitOfWork.Gateways.GetGateway(gid,true);
            if (g == null)
            {
                return NotFound();
            }
            var peripheral = g.Peripherals.FirstOrDefault(p=>p.Id==pid);
            if (peripheral == null)
            {
                return NotFound();
            }
            //var peripheralDto = new PeripheralDto()
            //{
            //    Id = peripheral.Id,
            //    DateTime = peripheral.DateTime,
            //    Status = peripheral.Status,
            //    UID = peripheral.UID,
            //    Vendor = peripheral.Vendor,

            //};
            var periferalDto = _mapper.Map<PeripheralDto>(peripheral);

            return Ok(periferalDto);
        }

        [HttpPost("{gid}/peripherals/create/")]
        public ActionResult CreatePeripheralsForGateway(int gid, [FromBody] PeripheralDtoForCreation peripheral) {
            
            if (_unitOfWork.Gateways.GetById(gid) == null) {
                return BadRequest();
            }

            //Peripheral peripheral1 = new Peripheral()
            //{
            //    UID = peripheral.UID,
            //    DateTime = peripheral.DateTime,
            //    Status = peripheral.Status,
            //    Vendor = peripheral.Vendor,
            //};

            var peripheralAdd = _mapper.Map<Peripheral>(peripheral);

            _unitOfWork.Gateways.AddPeripheralsForGateway(gid,peripheralAdd);
            if (!(_unitOfWork.Complete() >= 0))
            {
                return StatusCode(500, "A problem happened when handling request");
            }

            return StatusCode(201,$"Se creo con exito el periferioc con id {peripheralAdd.Id}");
            
        }
        [HttpDelete("{gid}/peripherals/delete/{pid}")]
        public ActionResult DeletePeripheralsForGateway(int gid, int pid)
        {
            var g = _unitOfWork.Gateways.GetGateway(gid,true);

            if (g == null)
            {
                return NotFound();
            }

            //Peripheral peripheral1 = new Peripheral()
            //{
            //    UID = peripheral.UID,
            //    DateTime = peripheral.DateTime,
            //    Status = peripheral.Status,
            //    Vendor = peripheral.Vendor,
            //};

            var peripheral = g.Peripherals.FirstOrDefault(p => p.Id == pid);
            if (peripheral == null)
            {
                return NotFound();
            }
            

            _unitOfWork.Peripherals.Remove(peripheral);
            _unitOfWork.Complete();

            return NoContent();

        }
    }
}
