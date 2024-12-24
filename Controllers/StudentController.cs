using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase_MVC.NET.Models;

namespace DataBase_MVC.NET.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private StudentDB _studentDB = new StudentDB();
        public ActionResult Index()
        {
            DataTable students =  _studentDB.GetStudents();
            return View(model:students);
        }
        public ActionResult Save(Student student)
        {
            if (this.ModelState.IsValid)
            {
                if (student.StudentId > 0)
                {
                    _studentDB.UpdateStudent(student);
                    return RedirectToAction("Index");
                }
                else if (student.StudentId == 0)
                {
                    _studentDB.AddStudent(student);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Title = student.StudentId == 0 ? "Add Student":"Edit Student";
            ViewBag.Course = CreateItems(student.CourseId);
            return View("Edit", student);
        }
        public ActionResult New()
        {
            Student student = new Student();
            student.StudentId = 0;
            student.Gender = "Male";
            ViewBag.Course = CreateItems(student.CourseId);
            ViewBag.Title = "Add Student";
            return View("Edit",student);
        }
        public ActionResult Edit(int id)
        {
          
            DataRow row = _studentDB.GetStudentById(id);
            Student student = new Student();
            student.StudentId = id;
            student.CourseId = Convert.ToInt32(row["CourseId"]);
            student.Address = Convert.ToString(row["Address"]);
            student.Gender = Convert.ToString(row["Gender"]);
            student.Name = Convert.ToString(row["Name"]);
            ViewBag.Title = "Edit Student";
            ViewBag.Course = CreateItems(student.CourseId);
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            _studentDB.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        [NonAction]
        private List<SelectListItem> CreateItems(int courseId)
        {
            DataTable dt = _studentDB.GetCourse();
            List<SelectListItem> selectList = 
                new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                SelectListItem item = new SelectListItem() 
                { Value = Convert.ToString( row["CourseId"]),
                    Selected = courseId == 
                    Convert.ToInt32(row["CourseId"]),
                    Text = Convert.ToString(row["Name"])
                };
                selectList.Add(item);
            }
            return selectList;
        } 
    }
}