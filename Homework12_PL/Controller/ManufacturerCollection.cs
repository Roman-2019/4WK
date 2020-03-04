using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_BLL.Services;
using Homework12_Common;
using Homework12_PL.Interfaces;
using Homework12_PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_PL.Controller
{
    public class ManufacturerCollection: IManufacturerCollection
    {
        private readonly IManufacturerService _dbManuf;

        public ManufacturerCollection()
        {
            _dbManuf = new ManufacturerService();
        }

        public IEnumerable<ManufacturerViewModel> GetAll()
        {
            var manuf = from manufacturer in _dbManuf.GetAll()
                        select new ManufacturerViewModel
                        {
                            Id = manufacturer.Id,
                            Name = manufacturer.Name,
                            CarsModel = manufacturer.CarsModel.Select(x => new CarViewModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                ManufacturerId = x.ManufacturerId,
                                Details = x.Details.Select(y => new DetailViewModel
                                {
                                    Id = y.Id,
                                    Cost = y.Cost,
                                    Type = (DetailTypeEnum)y.Type,
                                    ManufacturerId = y.ManufacturerId,
                                }),
                            }),
                            DetailsModel = manufacturer.DetailsModel.Select(z => new DetailViewModel
                            {
                                Id = z.Id,
                                Name = z.Name,
                                Cost = z.Cost,
                                ManufacturerId = z.ManufacturerId
                            })
                        };
            return manuf.ToList();
        }

        public ManufacturerViewModel GetById(int id)
        {
            var manuf = _dbManuf.GetById(id);

            var manufModel = new ManufacturerViewModel
            {
                Id = manuf.Id,
                Name = manuf.Name,
                CarsModel = manuf.CarsModel.Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerId = x.ManufacturerId,
                    Details = x.Details.Select(y => new DetailViewModel
                    {
                        Id = y.Id,
                        Cost = y.Cost,
                        Type = (DetailTypeEnum)y.Type,
                        ManufacturerId = y.ManufacturerId,
                    }),
                }),
                DetailsModel = manuf.DetailsModel.Select(x => new DetailViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                    Type = (DetailTypeEnum)x.Type,
                    ManufacturerId = x.ManufacturerId
                })
            };
            return manufModel;
        }

        //public int checkManufactorer(int id)
        //{
        //    var chosenManufId = _dbManuf.checkManufactorer(id);

        //    return chosenManufId;
        //}
    }
}
