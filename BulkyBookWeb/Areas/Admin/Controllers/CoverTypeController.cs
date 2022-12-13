using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]

    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //var objCategoryList=_db.Categories.ToList();
            //return View();

            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);


        }

        //Get
        public IActionResult Create()
        {
           return View();

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
           

            if (ModelState.IsValid)
                {
                _unitOfWork.CoverType.Add(obj);
                //_db.Add(obj);
                //_db.SaveChanges(); //go to database
                _unitOfWork.Save();
                TempData["success"] = "CoverType Create successfully.";
                    return RedirectToAction("Index", "CoverType");
                }
            
            return View(obj);   
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
        // var categoryFromDb = _db.CoverType.Find(Id);
        //  var categoryFromDbFirst = _db.CoverType.FirstOrDefault(c => c.Name == "id");
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);
        //var categoryFromDbSingle=_db.CoverType.SingleOrDefault(c => c.Id == id);
        if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
           

            if (ModelState.IsValid)
            {
                //_db.Categories.Update(obj);
                // _db.SaveChanges(); //go to database
                _unitOfWork.CoverType.update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Update successfully.";
                return RedirectToAction("Index", "CoverType");
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
            var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(c => c.Id == id);
            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);

        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj= _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);
            //var obj = _db.Categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save(); //go to database
            TempData["success"] = "CoverType Delete successfully.";
            return RedirectToAction("Index");
            

        }
    }

