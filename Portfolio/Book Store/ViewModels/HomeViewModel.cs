using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.ViewModels
{
    public class HomeViewModel
    {
        public Owner owner { get; set; }
        public List<Portfolio_Item> Portfolio_Items { get; set; }
    }
}
