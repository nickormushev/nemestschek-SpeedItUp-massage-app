using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MassageApplication.Database
{
    public static partial class DataProvider
    {

        public static IEnumerable<Massage_Days> getLastWeekDays()
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                var massage_days = from m in context.Massage_Days
                                   orderby m.date descending
                                   select m;
                return massage_days.Take(5).ToList();
            }
        }

        public static IEnumerable<Massage_Days> getAllDays()
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                var massage_days = from m in context.Massage_Days
                                   select m;
                return massage_days.ToList();
            }
        }

        public static bool bookingValidator(Models.BookingModel bkg)
        {
            //checks if the massage slot is entered 
            if (bkg.massage_slot_id == 0) return false;
                
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                
                var massageDay = (from md in context.Massage_Days
                                   where md.id == (from ms in context.Massage_Slots where ms.id == bkg.massage_slot_id select ms.massage_day_id).FirstOrDefault()
                                  select md).FirstOrDefault();

                var massageList = from ms in context.Massage_Slots
                                  where ms.massage_day_id == massageDay.id
                                  join b in context.Bookings on ms.id equals b.massage_slot_id
                                  where b.employee_id == bkg.employee_id
                                  select new
                                  {
                                      justHere = "I live"
                                  };

                int massageCount = massageList.ToList().Count();


                
                DateTime timeCheckDown = new DateTime(massageDay.date.Year, massageDay.date.Month, massageDay.date.Day, 10, 0, 0);
                DateTime timeCheckUp = new DateTime(massageDay.date.Year, massageDay.date.Month, massageDay.date.Day, 17, 0, 0);

                if (massageCount == 0)
                {
                    return true;
                }
                else if (massageCount == 1 && DateTime.Now >= timeCheckDown && DateTime.Now <= timeCheckUp)
                {
                    return true;
                }
                else
                {
                    return false;
                }
         }
            
        }

        public static IEnumerable<Massage_Days> getlastDay()
        {
            using (Massage_BookingEntities context = new Massage_BookingEntities())
            {
                var massage_days = from m in context.Massage_Days
                                   orderby m.date

                                   select m;
                return massage_days.ToList();
            }
        }

        //public static string getMasseuseName(DateTime massageDay)
        //{
        //    using (Massage_BookingEntities context = new Massage_BookingEntities())
        //    {
        //        var masseuseName = from m in context.Massage_Days
        //                           where m.date == massageDay
        //                           select m.masseuse;
                                 
        //        return masseuseName.FirstOrDefault();
        //    }
        //}

        public static void refreshWeekInDB(IEnumerable<DateTime> weekDays)
        {
            try
            {
                using (Massage_BookingEntities context = new Massage_BookingEntities())
                {
                    string[] hours = { "10:00", "10:20", "10:40", "11:00", "11:20", "11:40", "12:00", "12:20", "12:40", "13:00", "13:20", "13:40", "14:00", "14:20", "14:40", "15:00", "15:20", "15:40", "16:00", "16:20", "16:40" };
                    string[] masseuseNames = { "Ani", "Ani", "Stefi", "Stefi", "Ani" };

                    for (var day  = 0; day < weekDays.Count(); day++)
                    {
                        Massage_Days newDay = new Massage_Days()
                        {
                            date = weekDays.ElementAt(day),
                            masseuse = masseuseNames[day]
                        };
                        context.Massage_Days.Add(newDay);
                        context.SaveChanges();

                        foreach (var hour in hours)
                        {
                            Massage_Slots massageSlot = new Massage_Slots()
                            {
                                massage_day_id = newDay.id,
                                start_hour = DateTime.Parse(hour)
                            };
                            context.Massage_Slots.Add(massageSlot);
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public static Dictionary<int, IEnumerable<Massage_Slots>> getAvailableHours()
        {
            IEnumerable<Massage_Days> msgDay = getLastWeekDays();

            Dictionary<int, IEnumerable<Massage_Slots>> massageSlots = new Dictionary<int, IEnumerable<Massage_Slots>>();
            using (Massage_BookingEntities context = new Massage_BookingEntities()) {
                foreach (var day in msgDay) {

                    IEnumerable<int> bookedMassageDayId = from n in context.Bookings
                                             select n.massage_slot_id;

                    var massage_hours = from m in context.Massage_Slots
                                        //join n in context.Bookings on m.id equals n.massage_slot_id
                                        where m.massage_day_id == day.id && !bookedMassageDayId.Contains(m.id)
                                        select m;
                        massageSlots.Add(day.id, massage_hours.ToList());
                }

                return massageSlots;
            }
        }

    }
}