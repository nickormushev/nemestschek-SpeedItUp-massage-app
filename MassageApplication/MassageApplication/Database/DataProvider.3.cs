using MassageApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace MassageApplication.Database
{
    public static partial class DataProvider
    {
        public static object DbFucntions { get; private set; }

        // allows the massuesse to change the attendancy status of the employee 
        public static void changeAttendancyStatusToTrue(int bookingID)
        {
            using(Massage_BookingEntities context = new Massage_BookingEntities())
            {
               context.Bookings.Find(bookingID).has_attended = true;
                context.SaveChanges();
            }
        }

        public static void changeAttendancyStatusToFalse(int bookingID)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Bookings.Find(bookingID).has_attended = false;
                context.SaveChanges();
            }
        }

        public static IEnumerable<MassageInfoModel> dailyStatistics()
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                DateTime time = System.DateTime.Now;
                var massage_slot = (from md in context.Massage_Days
                                   join ms in context.Massage_Slots on md.id equals ms.massage_day_id
                                   join b in context.Bookings on ms.id equals b.massage_slot_id
                                   join e in context.Employees on b.employee_id equals e.id
                                   where SqlFunctions.DateDiff("dayofyear", time, md.date) == 0
                                   select new MassageInfoModel() {
                                       startHour = ms.start_hour,
                                       name = e.name,
                                       phone = b.phone,
                                       hasAttended = b.has_attended,
                                       date = md.date,
                                       bookId = b.id
                                   });

                
                return massage_slot.OrderBy(s => s.startHour).ToList();
     
            }
        }


        //allows the admin to change the payment status of the employee
        public static void changePaymentStatus(int bookingID)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Bookings.Find(bookingID).has_paid = true;
                context.SaveChanges();
            }
        }

        public static void changeMasseuseName(int dayId, string name)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Massage_Days.Find(dayId).masseuse = name;
                context.SaveChanges();
            }
        }

    }
}