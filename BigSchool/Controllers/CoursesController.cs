using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        
        public ActionResult Create()
        {

            //get list category
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.ListCategory = context.Categories.ToList();

            //return View();
            return View(objCourse);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course objCourse)
        {
            BigSchoolContext context = new BigSchoolContext();
               ModelState.Remove("LectureId");
               if(!ModelState.IsValid){
                   objCourse.ListCategory = context.Categories.ToList();
                   return View("Create", objCourse);
               }
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            // objCourse.LectureId = user.Id;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LectureId = user.Id;

            //context.Courses.Add(objCourse);
            context.Courses.Add(objCourse);
            context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}