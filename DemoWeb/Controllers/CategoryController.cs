using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDbContext _db;
        //Tiêm DI
        public CategoryController(CategoryDbContext db)
        {
            _db = db;
        }

        //Hiển thị ra list dữ liệu
        //[ActionName("hi")]
        public IActionResult Index()
        {
            //var categoryList = _db.Categories.ToList();
            //return View(categoryList);
            return View();
        }
        //return action method
        //trả về data type
        [HttpPost]
        public IActionResult Index(int id, string name)
        {
            //string webCome = $"Chào mừng {id} có {name} đến với bình nguyên vô tận";
            //return View((object)webCome);
            Category category = new Category();
            category.Ma = id;
            category.Name = name;
            category.Description = "hí anh em";
            return View(category);
        }

        //        GET: LẤY DỮ LIỆU MÀ KHÔNG CẦN THAY ĐỔI TRẠNG THÁI
        //POST: TẠO MỚI DỮ LIỆU
        //PUT/ PATCH: CẬP NHẬT DỮ LIỆU
        //DELETE: XÓA DỮ LIỆU

        //NẾU K NS GÌ NÓ SẼ MẶC ĐỊNH LÀ HTTGET
        //Tạo 1 đối tượng category
        //Tạo ra 1 view có form create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cate)
        {
            _db.Categories.Add(cate);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        //dùng để tạo ra view edit với dữ liệu cần edit
        [HttpGet]
        public IActionResult Edit(int HI)
        {
            var cateEdit = _db.Categories.FirstOrDefault(x => x.Ma == HI);
            return View(cateEdit);
        }
        [HttpPost]
        public IActionResult Edit(Category cate)
        {
            _db.Categories.Update(cate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int HI)
        {
            var cateEdit = _db.Categories.FirstOrDefault(x => x.Ma == HI);
            return View(cateEdit);
        }
       
        public IActionResult Delete(int HI) 
        {
            var cateDe = _db.Categories.FirstOrDefault(x => x.Ma == HI);
            _db.Categories.Remove(cateDe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
