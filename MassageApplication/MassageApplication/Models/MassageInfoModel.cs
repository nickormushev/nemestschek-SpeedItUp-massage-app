using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassageApplication.Models
{
    public class MassageInfoModel
    {
        public DateTime startHour { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public bool? hasAttended { get; set; }
        
        public int bookId { get; set; }

        public DateTime date { get; set; }
        public MassageInfoModel()
        {

        }

        public MassageInfoModel(DateTime _startHour, string _name, string _phone, bool? _attended, DateTime _date, int _bookId)
        {
            startHour = _startHour;
            name = _name;
            phone = _phone;
            hasAttended = _attended;
            date = _date;
            bookId = _bookId;
        }
    }
}