using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuoKaNaShop.Data;
using QuoKaNaShop.Model.Models;
using QuoKaNaShop.Web.Models;

namespace Project.Controllers
{
    public class DangNhap_DangKyController : Controller
    {
        // GET: DangNhap_DangKy
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult DangNhap()
        {
            //var model = new DangNhap
            //{
            //    DiaChiMail = "phanhoangnamst@gmail.com",
            //    MatKhau = "123456"
            //};
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            Customer cusModel = new Customer();
            return View(cusModel);
        }
        [HttpPost]
        public ActionResult DangKy(DangNhap_DangKy model)
        {
            //var db = new ShopEntities();
            model.Customer.Username = model.Customer.Email;
            using (QuoKaNaDBContext db = new QuoKaNaDBContext())
            {
                if (db.Customers.Any(x => x.Username == model.Customer.Username))
                {
                    ViewBag.DuplicateMessage = "Tên đăng nhập đã tồn tại.";
                    return View("../Home/TrangChuIndex");
                    //return Content(ViewBag);
                }

                //       model.Photo = model.Photo.ToString();
                db.Customers.Add(model.Customer);
                db.SaveChanges();
            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Đăng ký thành công.";
            return View("../Users/Index");

        }

        [HttpPost]
        public ActionResult DangNhap(DangNhap_DangKy model)
        {
            //DangNhap dn = new DangNhap();
            if (model.DangNhap.IsCustomer == "customer")
            {
                //var db = new ShopEntities();
                using (QuoKaNaDBContext db = new QuoKaNaDBContext())
                {
                    var sql = (from user in db.Customers
                               where model.DangNhap.DiaChiMail == user.Username & model.DangNhap.MatKhau == user.Password
                               select user).SingleOrDefault();
                    if (sql != null)
                    {
                        ViewBag.SuccessMessage = "Đăng nhập thành công.";
                        return View("../Users/Index");
                    }
                    else
                    {
                        ViewBag.DuplicateMessage = "Đăng nhập không thành công.";
                        return View("../Home/TrangChuIndex");
                        //return Content(ViewBag);
                    }
                    //model.Username = model.Email;
                    //model.Photo = model.Photo.ToString();
                    //db.Customers.Add(model);
                    //db.SaveChanges();
                }
            }
            else
            {
                using (QuoKaNaDBContext db = new QuoKaNaDBContext())
                {
                    var sql = (from user in db.Admins
                               where model.DangNhap.DiaChiMail == user.Username & model.DangNhap.MatKhau == user.Password
                               select user).SingleOrDefault();
                    if (sql != null)
                    {
                        ViewBag.SuccessMessage = "Đăng nhập thành công.";
                        return View("../PageOfAdmin/PageOfAdmin");
                    }
                    else
                    {
                        ViewBag.DuplicateMessage = "Đăng nhập không thành công.";
                        return View("../Home/TrangChuIndex");
                    }
                }
            }
            //ModelState.Clear();
            //ViewBag.SuccessMessage = "Đăng ký thành công.";
            //return View("DangKy", new Customer());

        }
        //public JsonResult CheckUserName(string username, string password)
        //{
        //    if (username == "phanhoangnam" && password=="123456")
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}
        //[ValidateInput(false)]
        //public ActionResult Validate(DangKy model)
        //{
        //    if (model.Ho.Length < 5)
        //        ModelState.AddModelError("Ho", "Ít nhất 5 ký tự");
        //    if (model.Ten.Length < 5)
        //        ModelState.AddModelError("Ten", "Ít nhất 5 ký tự");
        //    if (model.MatKhau.Length < 8)
        //        ModelState.AddModelError("MatKhau", "Ít nhất 8 ký tự");
        //    if (model.NhapLaiMatKhau!=model.MatKhau)
        //        ModelState.AddModelError("NhapLaiMatKhau", "Nhập lại mật khẩu");
        //    return View("TrangChuIndex");
        //}

        //public ActionResult Validate(DangKy model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", "Đăng ký thành công!");
        //    }
        //    return View("DangKy");
        //}

        //public ActionResult CheckAccount(DangNhap model)
        //{
        //    if (model.DiaChiMail=="phanhoangnamst@gmail.com" && model.MatKhau=="123456")
        //    {
        //        ModelState.AddModelError("", "Đăng nhập thành công!");
        //    }
        //    return View("DangNhap");
        //}
    }
}