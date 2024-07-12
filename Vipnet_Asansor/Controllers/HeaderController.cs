using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class HeaderController : Controller
    {
       HeaderManager headerManager = new HeaderManager(new EfHeaderDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Header Listesi";

            var values = headerManager.TGetList();
            return View(values);
        }

        // Header Ekle
        [HttpGet]
        public IActionResult AddHeader()
        {
            ViewBag.d1 = "Header Ekle";

            return View();
        }
        [HttpPost]

        public IActionResult AddHeader(Header header, IFormFile Image_File)
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
                header.ImageUrl = yeniisim;
            }




            headerManager.TAdd(header);
            return RedirectToAction("Index");
        }
        //public IActionResult AddHeader(Header header)
        //{
        //    headerManager.TAdd(header);
        //    return RedirectToAction("Index");
        //}

        // Header Sil

        public IActionResult DeleteHeader(int id)
        {
            var values = headerManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                headerManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }
        //public IActionResult DeleteHeader(int id)
        //{
        //    var values = headerManager.GetById(id);
        //    headerManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}

        // Header Güncelle
        [HttpGet]
        public IActionResult EditHeader(int id)
        {
            ViewBag.d1 = "Header Güncelleme";
            var values = headerManager.GetById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult EditHeader(Header header, IFormFile Image_File)
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
                header.ImageUrl = yeniisim;
            }




            ViewBag.d1 = "Partner Güncelleme";
            if (ModelState.IsValid)
            {
                headerManager.TUpdate(header);
                return RedirectToAction("Index");
            }
            return View(header);
        }
        //public IActionResult EditHeader(Header header)
        //{
        //    ViewBag.d1 = "Header Güncelleme";
        //    if (ModelState.IsValid)
        //    {
        //        headerManager.TUpdate(header);
        //        return RedirectToAction("Index");
        //    }

        //    // ModelState hatalarını loglama
        //    foreach (var modelState in ViewData.ModelState.Values)
        //    {
        //        foreach (var error in modelState.Errors)
        //        {
        //            Console.WriteLine(error.ErrorMessage); // veya kullanmakta olduğunuz loglama kütüphanesine loglayın
        //        }
        //    }

        //    return View(header);
        //}

    }
}
