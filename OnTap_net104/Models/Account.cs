using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnTap_net104.Models
{
    public class Account
    {
        // data anotation Validate cho phep chung ta validate du lieu ngay tu Models
        [Required]
        [StringLength(450, MinimumLength =10,ErrorMessage ="Đội dài username phải từ 10 đến 256")]
        public string Username { get; set; }
        [Required]
        [StringLength(450, MinimumLength = 10, ErrorMessage = "Đội dài username phải từ 10 đến 256")]
        public string Password { get; set; }
        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$",ErrorMessage = "Số điện thoại phải đúng format và có 10 chữ số")]
        public string PhongeNumber { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        public virtual List<Bill> Bills { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
