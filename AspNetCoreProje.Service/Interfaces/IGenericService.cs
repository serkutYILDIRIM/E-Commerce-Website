using System.Collections.Generic;

namespace AspNetCoreProje.Service.Interfaces
{
    public interface IGenericService<Tablo> where Tablo :class, new ()
    {
        void Ekle(Tablo tablo);
        void Sil(Tablo tablo);
        void Guncelle(Tablo tablo);
        public List<Tablo> GetirHepsi();
        public Tablo GetirIdIle(int id);
    }
}
