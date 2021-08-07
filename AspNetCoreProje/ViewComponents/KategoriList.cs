using Microsoft.AspNetCore.Mvc;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.ViewComponents
{
    public class KategoriList : ViewComponent
    {
        private readonly IKategoriService _kategoriService;
        public KategoriList(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_kategoriService.GetirHepsi());
        }
    }
}
