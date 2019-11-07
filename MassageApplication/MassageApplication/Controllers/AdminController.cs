using MassageApplication.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassageApplication.Controllers
{
    public class AdminController : Controller
    {
        //1 is TRUE ; 0 is FALSE; 2 is nothing
        public static int result = 2;
       
        
        // GET: Admin_Stat_
        public ActionResult Index()
        {
            ViewData["booked"] = result;
            result = 2;
            return View();
        }

        
        public ActionResult updateDates()
        {
            string url = Request.UrlReferrer.AbsolutePath;

            string today = DateTime.Today.DayOfWeek.ToString().ToLower();
            string[] lastWeekDays = { "friday", "saturday", "sunday" };
            if(Array.Exists(lastWeekDays, element => element == today))
            {
                updateWeek(0);
            }
            else
            {
                updateWeek(7);
            }
            return Redirect(url);
        }


        public ActionResult dummyFunc()
        {
           return Content("Dummy");
        }

        //updates dates and times in the DB based on the time the function is called
        private void updateWeek(int plusDays = 0)
        {

            DateTime startOfWeek = DateTime.Today.AddDays(
            (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
            (int)DateTime.Today.DayOfWeek);
            startOfWeek.AddDays(plusDays);

            string result = string.Join("," + Environment.NewLine, Enumerable
             .Range(0, 5)
             .Select(i => startOfWeek
                .AddDays(i)
                .ToString("dd-MM-yyyy")));


            IList<string> weekDays = result.Split(',').ToList();

            List<DateTime> dates = new List<DateTime>();
            foreach (var date in weekDays)
            {
                DateTime myDateTime = DateTime.Parse(date, CultureInfo.CurrentCulture,
                                     DateTimeStyles.NoCurrentDateDefault);
                dates.Add(myDateTime);
            }
            try
            {
                DataProvider.refreshWeekInDB(dates);
                AdminController.result = 1;
            }
            catch //(DbUpdateException ex)
            {
                AdminController.result = 0;
            }
        }
    }
}