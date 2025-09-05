using Azure;
using Microsoft.AspNetCore.Mvc;
using StudentDetails.Data;
using StudentDetails.Models.Domain;
using StudentDetails.Models.ViewModels;

namespace StudentDetails.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(AddStudentRequest addStudentRequest)
        {

            var tag = new Student
            {
                FirstName = addStudentRequest.FirstName,
                LastName = addStudentRequest.LastName,
                Address = addStudentRequest.Address

            };

            studentDbContext.Students.Add(tag);
            studentDbContext.SaveChanges();


            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            //use dbcontext to read the tags
            var students = studentDbContext.Students.ToList();

            return View(students);

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var student = studentDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                var editStudentRequest = new EditStudentRequest
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Address = student.Address
                };

                return View(editStudentRequest);
            }
            return View(null);
        }

        [HttpPost]
        public IActionResult Edit(EditStudentRequest editStudentRequest)
        {
            var student = new Student
            {
                Id = editStudentRequest.Id,
                FirstName = editStudentRequest.FirstName,
                LastName = editStudentRequest.LastName,
                Address = editStudentRequest.Address
            };

            var existingStudent = studentDbContext.Students.Find(student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Address = student.Address;

                studentDbContext.SaveChanges();
                return RedirectToAction("List", new { id = editStudentRequest.Id });
            }

            return RedirectToAction("List", new { id = editStudentRequest.Id });
        }

        [HttpPost]
        public IActionResult Delete(EditStudentRequest editStudentRequest)
        {
            var student = studentDbContext.Students.Find(editStudentRequest.Id);
            if (student != null)
            {
                studentDbContext.Students.Remove(student);
                studentDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new {id=editStudentRequest.Id});
        }
    }
}
