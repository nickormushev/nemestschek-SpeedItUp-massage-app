using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassageApplication.Database
{
    public  static partial class DataProvider
    {

        //adds a massage day to the database
        public static void addMassageDay(Massage_Days msDay)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Massage_Days.Add(msDay);
                context.SaveChanges();
            }
        }

        //adds a booking to the database 
        public static void addBooking(Booking booking)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }

        //adds a massage slot to the database
        public static void addMassageSlot(Massage_Slots msSlot)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                context.Massage_Slots.Add(msSlot);
                context.SaveChanges();
            }
        }

        //removes a massage day from the database 
        public static void removeMassageDay(int dayID)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                Massage_Days mday = context.Massage_Days.Find(dayID);
                context.Massage_Days.Remove(mday);
                context.SaveChanges();
            }
        }

        //removes a massage slot from the database
        public static void removeMassageSlot(int slotID)
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                Massage_Slots slot = context.Massage_Slots.Find(slotID);
                context.Massage_Slots.Remove(slot);
                context.SaveChanges();
            }
          
        }

        // removes a booking from the database
        public static void removeBookingSlot(int bookingID)
        {
           
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                Booking book = context.Bookings.Find(bookingID);
                context.Bookings.Remove(book);
                context.SaveChanges();
            }
        }

        public static IEnumerable<Employee> getAllEmployees()
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                var employees = from m in context.Employees
                                   select m;
                ; 
                return employees.ToList();
            }
        }




    }

    
}