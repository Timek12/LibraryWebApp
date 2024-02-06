using LibraryWeb.DataAccess.Data;
using LibraryWeb.DataAccess.Repository.IRepository;
using LibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepository.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("DisplayOrder", "The Display Order field cannot exactly match the Order Name.");
            //}

            if (ModelState.IsValid)
            {
                _categoryRepository.Add(obj);
                _categoryRepository.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var category = _categoryRepository.Get(c => c.Id == id);
            //var category = _categoryRepository.Find(id);
            //var category = _categoryRepository.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(obj);
                _categoryRepository.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _categoryRepository.Get(c => c.Id == id);
            //var category = _categoryRepository.Find(id);
            //var category = _categoryRepository.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var category = _categoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
