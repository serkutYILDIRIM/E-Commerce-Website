using AspNetCoreProje.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUrunService _urunService;
        private readonly IKategoriService _kategoriService;
        public HomeController(IUrunService urunService, IKategoriService kategoriService, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _kategoriService = kategoriService;
            _urunService = urunService;
        }
        public IActionResult Index()
        {
            return View(_urunService.GetirHepsi());
        }
        public IActionResult Ekle()
        {
            return View(new UrunEkleModel());
        }
        [HttpPost]
        public IActionResult Ekle(UrunEkleModel model)
        {
            if (ModelState.IsValid)
            {
                Urun urun = new Urun();
                if (model.Resim != null)
                {
                    var uzanti = Path.GetExtension(model.Resim.FileName);
                    var yeniResimAd = Guid.NewGuid() + uzanti;

                    var yuklenecekYer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniResimAd);

                    var stream = new FileStream(yuklenecekYer, FileMode.Create);
                    model.Resim.CopyTo(stream);

                    urun.Resim = yeniResimAd;
                }

                urun.Ad = model.Ad;
                urun.Fiyat = model.Fiyat;

                _urunService.Ekle(urun);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Guncelle(int id)
        {
            var gelenUrun = _urunService.GetirIdIle(id);

            UrunGuncelleModel model = new UrunGuncelleModel
            {
                Ad = gelenUrun.Ad,
                Fiyat = gelenUrun.Fiyat,
                Id = gelenUrun.Id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Guncelle(UrunGuncelleModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekUrun = _urunService.GetirIdIle(model.Id);
                if (model.Resim != null)
                {
                    var uzanti = Path.GetExtension(model.Resim.FileName);
                    var yeniResimAd = Guid.NewGuid() + uzanti;

                    var yuklenecekYer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniResimAd);

                    var stream = new FileStream(yuklenecekYer, FileMode.Create);
                    model.Resim.CopyTo(stream);
                    guncellenecekUrun.Resim = yeniResimAd;
                }

                guncellenecekUrun.Ad = model.Ad;
                guncellenecekUrun.Fiyat = model.Fiyat;

                _urunService.Guncelle(guncellenecekUrun);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Sil(int id)
        {
            _urunService.Sil(new Urun { Id = id });

            return RedirectToAction("Index");
        }
        public IActionResult AtaKategori(int id)
        {
            var uruneAitKategoriler = _urunService.GetKategoriler(id).Select(I => I.Ad);
            var kategoriler = _kategoriService.GetirHepsi();

            TempData["UrunId"] = id;

            List<KategoriAtaModel> list = new List<KategoriAtaModel>();

            foreach (var item in kategoriler)
            {
                KategoriAtaModel model = new KategoriAtaModel();
                model.KategoriId = item.Id;
                model.KategoriAd = item.Ad;
                model.VarMi = uruneAitKategoriler.Contains(item.Ad);

                list.Add(model);
            }

            return View(list);
        }
        [HttpPost]
        public IActionResult AtaKategori(List<KategoriAtaModel> list)
        {
            int urunId = (int)TempData["UrunId"];

            foreach(var item in list)
            {
                if (item.VarMi)
                {
                    _urunService.EkleKategori(new UrunKategori
                    {
                        KategoriId = item.KategoriId,
                        UrunId = urunId
                    });
                }
                else
                {
                    _urunService.SilKategori(new UrunKategori
                    {
                        KategoriId = item.KategoriId,
                        UrunId = urunId
                    });
                }
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CikisYapAsync()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
