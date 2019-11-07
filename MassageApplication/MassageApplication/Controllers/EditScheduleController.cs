using MassageApplication.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassageApplication.Controllers
{
    public class EditScheduleController : Controller
    {

        // GET: EditSchedule
        public ActionResult Index()
        {
            ViewData["days"] = DataProvider.getLastWeekDays().Reverse();
            //ViewData["dict"] = DataProvider.getAvailableHours();

            return View();
        }

        public ActionResult UpdateMasseuse(int dayId, string newMasseuseName)
        {
            DataProvider.changeMasseuseName(dayId, newMasseuseName);
            return Redirect("Index"); 
        }

        public ActionResult DummyReserve(int dayId, string newMasseuseName)
        {
            DataProvider.changeMasseuseName(dayId, newMasseuseName);
            return Redirect("Index");
        }

    }
}