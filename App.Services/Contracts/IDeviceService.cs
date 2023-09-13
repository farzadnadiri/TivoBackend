using System.Collections.Generic;
using System.Linq;
using App.Common.Pagination;
using App.Entities;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Contracts
{
    public interface IDeviceService
    {
        Device SelectDevice(int id);
        Device SelectDeviceByMacAddress(string mac);
        IQueryable<Device> GetAllDevices();
        PagedList<Device> GetPagedDevices(int page);
        Device AddNewDevice(DeviceViewModel model);
        Device UpdateDevice(DeviceViewModel model);
        Device DeleteDevice(int id);
        IList<SelectListItem> GetDevicesSelectList();
    }
}