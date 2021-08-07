using System.Collections.Generic;
using AspNetCoreProje.Data.Models;

namespace AspNetCoreProje.Service.Interfaces
{
    public interface ISepetService
    {
        void SepeteEkle(Urun urun);
        void SepettenCikart(Urun urun);
        List<Urun> GetirSepettekiUrunler();
        void SepetiBosalt();
    }
}
