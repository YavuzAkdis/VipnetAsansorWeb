using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Category Sayfası";

            var values = categoryManager.TGetList();
            return View(values);
        }

        // Category Ekle
        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.d1 = "Category Sayfası Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
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
            ViewBag.d1 = "Category Sayfası Güncelleme";
            var values = categoryManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            ViewBag.d1 = "Category Sayfası Güncelleme";
            categoryManager.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
