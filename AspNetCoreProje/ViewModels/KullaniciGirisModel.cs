using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProje.ViewModels
{
    public class KullaniciGirisModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        public string KullaniciAd { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Sifre { get; set; }
        public bool BeniHatirla { get; set; }
    }
}
