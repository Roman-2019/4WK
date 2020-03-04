using System.Collections.Generic;

namespace Homework12_DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(T item);
        void Delete(int id);
        void Update(T item);
        T GetById(int id);
    }
}