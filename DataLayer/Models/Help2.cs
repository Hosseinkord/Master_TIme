using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Help2
    {
        [Key]
        public int Help2Id { get; set; }

        [Display(Name = "کد زمان")]
        public int DateId { get; set; }

        [Display(Name = "کد استاد")]
        public int MasterCode { get; set; }

        [Display(Name = "کد درس")]
        public int LessonCode { get; set; }

        [Display(Name = "امتیاز")]
        public int ScHelp { get; set; }
    }
}
