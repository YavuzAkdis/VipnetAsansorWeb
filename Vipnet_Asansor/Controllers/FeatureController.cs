using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class FeatureController : Controller
    {
       FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Feature Listesi";

            var values = featureManager.TGetList();
            return View(values);
        }

        // Feature Ekle
        [HttpGet]
        public IActionResult AddFeature()
        {
            ViewBag.d1 = "Feature Ekle";

            return View();
        }
        [HttpPost]

        public IActionResult AddFeature(Feature feature, IFormFile Video_File)
        {
            if (Video_File != null)
            {
                // Dosya uzantısını al
                var uzanti = Path.GetExtension(Video_File.FileName);

                // Orijinal dosya adını al
                var orijinalDosyaAdi = Path.GetFileNameWithoutExtension(Video_File.FileName);

                // Benzersiz bir dosya adı oluşturmak için zaman damgası ekle
                var zamanDamgasi = DateTime.Now.ToString("HHmmss");
                var yeniisim = $"{orijinalDosyaAdi}_{zamanDamgasi}{uzanti}";

                // Dosyanın kaydedileceği yolu oluştur
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/video", yeniisim);

                // Dosyayı belirtilen yola kaydet
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Video_File.CopyTo(stream);
                }

                // Dosya adını modele atayın
                feature.VideoUrl = yeniisim;
            }




            featureManager.TAdd(feature);
            return RedirectToAction("Index");
        }
        //public IActionResult AddFeature(Feature feature)
        //{
        //    featureManager.TAdd(feature);
        //    return RedirectToAction("Index");
        //}

        // Feature Sil

        public IActionResult DeleteFeature(int id)
        {
            var values = featureManager.GetById(id);
            if (values != null)
            {
                var videoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/video/", values.VideoUrl);
                if (System.IO.File.Exists(videoPath))
                {
                    System.IO.File.Delete(videoPath);
                }
                featureManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }
        //public IActionResult DeleteFeature(int id)
        //{
        //    var values = featureManager.GetById(id);
        //    featureManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}

        // Feature Güncelle
        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            ViewBag.d1 = "Feature Güncelleme";
            var values = featureManager.GetById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult EditFeature(Feature feature, IFormFile Video_File)
        {
            if (Video_File != null)
            {
                // Dosya uzantısını al
                var uzanti = Path.GetExtension(Video_File.FileName);

                // Orijinal dosya adını al
                var orijinalDosyaAdi = Path.GetFileNameWithoutExtension(Video_File.FileName);

                // Benzersiz bir dosya adı oluşturmak için zaman damgası ekle
                var zamanDamgasi = DateTime.Now.ToString("HHmmss");
                var yeniisim = $"{orijinalDosyaAdi}_{zamanDamgasi}{uzanti}";

                // Dosyanın kaydedileceği yolu oluştur
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/video", yeniisim);

                // Dosyayı belirtilen yola kaydet
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Video_File.CopyTo(stream);
                }

                // Dosya adını modele atayın
                feature.VideoUrl = yeniisim;
            }




            ViewBag.d1 = "Feature Güncelleme";
            if (ModelState.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction("Index");
            }
            return View(feature);
        }
        //public IActionResult EditFeature(Feature feature)
        //{
        //    ViewBag.d1 = "Partner Güncelleme";
        //    if (ModelState.IsValid)
        //    {
        //        featureManager.TUpdate(feature);
        //        return RedirectToAction("Index");
        //    }
        //    return View(feature);
        //}
    }
}
