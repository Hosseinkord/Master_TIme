using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MasterLesson
    {
        [Key]
        public int MasterLessonId { get; set; }

        [Display(Name = "کد استاد")]
        public int MasterCode { get; set; }

        [Display(Name = "کد درس")]
        public int LessonCode { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "اولویت")]
        public int Prefer { get; set; }

        public Lesson Lesson { get; set; }
        public Master Master { get; set; }
    }
}
