using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="مقدار ورودی اشتباه است!")]
        public int UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "مقدار ورودی اشتباه است!")]
        public int PassWord { get; set; }

        [Display(Name = "نقش کاربری")]
        [Required(ErrorMessage = "مقدار ورودی اشتباه است!")]
        public int Role { get; set; }

    }
}
