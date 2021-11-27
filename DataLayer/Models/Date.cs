using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Date
    {
        [Key]
        public int DateId { get; set; }
        [Required(ErrorMessage ="لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "زمان")]
        public string DateName { get; set; }

        //Navigation Property...
        public virtual ICollection<MasterDate> MasterDates { get; set; }
    }
}
