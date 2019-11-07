using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassageApplication.Models
{
    public class BookingModel
    {
        [Required]
        public int employee_id { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [Required]
        public int massage_slot_id { get; set; }

        public int selected_massage_day_id { get; set; }
    }
}