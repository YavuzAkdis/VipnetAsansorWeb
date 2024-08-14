using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class PartnerController : Controller
    {

        PartnerManager partnerManager = new PartnerManager(new EfPartnerDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Partner Listesi";

            var values = partnerManager.TGetList();
            return View(values);
        }

        // Partner Ekle
        [HttpGet]
        public IActionResult AddPartner()
        {
            ViewBag.d1 = "Partner Ekle";

            return View();
        }
        //[HttpPost]
        //public IActionResult AddPartner(Partner partner)
        //{
        //    partnerManager.TAdd(partner);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult AddPartner(Partner partner,IFormFile Image_File)
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
                partner.ImageUrl = yeniisim;
            }




            partnerManager.TAdd(partner);
            return RedirectToAction("Index");
        }


        // Partner Sil
        public IActionResult DeletePartner(int id)
        {
            var values = partnerManager.GetById(id);
            if (values != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", values.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                partnerManager.TDelete(values);
            }
            return RedirectToAction("Index");
        }

        // Partner Güncelle
        [HttpGet]
        public IActionResult EditPartner(int id)
        {
            ViewBag.d1 = "Partner Güncelleme";
            var values = partnerManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPartner(Partner partner, IFormFile Image_File)
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
                partner.ImageUrl = yeniisim;
            }




            ViewBag.d1 = "Partner Güncelleme";
            if (ModelState.IsValid)
            {
                partnerManager.TUpdate(partner);
                return RedirectToAction("Index");
            }
            return View(partner);
        }
    }
}

