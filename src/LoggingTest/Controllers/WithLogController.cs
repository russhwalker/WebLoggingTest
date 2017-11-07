﻿using LoggingTest.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggingTest.Controllers
{
    [Audit]
    public class WithLogController : Controller
    {
        public ActionResult GetChunk()
        {
            return PartialView();
        }
    }
}