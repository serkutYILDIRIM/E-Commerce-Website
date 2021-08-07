using AspNetCoreProje.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUrunService _urunService;
        private readonly ISepetService _sepetService;
        public HomeController(IUrunService urunService, SignInManager<AppUser> signInManager, ISepetService sepetService)
        {
            _sepetService = sepetService;
            _signInManager = signInManager;
            _urunService = urunService;
        }
        public IActionResult Index(int? kategoriId)
        {
            ViewBag.KategoriId = kategoriId;
            return View();
        }
        public IActionResult UrunDetay(int id)
        {
            return View(_urunService.GetirIdIle(id));
        }
        public IActionResult GirisYap()
        {
            return View(new KullaniciGirisModel());
        }
        [HttpPost]
        public IActionResult GirisYap(KullaniciGirisModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = _signInManager.PasswordSignInAsync(model.KullaniciAd, model.Sifre, model.BeniHatirla, false).Result; //False vermemizin sebebi, kullanıcı adı veya şifre üst üste hatalı girilirse sistemin kitlenmemesi içindir.True yaparsak default olarak 5 dk boyunca tekrar giriş yapılmaz.

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");

            }

            return View(model);
        }
        public IActionResult Sepet()
        {
            return View(_sepetService.GetirSepettekiUrunler());
        }
        public IActionResult SepettenCikar (int id)
        {
            var cikarilacakUrun = _urunService.GetirIdIle(id);
            _sepetService.SepettenCikart(cikarilacakUrun);

            return RedirectToAction("Sepet");
        }
        public IActionResult SepetiBosalt(decimal fiyat)
        {
            _sepetService.SepetiBosalt();
            return RedirectToAction("Tesekkur", new { fiyat = fiyat});
        }
        public IActionResult Tesekkur(decimal fiyat)
        {
            ViewBag.Fiyat = fiyat;
            return View();
        }
        public IActionResult EkleSepet (int id)
        {
            var urun = _urunService.GetirIdIle(id);
            _sepetService.SepeteEkle(urun);
            TempData["bildirim"] = "Ürün sepete eklendi";

            return RedirectToAction("Index");
        }
        public IActionResult NotFound (int code)
        {
            ViewBag.Code = code;
            return View();
        }
        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(LogLevel.Error, $"\nHatanın Gerçekleştiği Yer:{errorInfo.Path} \nHata mesajı: {errorInfo.Error.Message}\nStackTrace:{errorInfo.Error.StackTrace}");

            return View();
        }
    }
}
