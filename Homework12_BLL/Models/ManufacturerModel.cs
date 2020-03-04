using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_BLL.Models
{
    public class ManufacturerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable <CarModel> CarsModel { get; set; }

        public IEnumerable<DetailModel> DetailsModel { get; set;}
    }
}
