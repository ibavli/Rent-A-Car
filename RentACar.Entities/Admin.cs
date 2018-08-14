using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class Admin
    {
        public Admin()
        {
            AdminId = Guid.NewGuid();
        }

        [Key]
        public Guid AdminId { get; set; }

        [DisplayName("Kullanıcı Adı"),
           MaxLength(15, ErrorMessage = "{0} bilgisi {1} karakterden uzun olamaz !"),
           Required(ErrorMessage = "Lütfen {0} bilgisini giriniz")]
        public string UserName { get; set; }

        [DisplayName("Ad"),
           MaxLength(40, ErrorMessage = "{0} bilgisi {1} karakterden uzun olamaz !"),
           Required(ErrorMessage = "Lütfen {0} bilgisini giriniz")]
        public string Name { get; set; }

        [DisplayName("Soyad"),
           MaxLength(40, ErrorMessage = "{0} bilgisi {1} karakterden uzun olamaz !"),
           Required(ErrorMessage = "Lütfen {0} bilgisini giriniz")]
        public string Surname { get; set; }

        [DisplayName("E posta"),
            MaxLength(50, ErrorMessage = "{0} maximum {1} karakter olmalıdır"),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string Mail { get; set; }

        [DisplayName("Telefon"),
            MaxLength(18, ErrorMessage = "{0} maximum {1} karakter olmalıdır")]
        public string Mobile { get; set; }

        public string Salt { get; set; }

        [DisplayName("Parola"),
            Required(ErrorMessage = "Lütfen {0} bilgisini giriniz")]
        public string Password { get; set; }

        public string PhotoUrl { get; set; }

        public int PasswordEnteredIncorrectly { get; set; }

        public bool IsAccountActive { get; set; }
    }
}
