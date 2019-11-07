using MassageApplication.Database;
using MassageApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassageApplication.Controllers
{
    public class UserDailyScheduleController : Controller
    {
        // GET: UserDailySchedule
        public ActionResult Index()
        {

            IEnumerable<MassageInfoModel> model = DataProvider.dailyStatistics();
            return View(model);
        }

        public ActionResult deleteBooking(string bookId)
        {
            DataProvider.deleteBooking(Int32.Parse(bookId));
            return RedirectToAction("Index", "UserDailySchedule");
        }

    }
}