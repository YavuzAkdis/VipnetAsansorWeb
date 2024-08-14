using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class GalleryController : Controller
    {
        GalleryManager galleryManager = new GalleryManager(new EfGalleryDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Galeri Listesi";

            var values = galleryManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }

     

        // Galeri Ekle
        [HttpGet]
        public IActionResult AddGallery()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "Galeri Ekle";

            return View();
        }
        [HttpPost]

        public IActionResult AddGallery(Gallery gallery, IFormFile Image_File, string language)
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
                gallery.ImageUrl = yeniisim;
            }


            gallery.Language = language; // Dil bilgisini ata

            galleryManager.TAdd(gallery);
            return RedirectToAction("Index");
        }

        // Header Sil

        public IActionResult DeleteGallery(int id)
        {
            var values = galleryManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                galleryManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }
    

        // Galeri Güncelle
        [HttpGet]
        public IActionResult EditGallery(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Galeri Güncelleme";
            var values = galleryManager.GetById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult EditGallery(Gallery gallery, IFormFile Image_File, string language)
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
                gallery.ImageUrl = yeniisim;
            }


            gallery.Language = language; // Dil bilgisini ata



            ViewBag.d1 = "Galeri Güncelleme";
            if (ModelState.IsValid)
            {
                galleryManager.TUpdate(gallery);
                return RedirectToAction("Index");
            }
            return View(gallery);
        }
    }
}
