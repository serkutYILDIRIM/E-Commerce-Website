using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using AspNetCoreProje.Service.Interfaces;

namespace AspNetCoreProje.TagHelpers
{
    [HtmlTargetElement("getirKategoriAd")]
    public class KategoriAd : TagHelper
    {
        private readonly IUrunService _urunService;
        public KategoriAd(IUrunService urunService)
        {
            _urunService = urunService;
        }
        public int UrunId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var gelenKategoriler = _urunService.GetKategoriler(UrunId).Select(I => I.Ad);
            foreach (var item in gelenKategoriler)
            {
                data += item+" ";
            }
            output.Content.SetContent(data);
        }
    }
}
