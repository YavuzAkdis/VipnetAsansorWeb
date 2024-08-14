using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class MasterBrandController : Controller
    {
        MasterBrandManager masterBrandManager = new MasterBrandManager(new EfMasterBrandDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "AnaMarka Listesi";

            var values = masterBrandManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


  
        // AnaMarka Ekle
        [HttpGet]
        public IActionResult AddMasterBrand()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "AnaMarka Ekle";

            return View();
        }
        //[HttpPost]
        //public IActionResult AddMasterBrand(MasterBrand masterbrand)
        //{
        //    masterBrandManager.TAdd(masterbrand);
        //    return RedirectToAction("Index");
        //}

        public IActionResult AddMasterBrand(MasterBrand masterbrand, IFormFile Image_File, string language)
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
                masterbrand.ImageUrl = yeniisim;
            }


            masterbrand.Language = language; // Dil bilgisini ata

            masterBrandManager.TAdd(masterbrand);
            return RedirectToAction("Index");
        }


        // AnaMarka Sil
        //public IActionResult DeleteMasterBrand(int id)
        //{
        //    var values = masterBrandManager.GetById(id);
        //    masterBrandManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}

        public IActionResult DeleteMasterBrand(int id)
        {
            var values = masterBrandManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                masterBrandManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }

        // AnaMarka Güncelle
        [HttpGet]
        public IActionResult EditMasterBrand(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "AnaMarka Güncelleme";
            var values = masterBrandManager.GetById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult EditMasterBrand(MasterBrand masterbrand, IFormFile Image_File, string language)
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
                masterbrand.ImageUrl = yeniisim;
            }


            masterbrand.Language = language; // Dil bilgisini ata

            ViewBag.d1 = "AnaMarka Güncelleme";
            if (ModelState.IsValid)
            {
                masterBrandManager.TUpdate(masterbrand);
                return RedirectToAction("Index");
            }
            return View(masterbrand);
        }
        //public IActionResult EditMasterBrand(MasterBrand masterbrand)
        //{
        //    ViewBag.d1 = "AnaMarka Güncelleme";
        //    if (ModelState.IsValid)
        //    {
        //        masterBrandManager.TUpdate(masterbrand);
        //        return RedirectToAction("Index");
        //    }
        //    return View(masterbrand);
        //}
    }
}
