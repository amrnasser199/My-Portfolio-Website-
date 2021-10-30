using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Owner:MyEntityBase
    {
        public string FullName { get; set; }
        public string Profile { get; set; }
        public string AvatarImage { get; set; }
        public Address Address { get; set; }

    }
}
