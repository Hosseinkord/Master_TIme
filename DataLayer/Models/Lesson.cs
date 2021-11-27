using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "شماره درس")]
        public int LessonCode { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "گروه درس")]
        public int LessonGroup { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "نام درس")]
        public string LessonName { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "واحد درس")]
        public int Unit { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "ترم")]
        public int Term { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "امتیاز درس")]
        public int Score { get; set; }

        //Navigation Property...
        public virtual ICollection<MasterLesson> MasterLessons { get; set; }

    }
}
