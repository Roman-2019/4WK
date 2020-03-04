using Homework12_DAL.Interfaces;
using Homework12_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_DAL.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturers>
    {
        private readonly MyDBContext _db;

        public ManufacturerRepository()
        {
            _db = new MyDBContext();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturers> GetAll()
        {
            return _db.Manufacturers.ToList();
        }

        public Manufacturers GetById(int id)
        {
            var manufacturer = _db.Manufacturers.Where(x => x.Id == id).FirstOrDefault();
            return manufacturer;
        }

        public void Insert(Manufacturers item)
        {
            throw new NotImplementedException();
        }

        public void Update(Manufacturers item)
        {
            throw new NotImplementedException();
        }
    }
}
