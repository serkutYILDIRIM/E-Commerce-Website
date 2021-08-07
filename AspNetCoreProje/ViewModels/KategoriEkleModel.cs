using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProje.ViewModels
{
    public class KategoriEkleModel
    {
        [Required(ErrorMessage ="Ad alanı boş bırakılamaz")]
        public string Ad { get; set; }
    }
}
