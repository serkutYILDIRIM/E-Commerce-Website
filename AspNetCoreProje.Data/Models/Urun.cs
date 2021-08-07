using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCoreProje.Data.Models
{
    public class Urun : IEquatable<Urun>
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Ad { get; set; }
        [MaxLength(250)]
        public string Resim { get; set; }
        public decimal Fiyat { get; set; }

        public List<UrunKategori> UrunKategoriler { get; set; }

        public bool Equals([AllowNull] Urun other)
        {
            return Id == other.Id && Ad == other.Ad && Resim == other.Resim && Fiyat == other.Fiyat;
        }
    }
}
