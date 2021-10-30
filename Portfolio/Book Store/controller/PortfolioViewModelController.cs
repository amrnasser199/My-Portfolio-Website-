 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core;
using Infrastructure;
using Core.Interfaces;
using Book_Store.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Book_Store.controller
{
    public class PortfolioViewModelController : Controller
    {
        private readonly IUnitOfWork<Portfolio_Item> _portfolio;
        private readonly IHostingEnvironment _hosting;

        public PortfolioViewModelController(IUnitOfWork<Portfolio_Item> portfolio,IHostingEnvironment hosting)
        {
          _portfolio = portfolio;
            _hosting = hosting;
        }

        // GET: PortfolioViewModel
        public IActionResult Index()
        {
            return View(_portfolio.entity.GetAll());
        }

        // GET: PortfolioViewModel/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio_Item = _portfolio.entity.GetByID(id);
            if (portfolio_Item == null)
            {
                return NotFound();
            }

            return View(portfolio_Item);
        }

        // GET: PortfolioViewModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioViewModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.File!=null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullpath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullpath, FileMode.Create));

                }
                Portfolio_Item portfolio_Item = new Portfolio_Item
                {
                    ProjectName=model.ProjectName,
                    Description = model.Description,
                    ImageUrl=model.File.FileName
                };
                _portfolio.entity.Insert(portfolio_Item);
                _portfolio.save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortfolioViewModel/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio_Item = _portfolio.entity.GetByID(id);
            if (portfolio_Item == null)
            {
                return NotFound();
            }
            PortfolioViewModel portfolioViewModel = new PortfolioViewModel
            {
                Id=portfolio_Item.Id,
                ProjectName=portfolio_Item.ProjectName,
                Description=portfolio_Item.Description,
                ImageUrl=portfolio_Item.ImageUrl
            };
            return View(portfolioViewModel);
        }

        // POST: PortfolioViewModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,PortfolioViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullpath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }
                    Portfolio_Item portfolio_Item = new Portfolio_Item
                    {
                        Id=model.Id,
                        ProjectName = model.ProjectName,
                        Description = model.Description,
                        ImageUrl = model.File.FileName
                    };
                    _portfolio.entity.Update(portfolio_Item);
                    _portfolio.save();
                
            }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Portfolio_ItemExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortfolioViewModel/Delete/5
        public  IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio_Item = _portfolio.entity.GetByID(id);
            if (portfolio_Item == null)
            {
                return NotFound();
            }

            return View(portfolio_Item);
        }

        // POST: PortfolioViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
             _portfolio.entity.Delete(id);
            _portfolio.save();

            return RedirectToAction(nameof(Index));
        }

        private bool Portfolio_ItemExists(Guid id)
        {
            return _portfolio.entity.GetAll().Any(e => e.Id == id);
        }
    }
}
