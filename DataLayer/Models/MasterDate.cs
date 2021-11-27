using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MasterDate
    {
        [Key]
        public int MasterDateId { get; set; }
        [Display(Name = "کد روز")]
        public int DateId { get; set; }

        [Display(Name = "شماره استاد")]
        public int MasterCode { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "وضعیت")]
        public int Status { get; set; }

        public Date Date { get; set; }
        public Master Master { get; set; }

    }
}
