using Microsoft.AspNetCore.Mvc;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.ViewComponents
{
    public class UrunList : ViewComponent
    {
       private readonly IUrunService _urunService;
        public UrunList(IUrunService urunService)
        {
            _urunService = urunService;
        }
        public IViewComponentResult Invoke(int? kategoriId)
        {
            if (kategoriId.HasValue)
            {
                return View(_urunService.GetirKategoriIdile((int)kategoriId));
            }
            return View(_urunService.GetirHepsi());
        }
    }
}
