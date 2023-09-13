using System.Linq;
using App.Services.Contracts;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [Authorize]
    [BreadCrumb(Title = "خانه", UseDefaultRouteUrl = true, Order = 0)]
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly IDeviceService _deviceService;
        private readonly ILocationLogService _locationLogService;
        private readonly IEventService _eventService;


        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public HomeController(ICarService carService,IDeviceService deviceService,ILocationLogService locationLogService,IEventService eventService)
        {
            _carService = carService;
            _deviceService = deviceService;
            _locationLogService = locationLogService;
            _eventService = eventService;
        }


        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {


            ViewBag.CarsCount = _carService.GetAllCars().Count();
            ViewBag.DevicesCount = _deviceService.GetAllDevices().Count();
            ViewBag.LocationLogsCount = _locationLogService.GetAllLocationLogs().Count();
            ViewBag.EventsCount = _eventService.GetAllEvents().Count();

            return View(_carService.GetAllCars());
        }

    }
}