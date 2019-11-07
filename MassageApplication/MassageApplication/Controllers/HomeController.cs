using MassageApplication.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//BOOK BUTTON TEST QUERY

//select d.date as 'date', s.start_hour as 'hour', emp.name as 'name'
//from bookings as b
//    join Massage_Slots as s on b.massage_slot_id = s.id

//    join Massage_Days as d on s.massage_day_id = d.id

//    join Employees as emp on emp.id = b.employee_id

//    order by date, hour

namespace MassageApplication.Controllers
{
   
    public class HomeController : Controller
    {
        //1 is TRUE ; 0 is FALSE; 2 is nothing
        static int result = 2;

        public HomeController()
        {
            ViewData["emp"] = DataProvider.getAllEmployees();
            ViewData["days"] = DataProvider.getLastWeekDays().Reverse();
            ViewData["dict"] = DataProvider.getAvailableHours();
        }
        // POST: Home
        public ActionResult Index()
        {
            ViewData["booked"] = result;
            result = 2;
            return View(new Models.BookingModel());
        }

        [HttpPost]
        public ActionResult Index(Models.BookingModel model)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            if (DataProvider.bookingValidator(model) && ModelState.IsValid)
            {
                Booking book = new Booking();
                book.employee_id = model.employee_id;
                book.massage_slot_id = model.massage_slot_id;
                book.phone = model.phone;
                book.has_attended = false;
                book.has_paid = false;

                DataProvider.addBooking(book);

                
                //the booking is made
                result = 1;
            }
            else
            {
                //booking not made
                result = 0;
                ViewData["booked"] = result;
                return View(model);
            }

            return Redirect(url);
        }
    }
}
