using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoKaNaShop.Model.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "Không để trống!")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "Mật khẩu phải ít nhất 8 ký tự!")]
        [Required(ErrorMessage = "Không để trống!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Không để trống!")]
        public string FullName { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Không để trống!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email nhập sai. Mời nhập lại! Ví dụ example@gmail.com")]
        [DataType(DataType.Password, ErrorMessage = "Địa chỉ Email phải trùng với Username")]
        public string Email { get; set; }

        public string Photo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}
