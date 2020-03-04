using Homework12_BLL.Models;
using System.Collections.Generic;

namespace Homework12_BLL.Interfaces
{
    public interface IDetailService
    {
        IEnumerable<DetailModel> GetAll();
        void Delete(int id);
        void Add(DetailModel detailModel);
        void Update(DetailModel detailModel);
        DetailModel GetById(int id);
    }
}