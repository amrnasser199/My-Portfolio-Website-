using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Portfolio_Item:MyEntityBase
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
