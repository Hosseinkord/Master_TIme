using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Master
    {
        [Key]
        public int MasterId { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "شماره استاد")]
        public int MasterCode { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "نام استاد")]
        public string MasterName { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "تعداد واحد مجاز")]
        public int NumLesson { get; set; }

        //Navigation Property...
        public virtual ICollection<MasterDate> MasterDates { get; set; }
        public virtual ICollection<MasterLesson> MasterLessons { get; set; }

    }
}
