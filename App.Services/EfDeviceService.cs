using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Common.Pagination;
using App.DataLayer.Context;
using App.Entities;
using App.Services.Contracts;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class EfDeviceService:IDeviceService
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly DbSet<Device> _devices;

        public EfDeviceService(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _devices = _uow.Set<Device>();
            _mapper = mapper;
        }
        
        public Device SelectDevice(int id)
        {
            return _devices.Find(id);
        }
        public Device SelectDeviceByMacAddress(string mac)
        {
            return _devices.Include(d=>d.Car).FirstOrDefault(d=>d.MacAddress==mac);
        }

        public IQueryable<Device> GetAllDevices()
        {
            return _devices;
        }

        public PagedList<Device> GetPagedDevices(int page)
        {
            return new PagedList<Device>(_devices, page);
        }

        public Device AddNewDevice(DeviceViewModel model)
        {
            var device = _mapper.Map<Device>(model);
            _devices.Add(device);
            return device;
        }

        public Device UpdateDevice(DeviceViewModel model)
        {
            var existingDevice = SelectDevice(model.Id);
            _mapper.Map(model, existingDevice);
            return existingDevice;
        }

        public Device DeleteDevice(int  id)
        {
            var device = SelectDevice(id);
            if (device != null)
            {
                device.Car = null;
                _devices.Remove(device);
                return device;
            }

            return null;
        }

        public IList<SelectListItem> GetDevicesSelectList()
        { 
            return _devices.Select(device => new SelectListItem { Value = device.Id.ToString(), Text = device.MacAddress }).ToList();

        }
    }
}
