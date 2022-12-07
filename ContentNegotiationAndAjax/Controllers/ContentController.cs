using ContentNegotiationAndAjax.Data;
using ContentNegotiationAndAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ContentNegotiationAndAjax.Controllers
{
    public class ContentController : Controller
    {
        private readonly DatabaseContext _Context;

        public ContentController(DatabaseContext context)
        {
            this._Context = context;
        }

        /// <summary>
        /// Get Secion of course
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Index(string? str)
        
        
        
        {
            var courses = _Context.Courses.ToList();
            //ViewBag.Str = str;
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(String? id)
        {
            var course = _Context.Courses.Where(x => x.Id ==Convert.ToInt32(id)).FirstOrDefault();
            var CheckAjaxType = HttpContext.Request.Headers["X-Requested-With"].ToString();
            if (CheckAjaxType == "XMLHttpRequest")
            {
                return PartialView("CourseDetail", course);
            }
            return View(course);
        }

        //Content Negotiation Action
        [HttpGet]
        public IActionResult ContentNegotiation(int id)
        {
            var course = _Context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return Ok(course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _Context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _Context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }

        /// <summary>
        /// Post Secion of course
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Create(Course model)
        {
            _Context.Courses.Add(model);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Course model)
        {
            _Context.Courses.Update(model);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Course model)
        {
            _Context.Courses.Remove(model);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
