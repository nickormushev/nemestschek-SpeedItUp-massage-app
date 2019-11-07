using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassageApplication.Database
{
    public static partial class DataProvider
    {
        public static void deleteBooking(int bookingId)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Bookings.Remove(context.Bookings.First(booking => booking.id == bookingId));
                context.SaveChanges();
            }
        }
    }
}