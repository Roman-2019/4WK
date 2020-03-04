using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_Common;
using Homework12_DAL.Interfaces;
using Homework12_DAL.Models;
using Homework12_DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Homework12_BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Cars> _dbCar;

        public CarService()
        {
            _dbCar = new CarRepository();

        }

        public void Add(CarModel carModel)
        {
            var car = new Cars
            {
                Name = carModel.Name,
                Details = carModel.Details.Select(x => new Details
                {
                    NameDetail = x.Name,
                    Price = x.Cost,
                    CarsId = x.CarId,
                    //DetailTypeId = (int)x.Type,
                    ManufacturerId = x.ManufacturerId
                }
                ).ToList(),
                ManufacturerId = carModel.ManufacturerId
            };

            _dbCar.Insert(car);
        }

        public void Delete(int id)
        {
            _dbCar.Delete(id);
        }

        public IEnumerable<CarModel> GetAll()
        {

            var carModels = from car in _dbCar.GetAll()
                            select new CarModel()
                            {
                                Id = car.Id,
                                Name = car.Name,
                                Details = car.Details.Select(x => new DetailModel
                                {
                                    Id = x.Id,
                                    Name = x.NameDetail,
                                    Cost = x.Price,
                                    CarId = x.CarsId,
                                    //Type = (DetailTypeEnum)x.DetailTypeId,
                                    Manufacturer = new ManufacturerModel
                                    {
                                        Id = x.Manufacturer.Id,
                                        Name = x.Manufacturer.Name
                                    }
                                }),
                                Manufacturer = new ManufacturerModel
                                {
                                    Id = car.Manufacturer.Id,
                                    Name = car.Manufacturer.Name,
                                },
                            };
            return carModels;
        }

        public void Update(CarModel carModel)
        {
            var car = new Cars
            {
                Id = carModel.Id,
                Name = carModel.Name
            };

            car.Name = carModel.Name;

            _dbCar.Update(car);
        }

        public CarModel GetById(int id)
        {
            var car = _dbCar.GetById(id);

            var carModel = new CarModel
            {
                Id = car.Id,
                Name = car.Name,
                Details = car.Details.Select(x => new DetailModel
                {
                    Id = x.Id,
                    Name = x.NameDetail,
                    Cost = x.Price,
                    CarId = x.CarsId,
                    //Type = (DetailTypeEnum)x.DetailTypeId,
                    Manufacturer = new ManufacturerModel
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name
                    }
                }),
                Manufacturer = new ManufacturerModel
                {
                    Id = car.Manufacturer.Id,
                    Name = car.Manufacturer.Name
                }

            };

            return carModel;
        }
    }
}