using Homework12_BLL.Models;
using System.Collections.Generic;

namespace Homework12_BLL.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarModel> GetAll();
        void Add(CarModel carModel);
        void Update(CarModel carModel);
        void Delete(int id);
        CarModel GetById(int id);
    }
}