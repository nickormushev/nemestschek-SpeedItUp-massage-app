using MassageApplication.Database;
using MassageApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassageApplication.Controllers
{
    public class CurrentScheduleController : Controller
    {
        // GET: CurrentSchedule
        public ActionResult Index()
        {

            IEnumerable<MassageInfoModel> model = DataProvider.dailyStatistics();
            return View(model);
        }


        public JsonResult changeStatusToAttended(string bookId)
        {
            DataProvider.changeAttendancyStatusToTrue(Int32.Parse(bookId));
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult changeStatusToUnAttended(string bookId)
        {
            DataProvider.changeAttendancyStatusToFalse(Int32.Parse(bookId));
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}