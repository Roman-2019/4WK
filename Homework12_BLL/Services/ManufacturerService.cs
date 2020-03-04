using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_Common;
using Homework12_DAL.Interfaces;
using Homework12_DAL.Models;
using Homework12_DAL.Repositories;
using System.Data.Sql;

namespace Homework12_BLL.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepository<Manufacturers> _dbManuf;

        public ManufacturerService()
        {
            _dbManuf = new ManufacturerRepository();
        }

        public IEnumerable<ManufacturerModel> GetAll()
        {
            var manuf = from manufacturer in _dbManuf.GetAll()
                        select new ManufacturerModel
                        {
                          Id = manufacturer.Id,
                          Name = manufacturer.Name,
                          CarsModel = manufacturer.Cars.Select(x => new CarModel
                          {
                              Id = x.Id,
                              Name = x.Name,
                              ManufacturerId = x.ManufacturerId,
                              Details = x.Details.Select (y => new DetailModel
                              {
                                  Id = y.Id,
                                  Cost = y.Price,
                                  ManufacturerId = y.ManufacturerId,
                              }),
                          }),
                          DetailsModel = manufacturer.Details.Select (z => new DetailModel
                          {
                              Id = z.Id,
                              Name = z.NameDetail,
                              Cost = z.Price,
                              ManufacturerId = z.ManufacturerId
                          })
                        };
            return manuf.ToList(); ;
        }

        public int checkManufactorer(int  id)
        {
            var chosenManuf = _dbManuf.GetById(id);

            var manufacturers = _dbManuf.GetAll();

            var deniedManufacturer = manufacturers.FirstOrDefault(x => x.Id == 1);

            if (chosenManuf == deniedManufacturer)
            {
                throw new NotImplementedException();
            }
            else
            {
                return chosenManuf.Id;
            }
        }

        public ManufacturerModel GetById(int id)
        {
            var manuf = _dbManuf.GetById(id);

            var manufModel =  new ManufacturerModel
                        {
                            Id = manuf.Id,
                            Name = manuf.Name,
                            CarsModel = manuf.Cars.Select(x => new CarModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                ManufacturerId = x.ManufacturerId,
                                Details = x.Details.Select(y => new DetailModel
                                {
                                    Id = y.Id,
                                    Cost = y.Price,
                                    //Type = (DetailTypeEnum)y.DetailTypeId,
                                    ManufacturerId = y.ManufacturerId,
                                }),
                            }),
                            DetailsModel = manuf.Details.Select(x => new DetailModel
                            {
                                Id = x.Id,
                                Name = x.NameDetail,
                                Cost = x.Price,
                                //Type = (DetailTypeEnum)x.DetailTypeId,
                                ManufacturerId = x.ManufacturerId
                            })
                        };
            return manufModel;
        }

        public CarManufacturerModel GetMostExpensive()
        {
            var sumdetail = _dbManuf.GetAll().OrderBy(x => x.Cars.Max(y => y.Details.Sum(z => z.Price))).FirstOrDefault();
            var mostexpensive = sumdetail.Cars.Select(x => new CarModel
            {
                Id = x.Id,
                Name = x.Name,
                Details = x.Details.Select(y => new DetailModel
                {
                    Id = y.Id,
                   Name = y.NameDetail,
                    Cost = y.Price,
                }),
            }).ToList();
            var maxCar = mostexpensive.OrderBy(y => y.Details.Sum(z => z.Cost)).FirstOrDefault();

            var result =   new CarManufacturerModel
            {
                CarsModel=new CarModel 
                {
                    Id=maxCar.Id,
                    Name=maxCar.Name,
                    Details= maxCar.Details.Select(y => new DetailModel
                    {
                        Name = y.Name
                    })
                },
                ManufacturerModel=new ManufacturerModel 
                {
                    Id=sumdetail.Id,
                    Name=sumdetail.Name,
                    CarsModel= sumdetail.Cars.Select(x => new CarModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Details = x.Details.Select(y => new DetailModel
                        {
                            Id = y.Id,
                            Name = y.NameDetail,
                            Cost = y.Price,
                        })
                    }),
                    DetailsModel = sumdetail.Details.Select(z => new DetailModel
                    {
                        Id = z.Id,
                        Name = z.NameDetail,
                        Cost = z.Price,
                        ManufacturerId = z.ManufacturerId
                    })
                }
               
                //CarId = maxCar.Id,
                //CarName = maxCar.Name,
                //ManufId=sumdetail.Id,
                //ManufName=sumdetail.Name
            };
            return result;
        }

    }
}
