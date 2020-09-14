using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_TimeTable.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Student student) {
            if (ModelState.IsValid)
            {
                using (SchoolEntities db = new SchoolEntities())
                {
                    var obj = db.Students.Where(s => s.User_Name.Equals(student.User_Name) && s.Password.Equals(student.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Student_ID"] = obj.Student_Id.ToString();
                        Session["UserName"] = obj.User_Name.ToString();
                        return RedirectToAction("SchoolCalender");
                    }
                }
            }
            return View(student);
        }

        public ActionResult SchoolCalender()
        {
            if (Session["Student_ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}