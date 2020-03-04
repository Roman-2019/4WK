using Homework12_PL.Controller;
using System;
using Homework12_BLL.Services;

namespace Homework12_ThreeLayer_Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            var carController = new CarController();
            var detailController = new DetailController();
            var manufacturerController = new ManufacturerCollection();
            var manufacturerService = new ManufacturerService();

            var allDetailsController = detailController.GetAll();
            //detailController.Add(null);
            //detailController.Delete(24);
            //var fifthDetail = detailController.GetById(9);
            //detailController.Update(null);

            //var allCarViewModels = carController.GetAll();
            //carController.Add(null);
            //carController.Delete(6);
            //var secondCar = carController.GetCarById(1);
            //carController.Update(null);

            var allManuf =  manufacturerController.GetAll();
            var mostexpensive = manufacturerService.GetMostExpensive();


            Console.ReadKey();
        }
    }
}
