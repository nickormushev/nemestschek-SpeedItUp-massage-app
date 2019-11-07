using MassageApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassageApplication.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statics
        public ActionResult Index()
        {

            Dictionary<int, IEnumerable<Massage_Slots>> hoursDict = DataProvider.getAvailableHours();
            //return Content(hoursDict[291].ElementAt(0).start_hour.Hour.ToString());
            return View(hoursDict);
        }
        
        public ActionResult getBookings()
        {
            return View();
        }

    }
}