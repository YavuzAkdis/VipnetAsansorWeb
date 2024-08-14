
//ÜRÜNLERİ EKLE-SİL-GÜNCELLE

using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
   
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Product Listele
        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Product Sayfası";

            var values = productManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }
     

        // Product Ekle
        [HttpGet]
        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
        public IActionResult AddProduct()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "Product Sayfası Ekle";

            return View();
        }

        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
        public IActionResult AddProduct(Product product, IFormFile PImage_File, IFormFile PImage_File2, IFormFile PImage_File3, IFormFile PdfFile, string language)
        {
            if (PImage_File != null)
            {
                var extension = Path.GetExtension(PImage_File.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PImage_File.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PImage_File.CopyTo(stream);
                }

                product.PImageUrl = fileName;
            }

            if (PImage_File2 != null)
            {
                var extension = Path.GetExtension(PImage_File2.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PImage_File2.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PImage_File2.CopyTo(stream);
                }

                product.PImageUrl2 = fileName;
            }

            if (PImage_File3 != null)
            {
                var extension = Path.GetExtension(PImage_File3.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PImage_File3.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PImage_File3.CopyTo(stream);
                }

                product.PImageUrl3 = fileName;
            }

            if (PdfFile != null)
            {
                var extension = Path.GetExtension(PdfFile.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PdfFile.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PdfFile.CopyTo(stream);
                }

                product.PdfFileUrl = fileName;
            }

            product.Language = language; // Dil bilgisini ata

            productManager.TAdd(product);
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public IActionResult AddProduct(Product product)
        //{
        //    productManager.TAdd(product);
        //    return RedirectToAction("Index");
        //}

        // Product Sil
        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
        public IActionResult DeleteProduct(int id)
        {
            var values = productManager.GetById(id);
            productManager.TDelete(values);
            return RedirectToAction("Index");
        }


        // Product Güncelle

        [HttpGet]
        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
        public IActionResult EditProduct(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            var product = productManager.GetById(id);
            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
        public IActionResult EditProduct(Product product, IFormFile PImage_File, IFormFile PImage_File2, IFormFile PImage_File3, IFormFile PdfFile, string language)
        {
            if (PImage_File != null)
            {
                var extension = Path.GetExtension(PImage_File.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PImage_File.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PImage_File.CopyTo(stream);
                }

                product.PImageUrl = fileName;
            }

            if (PImage_File2 != null)
            {
                var extension = Path.GetExtension(PImage_File2.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PImage_File2.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PImage_File2.CopyTo(stream);
                }

                product.PImageUrl2 = fileName;
            }

            if (PImage_File3 != null)
            {
                var extension = Path.GetExtension(PImage_File3.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PImage_File3.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PImage_File3.CopyTo(stream);
                }

                product.PImageUrl3 = fileName;
            }

            if (PdfFile != null)
            {
                var extension = Path.GetExtension(PdfFile.FileName);
                var fileName = $"{Path.GetFileNameWithoutExtension(PdfFile.FileName)}_{DateTime.Now:HHmmss}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PdfFile.CopyTo(stream);
                }

                product.PdfFileUrl = fileName;
            }

            product.Language = language; // Dil bilgisini ata

            productManager.TUpdate(product);
            return RedirectToAction("Index");
        }


        // product detay
        // Ürünleri Url göre listeleme
        //public IActionResult Details(string url)
        //{
        //    if (string.IsNullOrEmpty(url))
        //    {
        //        return NotFound();
        //    }

        //    var product = _productService.GetByUrl(url);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

    }
}
