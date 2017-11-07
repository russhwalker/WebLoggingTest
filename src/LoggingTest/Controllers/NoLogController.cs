using LoggingTest.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggingTest.Controllers
{
    public class NoLogController : Controller
    {
        public ActionResult GetChunk()
        {
            return PartialView();
        }
    }
}