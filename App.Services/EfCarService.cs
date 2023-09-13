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
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class EfCarService:ICarService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly IDeviceService _deviceService;
        private readonly DbSet<Car> _cars;

        public EfCarService(IUnitOfWork uow,IDeviceService deviceService,IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _cars = _uow.Set<Car>();
            _deviceService = deviceService;
            _mapper = mapper;
        }

        public Car SelectCar(int id)
        {
            return _cars.Find(id);
        }

        public IQueryable<Car> GetAllCars()
        {
            return _cars.Include(car=>car.Device);
        }

        public PagedList<Car> GetPagedCars(int page)
        {
            return new PagedList<Car>(_cars,page);
        }
        public Car AddNewCar(CarViewModel model)
        {
            var car = _mapper.Map<Car>(model);
            car.Device = _deviceService.SelectDevice(model.DeviceId);
            _cars.Add(car);
            return car;
        }
        public Car UpdateCar(CarViewModel model)
        {
            var existingCar = SelectCar(model.Id);
            _mapper.Map(model, existingCar);
            existingCar.Device = _deviceService.SelectDevice(model.DeviceId);
            return existingCar;
        }

        public Car DeleteCar(int id)
        {
            
            var car = SelectCar(id);
            if (car != null)
            {
              
                car.Device = null;
                _cars.Remove(car);
                return car;
            }

            return null;
        }

        public LocationLogViewModel RealTimeLocation(int id)
        {
            var car = _cars.Include(d=>d.LocationLogs).Single(d=>d.Id==id);
            var locationLog = car.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault();
            return _mapper.Map<LocationLogViewModel>(locationLog);
        }

        public IQueryable<CarRealTimeStatus> RealTimeLocations()
        {

            return _cars.Include(d => d.LocationLogs).Select(d => new CarRealTimeStatus {
                Id = d.Id, Color = d.Color,Type = d.Type,Driver = d.Driver,Plate=d.Plate, Direction = 
                d.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault().Direction,Lat = d.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault().Lat,
                Long=d.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault().Long, Speed = d.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault().Speed,
                Odometer = d.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault().Odometer,
                IsFresh =( Math.Abs((d.LocationLogs.OrderByDescending(d => d.Time).FirstOrDefault().Time-DateTime.UtcNow).Minutes)<5)

            });

        }

    }
}
