using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.Entities
{
    public class Person
    {
        public string LastName { get; set; }
        public Pet[] Pets { get; set; }
    }
}
