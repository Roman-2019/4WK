using System.Collections.Generic;
using System.Data.Entity;
using Homework12_DAL.Interfaces;
using Homework12_DAL.Models;
using System.Linq;

namespace Homework12_DAL.Repositories
{
    public class CarRepository : IRepository<Cars>
    {
        private readonly MyDBContext _db;

        public CarRepository()
        {
            _db = new MyDBContext();
        }

        public void Delete(int id)
        {
            var car = GetById(id);

            _db.Cars.Remove(car);
            _db.SaveChanges();
        }

        public IEnumerable<Cars> GetAll()
        {
            return _db.Cars.AsNoTracking().ToList();
        }

        public void Insert(Cars car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        public void Update(Cars car)
        {
            var updatedCar = GetById(car.Id);

            updatedCar.Name = car.Name;

            _db.Entry(updatedCar);
            _db.SaveChanges();
        }

        public Cars GetById(int id)
        {
            var car = _db.Cars.Where(x => x.Id == id).FirstOrDefault();
            return car;
        }
    }
}