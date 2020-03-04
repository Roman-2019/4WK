
using Homework12_Common;

namespace Homework12_PL.Models
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public int CarId { get; set; }
        public CarViewModel CarViewModel { get; set; }

        public DetailTypeEnum Type { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }
    }
}
