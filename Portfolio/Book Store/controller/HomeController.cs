using Book_Store.ViewModels;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.controller
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<Portfolio_Item> _portofolio;

        public HomeController(IUnitOfWork<Owner> owner,IUnitOfWork<Portfolio_Item> Portofolio)
        {
           _owner = owner;
            _portofolio = Portofolio;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                owner=_owner.entity.GetAll().First(),
                Portfolio_Items=_portofolio.entity.GetAll().ToList()
            };
            return View(homeViewModel);
        }
    }
}
