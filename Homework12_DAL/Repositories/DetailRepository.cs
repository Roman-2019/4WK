using Homework12_DAL.Interfaces;
using Homework12_DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Homework12_DAL.Repositories
{
    public class DetailRepository : IRepository<Details>
    {
        private readonly MyDBContext _db;

        public DetailRepository()
        {
            _db = new MyDBContext();
        }

        public void Delete(int id)
        {
            var detail = GetById(id);
            _db.Details.Remove(detail);
            _db.SaveChanges();
        }

        public IEnumerable<Details> GetAll()
        {
            return _db.Details.AsNoTracking().ToList();
        }

        public void Insert(Details detail)
        {
            _db.Details.Add(detail);
            _db.SaveChanges();
        }

        public void Update(Details detail)
        {
            var updatedDetail = GetById(detail.Id);

            updatedDetail.NameDetail = detail.NameDetail;
            updatedDetail.Price = detail.Price;

            _db.Entry(updatedDetail);
            _db.SaveChanges();
        }

        public Details GetById(int id)
        {
            var detail = _db.Details.Where(x => x.Id == id).FirstOrDefault();

            return detail;
        }
    }
}