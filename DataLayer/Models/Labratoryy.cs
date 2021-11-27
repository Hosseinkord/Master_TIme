using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Labratoryy
    {
        [Key]
        public int LabratorId { get; set; }
        
        [Display(Name ="زمان ")]
        [Required(ErrorMessage ="زمان را وارد کنید")]    
        public int DateId { get; set; }

        [Display(Name = "توضیحات ")]
        public string  Labrator_description { get; set; }

        [Display(Name = "پر و خالی بودن ")]
        [Required(ErrorMessage = "انتخاب کنید.")]
        public bool Empty { get; set; }
    }
}
