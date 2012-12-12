﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWorm.Models;
using BookWorm.Models.Validations;

namespace BookWorm.ViewModels
{
    public class BookInformation
    {
        public Book Book { get; set; }

        public BookInformation(Book book)
        {
            this.Book = book;
        }
        public BookInformation()
        {
        }

        public SelectList ValidLanguages()
        {
            return new SelectList(new ValidLanguage().ValidLanguages);
        }
    }
}