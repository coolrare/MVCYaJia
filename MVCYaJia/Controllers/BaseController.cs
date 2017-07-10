﻿using MVCYaJia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCYaJia.Controllers
{
    public abstract class BaseController : Controller
    {
        public ProductRepository repo = RepositoryHelper.GetProductRepository();

        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
        }
    }
}