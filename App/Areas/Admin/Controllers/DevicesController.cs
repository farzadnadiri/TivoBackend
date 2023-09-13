using System.ComponentModel;
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
    [BreadCrumb(Title = "دستگاه ها", Order = 0)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("دستگاه ها")]
    public class DevicesController : Controller
    {
        public readonly IDeviceService _deviceService;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _uow;
        public DevicesController(IDeviceService deviceService,IMapper mapper,IUnitOfWork uow)
        {
            _deviceService = deviceService;
            _mapper = mapper;
            _uow = uow;
        }
        [DisplayName("ایندکس")]
        public IActionResult Index()
        {
            return View(_deviceService.GetAllDevices());
        }
        [DisplayName("نمایش ایجاد")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [DisplayName("ذخیره ایجاد")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceViewModel model)
        {
            if (ModelState.IsValid)
            {
              
                _deviceService.AddNewDevice(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [DisplayName("نمایش ویرایش")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.DevicesList = _deviceService.GetDevicesSelectList();
            var device = _deviceService.SelectDevice(id);
            var model = _mapper.Map<DeviceViewModel>(device);

            return View(model);
        }

        [DisplayName("ذخیره ویرایش")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceViewModel model)
        {
            if (ModelState.IsValid)
            {

                _deviceService.UpdateDevice(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [DisplayName("نمایش حذف")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var device = _deviceService.SelectDevice(id);
            var model = _mapper.Map<DeviceViewModel>(device);

            return View(model);
        }

        [DisplayName("ذخیره حذف")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            _deviceService.DeleteDevice(id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}