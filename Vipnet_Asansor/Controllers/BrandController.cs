using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace Vipnet_Asansor.Controllers
{
    //[Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class BrandController : Controller
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Markalarımız Listesi";

            var values = brandManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


        // Marka Ekle
        [HttpGet]
        public IActionResult AddBrand()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Markalarımız Ekle";

            return View();
        }
        [HttpPost]

        public IActionResult AddBrand(Brand brand, IFormFile Image_File, string language)
        {
            if (Image_File != null)
            {
                // Dosya uzantısını al
                var uzanti = Path.GetExtension(Image_File.FileName);

                // Orijinal dosya adını al
                var orijinalDosyaAdi = Path.GetFileNameWithoutExtension(Image_File.FileName);

                // Benzersiz bir dosya adı oluşturmak için zaman damgası ekle
                var zamanDamgasi = DateTime.Now.ToString("HHmmss");
                var yeniisim = $"{orijinalDosyaAdi}_{zamanDamgasi}{uzanti}";

                // Dosyanın kaydedileceği yolu oluştur
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", yeniisim);

                // Dosyayı belirtilen yola kaydet
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Image_File.CopyTo(stream);
                }

                // Dosya adını modele atayın
                brand.ImageUrl = yeniisim;
            }


            brand.Language = language; // Dil bilgisini ata

            brandManager.TAdd(brand);
            return RedirectToAction("Index");
        }

        //public IActionResult AddBrand(Brand brand)
        //{
        //    brandManager.TAdd(brand);
        //    return RedirectToAction("Index");
        //}

        // Marka Sil

        public IActionResult DeleteBrand(int id)
        {
            var values = brandManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                brandManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }

        //public IActionResult DeleteBrand(int id)
        //{
        //    var values = brandManager.GetById(id);
        //    brandManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}

        // Marka Güncelle
        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Markalarımız Güncelleme";
            var values = brandManager.GetById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult EditBrand(Brand brand, IFormFile Image_File, string language)
        {
            if (Image_File != null)
            {
                // Dosya uzantısını al
                var uzanti = Path.GetExtension(Image_File.FileName);

                // Orijinal dosya adını al
                var orijinalDosyaAdi = Path.GetFileNameWithoutExtension(Image_File.FileName);

                // Benzersiz bir dosya adı oluşturmak için zaman damgası ekle
                var zamanDamgasi = DateTime.Now.ToString("HHmmss");
                var yeniisim = $"{orijinalDosyaAdi}_{zamanDamgasi}{uzanti}";

                // Dosyanın kaydedileceği yolu oluştur
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", yeniisim);

                // Dosyayı belirtilen yola kaydet
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Image_File.CopyTo(stream);
                }

                // Dosya adını modele atayın
                brand.ImageUrl = yeniisim;
            }


            brand.Language = language; // Dil bilgisini ata

            ViewBag.d1 = "Partner Güncelleme";
            if (ModelState.IsValid)
            {
                brandManager.TUpdate(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }
      
    }
}
