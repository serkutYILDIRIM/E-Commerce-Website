using System.Collections.Generic;
using AspNetCoreProje.Service.CustomExtensions;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.Interfaces;
using Microsoft.AspNetCore.Http;


namespace AspNetCoreProje.Service.BusinessService
{
    public class SepetService : ISepetService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SepetService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SepeteEkle(Urun urun)
        {
            var gelenListe = _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("sepet");

            if (gelenListe == null)
            {
                gelenListe = new List<Urun>();
                gelenListe.Add(urun);
            }
            else
            {
                gelenListe.Add(urun);
            }
            _httpContextAccessor.HttpContext.Session.SetObject("sepet", gelenListe);
        }
        public void SepettenCikart(Urun urun)
        {
            var gelenListe = _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("sepet");
            gelenListe.Remove(urun);

            _httpContextAccessor.HttpContext.Session.SetObject("sepet", gelenListe);
        }
        public List<Urun> GetirSepettekiUrunler()
        {
            return _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("sepet");
        }
        public void SepetiBosalt()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sepet");
        }
    }
}
