using System.ComponentModel;
using App.Services.Contracts;
using App.Services.Identity;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [BreadCrumb(Title = "رویدادها", Order = 0)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("رویدادها")]
    public class EventsController : Controller
    {
        private IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
    
        public IActionResult Index()
        {
            return View(_eventService.GetAllEvents());
        }
    }
}
