using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public  class MAHe
    {

        [Key]
        public int MAHeId { get; set; }

        [Display(Name = "شماره استاد")]
        public int MasterCode { get; set; }

        [Display(Name = "تعداد واحد مجاز")]
        public int NumLesson { get; set; }
    }
}
