using System.Collections.Generic;

namespace Homework12_BLL.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailModel> Details { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
    }
}
