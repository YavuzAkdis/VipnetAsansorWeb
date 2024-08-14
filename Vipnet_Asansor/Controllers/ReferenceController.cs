using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class ReferenceController : Controller
    {
        ReferenceManager referenceManager = new ReferenceManager(new EfReferenceDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Reference Listesi";

            var values = referenceManager.TGetList();
            return View(values);
        }

        // Reference Ekle
        [HttpGet]
        public IActionResult AddReference()
        {
            ViewBag.d1 = "Reference Ekle";

            return View();
        }


      


        [HttpPost]
        public IActionResult AddReference(Reference reference, IFormFile Image_File)
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
                reference.ImageUrl = yeniisim;
            }


            referenceManager.TAdd(reference);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult AddReference(Reference reference)
        //{
        //    referenceManager.TAdd(reference);
        //    return RedirectToAction("Index");
        //}


        // Reference Sil
        public IActionResult DeleteReference(int id)
        {
            var values = referenceManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                referenceManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }

        //public IActionResult DeleteReference(int id)
        //{
        //    var values = referenceManager.GetById(id);
        //    referenceManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}
        // Reference Güncelle
        [HttpGet]
        public IActionResult EditReference(int id)
        {
            ViewBag.d1 = "Reference Güncelleme";
            var values = referenceManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditReference(Reference reference, IFormFile Image_File)
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
                reference.ImageUrl = yeniisim;
            }


            ViewBag.d1 = "Reference Güncelleme";
            if (ModelState.IsValid)
            {
                referenceManager.TUpdate(reference);
                return RedirectToAction("Index");
            }
            return View(reference);
        }

        //[HttpPost]
        //public IActionResult EditReference(Reference reference)
        //{
        //    ViewBag.d1 = "Reference Güncelleme";
        //    if (ModelState.IsValid)
        //    {
        //        referenceManager.TUpdate(reference);
        //        return RedirectToAction("Index");
        //    }
        //    return View(reference);
        //}
    }
}
