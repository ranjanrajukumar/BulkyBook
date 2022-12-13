using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //var objCategoryList=_db.Categories.ToList();
            //return View();

            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);


        }

        //Get
        public IActionResult Create()
        {
           return View();

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "error");
            }

            if (ModelState.IsValid)
                {
                _unitOfWork.Category.Add(obj);
                //_db.Add(obj);
                //_db.SaveChanges(); //go to database
                _unitOfWork.Save();
                TempData["success"] = "Category Create successfully.";
                    return RedirectToAction("Index", "Category");
                }
            
            return View(obj);   
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var categoryFromDb = _db.Categories.Find(Id);
            //  var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Name == "id");
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "error");
            }

            if (ModelState.IsValid)
            {
                //_db.Categories.Update(obj);
                // _db.SaveChanges(); //go to database
                _unitOfWork.Category.update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Update successfully.";
                return RedirectToAction("Index", "Category");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(Id);
            var categoryFromDbFirst= _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);

        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj= _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            //var obj = _db.Categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save(); //go to database
            TempData["success"] = "Category Delete successfully.";
            return RedirectToAction("Index");
            

        }
    }

