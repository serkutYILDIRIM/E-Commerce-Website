using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProje.Data.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Ad { get; set; }

        public List<UrunKategori> UrunKategoriler { get; set; }
    }
}
