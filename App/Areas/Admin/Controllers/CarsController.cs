using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using App.DataLayer.Context;
using App.Entities;
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
    [BreadCrumb(Title = "خودروها", Order = 0)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("خودروها")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IDeviceService _deviceService;
        private readonly ILocationLogService _locationLogService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public CarsController(ICarService carService, IDeviceService deviceService, IMapper mapper,IUnitOfWork uow, ILocationLogService locationLogService)
        {
            _carService = carService;
            _deviceService = deviceService;
            _locationLogService =locationLogService;
            _mapper = mapper;
            _uow = uow;
        }
        [DisplayName("ایندکس")]
        public IActionResult Index()
        {
          
            return View(_carService.GetAllCars());
        }

        [HttpGet]
        [DisplayName("نمایش ایجاد")]
        public IActionResult Create()
        {
            ViewBag.DevicesList = _deviceService.GetDevicesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ذخیره ایجاد")]
        public IActionResult Create(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carService.AddNewCar(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        [DisplayName("نمایش ویرایش")]
        public IActionResult Edit(int id)
        {
            ViewBag.DevicesList = _deviceService.GetDevicesSelectList();
            var car = _carService.SelectCar(id);
            var model = _mapper.Map<CarViewModel>(car);
            
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ذخیره ویرایش")]
        public IActionResult Edit(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
            
                _carService.UpdateCar(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }



        [HttpGet]
        [DisplayName("نمایش حذف")]
        public IActionResult Delete(int id)
        {
            var car = _carService.SelectCar(id);
            var model = _mapper.Map<CarViewModel>(car);
            ViewBag.Device = _deviceService.SelectDevice(car.DeviceId);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ذخیره حذف")]
        public IActionResult DeleteConfirm(int id)
        {
            _carService.DeleteCar(id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        [DisplayName("جزئیات")]
        public IActionResult Details(int id)
        {
            var car = _carService.SelectCar(id);
            var model = _mapper.Map<CarViewModel>(car);
            ViewBag.Device =_mapper.Map<DeviceViewModel>(_deviceService.SelectDevice(car.DeviceId));
            ViewBag.Location= _carService.RealTimeLocation(id);
            return View(model);
        }


        [HttpGet]
        [Route("api/[Area]/[controller]/[action]")]
        public ActionResult StatusOfCars()
        {

            var locations= _carService.RealTimeLocations();
            return Ok(locations);

        }


    }
}