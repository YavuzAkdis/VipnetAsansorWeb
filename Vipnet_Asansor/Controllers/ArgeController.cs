﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class ArgeController : Controller
    {
        ArgeManager argeManager = new ArgeManager(new EfArgeDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Arge Sayfası";

            var values = argeManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


        // Arge Ekle
        [HttpGet]
        public IActionResult AddArge()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Arge Sayfası Ekle";

            return View();
        }
        [HttpPost]

        public IActionResult AddArge(Arge arge, IFormFile Image_File, string language)
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
                arge.ImageUrl = yeniisim;
            }


            arge.Language = language; // Dil bilgisini ata

            argeManager.TAdd(arge);
            return RedirectToAction("Index");
        }

        //public IActionResult AddArge(Arge arge)
        //{
        //    argeManager.TAdd(arge);
        //    return RedirectToAction("Index");
        //}

        // Arge Sil

        public IActionResult DeleteArge(int id)
        {
            var values = argeManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                argeManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }
        //public IActionResult DeleteArge(int id)
        //{
        //    var values = argeManager.GetById(id);
        //    argeManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}

        // Arge Güncelle
        [HttpGet]
        public IActionResult EditArge(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Arge Sayfası Güncelleme";
            var values = argeManager.GetById(id);
            return View(values);
        }
  
        [HttpPost]



        public IActionResult EditArge(Arge arge, IFormFile Image_File, string language)
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
                arge.ImageUrl = yeniisim;
            }


            arge.Language = language; // Dil bilgisini ata

            ViewBag.d1 = "Arge Güncelleme";
            if (ModelState.IsValid)
            {
                argeManager.TUpdate(arge);
                return RedirectToAction("Index");
            }
            return View(arge);
        }
        //public IActionResult EditArge(Arge arge)
        //{
        //    ViewBag.d1 = "Arge Sayfası Güncelleme";
        //   argeManager.TUpdate(arge);
        //    return RedirectToAction("Index");
        //}
    }
}
