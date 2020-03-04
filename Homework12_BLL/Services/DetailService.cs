using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_DAL.Interfaces;
using Homework12_DAL.Models;
using Homework12_DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using Homework12_Common;

namespace Homework12_BLL.Services
{
    public class DetailService : IDetailService
    {
        private readonly IRepository<Details> _dbDetail;

        public DetailService()
        {
            _dbDetail = new DetailRepository();
        }

        public IEnumerable<DetailModel> GetAll()
        {

            var details = from detail in _dbDetail.GetAll()
                          select new DetailModel
                          {
                              Id = detail.Id,
                              Name = detail.NameDetail,
                              Cost = detail.Price,
                              CarModel = new CarModel
                              {
                                  Id = detail.Car.Id,
                                  Name = detail.Car.Name
                              },
                              CarId = detail.CarsId,
                              //Type = (DetailTypeEnum)detail.DetailTypeId,
                              Manufacturer = new ManufacturerModel
                              {
                                  Id = detail.Manufacturer.Id,
                                  Name = detail.Manufacturer.Name
                              }
                          };


            return details.ToList();
        }

        public void Delete(int id)
        {
            _dbDetail.Delete(id);
        }

        public void Add(DetailModel detailModel)
        {
            //var car = _dbCar.GetAll().Where(x => x.Id == detailModel.CarId).FirstOrDefault();

            var detail = new Details
            {
                NameDetail = detailModel.Name,
                Price = detailModel.Cost,
                CarsId = detailModel.CarId,
                Manufacturer = new Manufacturers
                { 
                    Id = detailModel.ManufacturerId
                }  //TODO:check      
            };

            _dbDetail.Insert(detail);
        }

        public void Update(DetailModel detailModel)
        {
            var detail = new Details
            {
                Id = detailModel.Id,

                NameDetail = detailModel.Name,
                Price = detailModel.Cost
            };

            _dbDetail.Update(detail);
        }

        public DetailModel GetById(int id)
        {
            var detail = _dbDetail.GetById(id);

            var detailModel = new DetailModel
            {
                Id = detail.Id,
                Name = detail.NameDetail,
                Cost = detail.Price,
                CarModel = new CarModel
                {
                    Id = detail.Car.Id,
                    Name = detail.Car.Name,
                },
                //Type = (DetailTypeEnum)detail.DetailTypeId,
                Manufacturer = new ManufacturerModel
                {
                    Id = detail.Manufacturer.Id,
                    Name = detail.Manufacturer.Name
                }
            };

            return detailModel;
        }
    }
}