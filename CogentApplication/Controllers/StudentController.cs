using EFDataAccessLayer;
using EFDataAccessLayer.ModelEF;
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
        public ActionResult Details(int StudentID)
        {
            try
            {
                var result = _add.GetbyID(StudentID);

                return View("Details", result);

            }
            catch
            {
                return View("Error");

            }

        }

        // GET: StudentController/Create
        public ActionResult Create()
        {

            var model = new StudentDetails();
        //    model.Gender = "Male";
            return View("Create", model);
        }

        // POST: StudentController/Create
        [HttpPost]
    //    [ValidateAntiForgeryToken]
        public ActionResult Creates(StudentDetails stud)
        {
            try
            {
               /* if (ModelState.IsValid)
                {*/
                    _add.Insert(stud);
                    return RedirectToAction(nameof(List));
             /*   }
                else
                {
                    return View("create", stud);
                }*/
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int StudentID)
        {
            var result = _add.GetbyID(StudentID);
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
        public ActionResult Delete(int StudentID)
        {
            var result = _add.GetbyID(StudentID);
            return View("Delete", result) ;
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebyid(int StudentID)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _add.Delete(StudentID);

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Delete");
                }
            }
            catch
            {
                return View();
            }
         }
        [HttpGet]
        [Route("~/api/Course")]
        public ActionResult Subject()
        {
            try
            {
                 var get = Getvalue();
                 return Ok(get.ToList());
            }
            catch(Exception ex)
            {
               throw new Exception();
            }
            finally
            {

            }
        }
        private List<Subject> Getvalue()
        {
            List<Subject> Course = new List<Subject>();
            Subject input = new Subject();
            input.ID = 1;
            input.Name = "CSE";
            Course.Add(input);
            Subject input1 = new Subject();
            input1.ID = 2;
            input1.Name = "ACC";
            Course.Add(input1);
            Subject input2 = new Subject();
            input2.ID = 3;
            input2.Name = "ECE";
            Course.Add(input2);

            return Course;

        }
    }
}
