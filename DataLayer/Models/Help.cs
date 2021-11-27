using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Help
    {
        [Key]
        public int ClassId { get; set; }
        [Display(Name = "کد روز")]
        public int DI { get; set; }
        [Display(Name = "استاد")]
        public int MC { get; set; }
        [Display(Name = "وضعیت")]
        public int ST { get; set; }
    }
}
