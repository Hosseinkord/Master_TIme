using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Cal_End
    {
        [Key]
        public int Cal_EndId { get; set; }

        [Display(Name = "زمان")]
        public int Time { get; set; }
        [Display(Name = "استاد")]
        public int Master { get; set; }
        [Display(Name = "درس")]
        public int Lesson { get; set; }
        [Display(Name = "اولویت")]
        public int Number { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

    }
}
