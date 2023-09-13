using System.ComponentModel;
using App.DataLayer.Context;
using App.Services.Contracts;
using App.Services.Identity;
using App.ViewModels;
using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [BreadCrumb(Title = "لاگ ها", Order = 0)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("لاگ ها")]
    public class LocationLogsController : Controller
    {
        public readonly ILocationLogService _locationLogService;
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;
        public LocationLogsController(ILocationLogService locationLogService,IUnitOfWork uow, IMapper mapper)
        {
            _locationLogService = locationLogService;
            _uow = uow;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var logs=_locationLogService.GetAllLocationLogs();
            return View(logs);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var log = _locationLogService.SelectLocationLog(id);
            ViewBag.Car = _mapper.Map<CarViewModel>(log.Car);

            return View(_mapper.Map<LocationLogViewModel>(log));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var log = _locationLogService.SelectLocationLog(id);
            ViewBag.Car = _mapper.Map<CarViewModel>(log.Car);

            return View(_mapper.Map<LocationLogViewModel>(log));
        }


        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            _locationLogService.DeleteLocationLog(id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}