
//ÜRÜNLERİ EKLE-SİL-GÜNCELLE

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        
        // Product Listele
        public IActionResult Index()
        {
            ViewBag.d1 = "Product Sayfası";

            var values = productManager.TGetList();
            return View(values);
        }

        // Product Ekle
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.d1 = "Product Sayfası Ekle";

            return View();
        }

        public IActionResult AddProduct(Product product, IFormFile PImage_File, IFormFile PImage_File2, IFormFile PImage_File3, IFormFile PdfFile)
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
        public IActionResult DeleteProduct(int id)
        {
            var values = productManager.GetById(id);
            productManager.TDelete(values);
            return RedirectToAction("Index");
        }


        // Product Güncelle

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = productManager.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product, IFormFile PImage_File, IFormFile PImage_File2, IFormFile PImage_File3, IFormFile PdfFile)
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

            productManager.TUpdate(product);
            return RedirectToAction("Index");
        }

        //
        //[HttpGet]
        //public IActionResult EditProduct(int id)
        //{
        //    ViewBag.d1 = "Product Sayfası Güncelleme";
        //    var values = productManager.GetById(id);
        //    return View(values);
        //}

        //[HttpPost]
        //public IActionResult EditProduct(Product product)
        //{
        //    ViewBag.d1 = "Product Sayfası Güncelleme";
        //    productManager.TUpdate(product);
        //    return RedirectToAction("Index");
        //}

        // product detay
        public IActionResult Details(int id)
        {
            var product = productManager.GetById(id);
            return View(product);
        }
    }
}
