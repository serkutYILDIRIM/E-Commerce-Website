using System.Collections.Generic;
using System.Linq;
using AspNetCoreProje.Data;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.Service.BusinessService
{
    public class UrunService : GenericService<Urun>, IUrunService
    {
        private readonly IUrunKategoriService _urunKategoriService;
        public UrunService(IUrunKategoriService urunKategoriService)
        {
            _urunKategoriService = urunKategoriService;
        }
        public List<Kategori> GetKategoriler(int urunId)
        {
            using var context = new AspNetCoreContext();
            return context.Urunler.Join(context.UrunKategoriler, urun => urun.Id, urunKategori => urunKategori.UrunId, (u, uc) => new
            {
                urun = u,
                urunKategori = uc
            }).Join(context.Kategoriler, iki => iki.urunKategori.KategoriId, kategori => kategori.Id, (uc, k) => new
            {
                urun = uc.urun,
                kategori = k,
                urunKategori = uc.urunKategori
            }).Where(I => I.urun.Id == urunId).Select(I => new Kategori
            {
                Ad = I.kategori.Ad,
                Id = I.kategori.Id
            }).ToList();
        }

        public void SilKategori(UrunKategori urunKategori)
        {
            var kontrolKayit = _urunKategoriService.GetirFiltreile(I => I.KategoriId == urunKategori.KategoriId && I.UrunId == urunKategori.UrunId);

            if (kontrolKayit != null)
            {
                _urunKategoriService.Sil(kontrolKayit);
            }
        }
        public void EkleKategori(UrunKategori urunKategori)
        {
            var kontrolKayit = _urunKategoriService.GetirFiltreile(I => I.KategoriId == urunKategori.KategoriId && I.UrunId == urunKategori.UrunId);

            if (kontrolKayit == null)
            {
                _urunKategoriService.Ekle(urunKategori);
            }
        }

        public List<Urun> GetirKategoriIdile(int kategoriId)
        {
            using var context = new AspNetCoreContext();

            return context.Urunler.Join(context.UrunKategoriler, u => u.Id, uc => uc.UrunId, (urun, urunKategori) => new
            {
                Urun = urun,
                UrunKategori = urunKategori
            }).Where(I => I.UrunKategori.KategoriId == kategoriId).Select(I => new Urun
            {
                Id = I.Urun.Id,
                Ad = I.Urun.Ad,
                Fiyat = I.Urun.Fiyat,
                Resim = I.Urun.Resim
            }).ToList();
        }
    }
}
