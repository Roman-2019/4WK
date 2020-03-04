using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_BLL.Services;
using Homework12_Common;
using Homework12_DAL.Repositories;
using Homework12_PL.Interfaces;
using Homework12_PL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework12_PL.Controller
{
    public class DetailController : IDetailController
    {
        private readonly IDetailService _dbDetail;

        public DetailController()
        {
            _dbDetail = new DetailService();
        }

        public void Add(DetailViewModel detailViewModel)
        {
            var detail = new DetailModel
            {
                Name = "Engine",
                Type = DetailTypeEnum.Engine,
                Cost = 1280,
                CarId = 8,
                ManufacturerId = 2
            };
            _dbDetail.Add(detail);
        }

        public void Delete(int id)
        {
            _dbDetail.Delete(id);
        }

        public IEnumerable<DetailViewModel> GetAll()
        {
            var detailViewModel = from detail in _dbDetail.GetAll()
                                  select new DetailViewModel
                                  {
                                      Name = detail.Name,
                                      Cost = detail.Cost,
                                      CarViewModel = new CarViewModel
                                      {
                                          Id = detail.CarModel.Id,
                                          Name = detail.CarModel.Name,
                                      },
                                      Type = (DetailTypeEnum)detail.Type,
                                      CarId = detail.CarId,
                                      Manufacturer = new ManufacturerViewModel
                                      {
                                          Id = detail.Manufacturer.Id,
                                          Name = detail.Manufacturer.Name
                                      }
                                  };
            return detailViewModel.ToList();
        }

        public void Update(DetailViewModel detailViewModel)
        {
            var detailModel = new DetailModel
            {
                Id = 1,
                Name = "PeterDetail",
                Cost = 000000,
            };

            _dbDetail.Update(detailModel);
        }

        public DetailViewModel GetById(int id)
        {
            var detailModel = _dbDetail.GetById(id);

            var detailViewModel = new DetailViewModel
            {
                Id = detailModel.Id,
                Name = detailModel.Name,
                Cost = detailModel.Cost,
                CarViewModel = new CarViewModel
                {
                    Id = detailModel.CarModel.Id,
                    Name = detailModel.CarModel.Name,
                },
                Type = (DetailTypeEnum)detailModel.Type,
                CarId = detailModel.CarId,
                Manufacturer = new ManufacturerViewModel
                {
                    Id = detailModel.Manufacturer.Id,
                    Name = detailModel.Manufacturer.Name
                }
            };

            return detailViewModel;
        }
    }
}