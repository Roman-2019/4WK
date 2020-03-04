using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_DAL.Models
{
    public class Details
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Price { get; set; }

        public int CarsId { get; set; }
        public virtual Cars Car { get; set; }

        //public int DetailTypeId { get; set; }
        //public virtual DetailType DetailType { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }
    }
}
