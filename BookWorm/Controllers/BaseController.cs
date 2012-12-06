﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWorm.Repository;
using Raven.Client;
using Raven.Client.Document;

namespace BookWorm.Controllers
{
    public abstract class BaseController : Controller
    {
        private IDocumentSession _session;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _session = MvcApplication.Store.OpenSession();
            base.OnActionExecuting(filterContext);

        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            using (_session)
            {
                if (filterContext.Exception != null)
                    return;

                if (_session != null)
                    _session.SaveChanges();
            }
        }
    }
}
