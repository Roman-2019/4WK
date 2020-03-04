using Homework12_PL.Models;
using System.Collections.Generic;

namespace Homework12_PL.Interfaces
{
    public interface ICarController
    {
        IEnumerable<CarViewModel> GetAll();
        void Add(CarViewModel carModel);
        void Update(CarViewModel carModel);
        void Delete(int id);

    }
}