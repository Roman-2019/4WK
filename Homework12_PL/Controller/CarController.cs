using System;
using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_BLL.Services;
using Homework12_PL.Interfaces;
using Homework12_PL.Models;
using System.Collections.Generic;
using System.Linq;
using Homework12_Common;

namespace Homework12_PL.Controller
{
    public class CarController : ICarController
    {
        private readonly ICarService _dbCar;
        private readonly IDetailService _dbDetail;
        private readonly IManufacturerService _dbManuf ;

        public CarController()
        {
            _dbCar = new CarService();
            _dbDetail = new DetailService();
            _dbManuf = new ManufacturerService();
        }

        public void Add(CarViewModel carViewModel)
        {
            var car = new CarModel
            {
                Name = "Toyota",
                Details = new List<DetailModel>
                {
                    new DetailModel
                    {
                        Name = "Wheel",
                        Cost = 150,
                        Type = DetailTypeEnum.Wheel,
                        ManufacturerId = _dbManuf.checkManufactorer(2),
                    },
                    //new DetailModel
                    //{
                    //    Name = "Wheel",
                    //    Cost = 100,
                    //    Type = DetailTypeEnum.Wheel,
                    //    ManufacturerId = _dbManuf.checkManufactorer(3),
                    //},
                    //new DetailModel
                    //{
                    //    Name = "SteeringWheel",
                    //    Cost = 3333,
                    //    Type = DetailTypeEnum.SteeringWheel,
                    //    ManufacturerId = _dbManuf.checkManufactorer(2),
                    //}
                },
                ManufacturerId = _dbManuf.checkManufactorer(2),
            };


            _dbCar.Add(car);
        }

        public void Delete(int id)
        {
            _dbCar.Delete(id);
        }

        public IEnumerable<CarViewModel> GetAll()
        {

            var carViewModels = from car in _dbCar.GetAll()
                                select new CarViewModel()
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    Details = car.Details.Select(x => new DetailViewModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Cost = x.Cost,
                                        CarId = x.CarId,
                                        Type = (DetailTypeEnum)x.Type,
                                        Manufacturer = new ManufacturerViewModel
                                        {
                                            Id = x.Manufacturer.Id,
                                            Name = x.Manufacturer.Name
                                        }
                                    }),
                                    Manufacturer = new ManufacturerViewModel
                                    {
                                        Id = car.Manufacturer.Id,
                                        Name = car.Manufacturer.Name
                                    }
                                };

            return carViewModels;
        } 

        public void Update(CarViewModel carViewModel)
        {
            var carModel = new CarModel
            {
                Id = 1,
                Name = "Peugau"
            };

            _dbCar.Update(carModel);
        }

        public CarViewModel GetCarById(int id)
        {
            var carModel = _dbCar.GetById(id);

            var carViewModel = new CarViewModel
            {
                Id = carModel.Id,
                Name = carModel.Name,
                Details = carModel.Details.Select(x => new DetailViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                    CarId = x.CarId,
                    Type = (DetailTypeEnum)x.Type,
                    Manufacturer = new ManufacturerViewModel
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name
                    }
                }),
                Manufacturer = new ManufacturerViewModel
                {
                    Id = carModel.Manufacturer.Id,
                    Name = carModel.Manufacturer.Name
                }
            };

            return carViewModel;
        }
    }
}