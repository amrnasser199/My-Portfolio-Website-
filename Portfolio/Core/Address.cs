using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Address:MyEntityBase
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }
}
