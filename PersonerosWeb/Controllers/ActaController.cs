﻿using PersonerosWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    [Autenticado]
    public class ActaController : Controller
    {
        // GET: Acta
        public ActionResult Index()
        {
            return View();
        }
    }
}