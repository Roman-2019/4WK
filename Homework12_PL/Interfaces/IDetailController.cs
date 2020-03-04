using Homework12_PL.Models;
using System.Collections.Generic;

namespace Homework12_PL.Interfaces
{
    public interface IDetailController
    {
        IEnumerable<DetailViewModel> GetAll();
        void Delete(int id);
        void Add(DetailViewModel detailModel);
        void Update(DetailViewModel detailModel);
    }
}
