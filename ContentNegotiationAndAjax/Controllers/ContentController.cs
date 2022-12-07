using ContentNegotiationAndAjax.Data;
using ContentNegotiationAndAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

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
        public IActionResult Details(int id)
        {
            var course = _Context.Courses.Where(x => x.Id ==id).FirstOrDefault();
            var CheckAjaxType = HttpContext.Request.Headers["X-Requested-With"].ToString();
            if (CheckAjaxType == "XMLHttpRequest")
            {
                return PartialView("CourseDetail", course);
            }
            return View(course);
        }

        //Content Negotiation Action
        [HttpGet]
        //[Produces("application/json")]
        public /*IEnumerable<Course> */IActionResult ContentNegotiation()
        {
            //var contentType = HttpContext.Request.Headers.Accept.ToString();
            var course = _Context.Courses.ToList();
            //var services = HttpContext.RequestServices;

            //OutputFormatter output = contentType;
            //HttpContext.Response.Headers.ContentType = contentType;
            return Ok(course);
            //return course;
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
