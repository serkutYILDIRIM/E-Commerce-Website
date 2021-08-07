using System;
using System.Linq.Expressions;
using AspNetCoreProje.Data.Models;

namespace AspNetCoreProje.Service.Interfaces
{
   public interface IUrunKategoriService : IGenericService<UrunKategori>
    {
        UrunKategori GetirFiltreile(Expression<Func<UrunKategori, bool>> filter);
    }
}
