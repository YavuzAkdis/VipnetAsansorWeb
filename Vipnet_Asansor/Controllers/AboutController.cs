

//ABOUT EKLE SİL GÜNCELLE

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "About Listesi";

            var values = aboutManager.TGetList();
            return View(values);
        }

        // About Ekle
        [HttpGet]
        public IActionResult AddAbout()
        {
            ViewBag.d1 = "About Ekle";

            return View();
        }
        [HttpPost]

        public IActionResult AddAbout(About about, IFormFile Image_File)
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
                about.ImageUrl = yeniisim;
            }




            aboutManager.TAdd(about);
            return RedirectToAction("Index");
        }
      
        // About Sil

        public IActionResult DeleteAbout(int id)
        {
            var values = aboutManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                aboutManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }


        // About Güncelle
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            ViewBag.d1 = "About Güncelleme";
            var values = aboutManager.GetById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult EditAbout(About about, IFormFile Image_File)
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
                about.ImageUrl = yeniisim;
            }




            ViewBag.d1 = "About Güncelleme";
            if (ModelState.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index");
            }
            return View(about);
        }
      
    }
}
