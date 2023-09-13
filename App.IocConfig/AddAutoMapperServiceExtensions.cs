using System;
using System.Collections.Generic;
using System.Text;
using App.Entities;
using App.ViewModels;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.IocConfig
{

    public static class AddAutoMapperServiceExtensions
    {
        public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfigurations());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }

    public class AutoMapperConfigurations : Profile
    {

        public AutoMapperConfigurations()
        {
            CreateMap<CarViewModel, Car>();
            CreateMap<Car, CarViewModel>();
            CreateMap<DeviceViewModel, Device>();
            CreateMap<Device, DeviceViewModel>();
            CreateMap<LocationLog, LocationLogViewModel>();
            CreateMap<LocationLogViewModel, LocationLog>();
          
        }

      
    }
}
