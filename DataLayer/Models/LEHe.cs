using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LEHe
    {
        [Key]
        public int LeHeId { get; set; }

        [Display(Name = "شماره درس")]
        public int LessonCode { get; set; }

        [Display(Name = "گروه درس")]
        public int LessonGroup { get; set; }

        [Display(Name = "واحد درس")]
        public int LUnit { get; set; }

    }
}
