using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tp2_School.Models;
using tp2_School.Models.Repositories;

namespace tp2_School.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentRepository studentRepository;
        readonly ISchoolRepository schoolRepository;

        public StudentController(IStudentRepository studentRepository, ISchoolRepository schoolRepository)
        {
            this.studentRepository = studentRepository;
            this.schoolRepository = schoolRepository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID","SchoolName");
            return View(studentRepository.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student st)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName",st.SchoolID);
                studentRepository.Add(st);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student st)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
                studentRepository.Edit(st);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            var st = studentRepository.GetById(id);
            return View(st);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student st)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
                studentRepository.Delete(st);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string name, int? schoolid)
        {
            var result = studentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = studentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = studentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(),"SchoolID","SchoolName");
            return View("Index",result);
        }
    }
}
