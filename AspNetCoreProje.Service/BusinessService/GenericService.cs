using System.Collections.Generic;
using System.Linq;
using AspNetCoreProje.Data;

namespace AspNetCoreProje.Service.BusinessService
{
    public class GenericService<Tablo> where Tablo:class,new()
    {
        private readonly AspNetCoreContext context = new AspNetCoreContext();
        public void Ekle (Tablo tablo)
        {
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }
        public void Guncelle (Tablo tablo)
        {
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }
        public void Sil (Tablo tablo)
        {
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }
        public List<Tablo> GetirHepsi()
        {
            return context.Set<Tablo>().ToList();
        }
        public Tablo GetirIdIle(int id)
        {
            return context.Set<Tablo>().Find(id);
        }
    }
}
