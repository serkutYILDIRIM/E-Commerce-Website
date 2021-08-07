using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProje.ViewModels
{
    public class UrunGuncelleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string Ad { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Fiyat 0 dan yüksek olmalıdır.")]
        public decimal Fiyat { get; set; }
        public IFormFile Resim { get; set; }
    }
}
