using System.Collections.Generic;
using AspNetCoreProje.Data.Models;

namespace AspNetCoreProje.Service.Interfaces
{
    public interface IUrunService : IGenericService<Urun>
    {
        List<Kategori> GetKategoriler(int urunId);
        void EkleKategori(UrunKategori urunKategori);
        void SilKategori(UrunKategori urunKategori);
        List<Urun> GetirKategoriIdile(int kategoriId);
    }
}
