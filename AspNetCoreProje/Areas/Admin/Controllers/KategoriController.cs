using AspNetCoreProje.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        public IActionResult Index()
        {
            return View(_kategoriService.GetirHepsi());
        }
        public IActionResult Ekle()
        {
            return View(new KategoriEkleModel());
        }
        [HttpPost]
        public IActionResult Ekle(KategoriEkleModel model)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Ekle(new Kategori
                {
                    Ad = model.Ad
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Guncelle(int id)
        {
            var guncellenecekKategori = _kategoriService.GetirIdIle(id);

            KategoriGuncelleModel model = new KategoriGuncelleModel
            {
                Id = guncellenecekKategori.Id,
                Ad = guncellenecekKategori.Ad
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Guncelle(KategoriGuncelleModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekKategori = _kategoriService.GetirIdIle(model.Id);
                guncellenecekKategori.Ad = model.Ad;

                _kategoriService.Guncelle(guncellenecekKategori);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Sil (int id)
        {
            _kategoriService.Sil(new Kategori { Id = id });

            return RedirectToAction("Index");
        }
    }
}
