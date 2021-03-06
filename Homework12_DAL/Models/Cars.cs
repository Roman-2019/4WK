﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_DAL.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Details> Details { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }

    }
}
