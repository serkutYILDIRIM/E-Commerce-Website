namespace AspNetCoreProje.Data.Models
{
    public class UrunKategori
    {
        public int Id { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
