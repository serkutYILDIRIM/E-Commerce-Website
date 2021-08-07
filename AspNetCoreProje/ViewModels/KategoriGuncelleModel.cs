using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProje.ViewModels
{
    public class KategoriGuncelleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        public string Ad { get; set; }
    }
}
