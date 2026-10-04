using System.Linq;
using System.Web.Mvc;
using StudentCRUD.Models;

namespace StudentCRUD.Controllers
{
    public class StudentsController : Controller
    {
        StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            db.Entry(student).State =
                System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
