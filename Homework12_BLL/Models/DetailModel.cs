
using Homework12_Common;

namespace Homework12_BLL.Models
{
    public class DetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public int CarId { get; set; }
        public CarModel CarModel { get; set; }

        public DetailTypeEnum Type { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
    }
}
