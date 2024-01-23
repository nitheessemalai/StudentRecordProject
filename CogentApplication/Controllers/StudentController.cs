using EFDataAccessLayer;
using EFDataAccessLayer.RepositoryEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogentApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepositoryEF _add;
        private readonly string _connectionstring;
        public StudentController(IStudentRepositoryEF add, IConfiguration configuration)
        {
            _add = add;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: StudentController
        public ActionResult List()
        {
            var result = _add.GetAllDetails();
            return View("List", result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {

            var model = new StudentDetails();
            return View("Create", model);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetails stud)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _add.Insert(stud);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("create", stud);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = new StudentDetails();
            return View("Edit", result);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentDetails data)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _add.Update(id,data);

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Edit", data);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = 
            return View("Delete", result);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
