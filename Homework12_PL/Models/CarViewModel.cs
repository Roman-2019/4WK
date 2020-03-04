using System.Collections.Generic;

namespace Homework12_PL.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailViewModel> Details { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }
    }
}
