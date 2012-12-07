﻿using System;
using System.Web.Mvc;
using BookWorm.Models;

namespace BookWorm.Controllers
{
    public class BooksController : Controller
    {
        private Repository _repository;

        public BooksController(Repository repository)
        {
            _repository = repository;
        }

        public BooksController()
        {
            _repository = new Repository();
        }

        public ActionResult Index(int id)
        {
            throw new NotImplementedException();
        }

        public ViewResult New()
        {
            ViewBag.Title = "Add a Book";
            return View(new Book());
        }

        [HttpPost]
        public RedirectToRouteResult New(Book book)
        {
            var createdBook = (Book) _repository.Create(book);
            TempData["flash"] = string.Format("Added {0} successfully", createdBook.Title);
            return RedirectToAction("Index", new { id = createdBook.Id });
        }
    }
}