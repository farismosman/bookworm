﻿using System;
using System.Web.Mvc;
using BookWorm.Models;
using BookWorm.Repository;

namespace BookWorm.Controllers
{
    public class PagesController : Controller
    {
        private readonly Repository<StaticPage> _repository;

        public PagesController(Repository<StaticPage> repository)
        {
            _repository = repository;
        }

        public ActionResult New(StaticPage submittedStaticPage)
        {
            ViewBag.Message = string.Format("Added {0}", submittedStaticPage.Title);
            var savedPage = _repository.Create(submittedStaticPage);
            TempData["flash"] = string.Format("Added {0}", submittedStaticPage.Title);
            return RedirectToAction("index","pages", new { id=savedPage.Id}); 
        }

        public ActionResult Index(int id)
        {
            throw new NotImplementedException();
        }
    }
}