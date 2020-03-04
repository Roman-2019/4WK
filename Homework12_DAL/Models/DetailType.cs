using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_DAL.Models
{
    public class DetailType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Details> Details { get; set; }
    }
}
