using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Category Sayfası";

            var values = categoryManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }



        // Category Ekle
        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Category Sayfası Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category, IFormFile Image_File, string language)
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
                category.ImageUrl = yeniisim;
            }


            category.Language = language; // Dil bilgisini ata


            categoryManager.TAdd(category);
            return RedirectToAction("Index");
        }

        // Category Sil
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.GetById(id);
            categoryManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Category Güncelle
        [HttpGet]
        public IActionResult EditCategory(int id)
        {

            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Category Sayfası Güncelleme";
            var values = categoryManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category, IFormFile Image_File, string language)
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
                category.ImageUrl = yeniisim;
            }


            category.Language = language; // Dil bilgisini ata


            ViewBag.d1 = "Category Sayfası Güncelleme";

            if (ModelState.IsValid)
            {
                categoryManager.TUpdate(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}
