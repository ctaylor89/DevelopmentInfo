using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.Entities
{
    public class Order // Used in LinqQuery()
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public double Cost { get; set; }
    }
}
