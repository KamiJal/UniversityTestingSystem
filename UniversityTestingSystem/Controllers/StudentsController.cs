using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityTestingSystem.Models;

namespace UniversityTestingSystem.Controllers
{

    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: students/form        
        public ActionResult Form()
        {
            return View();
        }
    }
}