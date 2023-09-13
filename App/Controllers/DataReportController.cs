using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DataLayer.Context;
using App.Entities;
using App.Services.Contracts;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataReportController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ILocationLogService _locationLogService;
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public DataReportController(ICarService carService,ILocationLogService locationLogService, IDeviceService deviceService, IMapper mapper, IUnitOfWork uow)
        {
            _carService = carService;
            _deviceService = deviceService;
            _locationLogService = locationLogService;
            _mapper = mapper;
            _uow = uow;
        }

        
        [HttpGet]
        public ActionResult GetItem()
        {
            return Ok("Hello farhad");
        }

        [HttpPost]
        public ActionResult<DevicePacket> PostItem(DevicePacket model)
        {

            if (ModelState.IsValid)
            {

                var device = _deviceService.SelectDeviceByMacAddress(model.Key);
                if (device == null)
                {
                    return NotFound();
                }

                var car = device.Car;

                var unixTimeStamp = new DateTime(1970, 1, 1, 0, 0, 0);
                var res = DateTime.SpecifyKind(unixTimeStamp, DateTimeKind.Utc)+ TimeSpan.FromSeconds(model.DateTime);

                _locationLogService.AddNewLocationLog(new LocationLog()
                {
                    Car = car,
                    Direction = model.Direction,
                    Lat = model.Lat,
                    Long = model.Long,
                    Odometer = (int)model.Odometry,
                    Speed = (int)model.Speed,
                    Time = res,

                });

             

                _uow.SaveChanges();

                return model;
            }

            return BadRequest();

        }

    }
}
