using System;
using System.Linq;
using System.Linq.Expressions;
using AspNetCoreProje.Data;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.Service.BusinessService
{
    public class UrunKategoriService : GenericService<UrunKategori>, IUrunKategoriService
    {
        public UrunKategori GetirFiltreile(Expression<Func<UrunKategori, bool>> filter)
        {
            using var context = new AspNetCoreContext();

            return context.UrunKategoriler.FirstOrDefault(filter);
        }
    }
}
