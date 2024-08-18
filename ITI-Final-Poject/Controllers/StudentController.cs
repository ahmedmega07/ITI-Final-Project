
using ITI_Final_Poject.Models;
using ITI_Final_Poject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI_Final_Poject.Controllers
{


    [Authorize]
    public class StudentController : Controller
    {


        I_StudentRepo studentRepository;
        I_DepartmentRepo departmentRepository;

        public StudentController(I_StudentRepo _stdRepo, I_DepartmentRepo _Deptrepo)
        {
            studentRepository = _stdRepo;
            departmentRepository = _Deptrepo;
        }









        public IActionResult New()
        {

            ViewData["DeptList"] = departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Student newStd)
        {


            if (ModelState.IsValid == true)
            {

                if (newStd.Dept_Id != 0)
                {
                    try
                    {
                        //save
                        studentRepository.Insert(newStd);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                else
                {
                    //error message send view 
                    ModelState.AddModelError("", "Select Department");
                }
            }
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View(newStd);

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Student std = studentRepository.GetById(id);
            return View(std);

        }

        [Authorize(Roles = "Admin")]
        public IActionResult ConfirmDelete(int id)
        {
            studentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //student/details/id
        public IActionResult Details(int id)
        {
            Student std = studentRepository.GetById(id);
            return View(std);
        }
        public IActionResult GetStudent()
        {

            Student stdModel = studentRepository.GetById(1);
            return View(stdModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Student student = studentRepository.GetById(id);
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveEdit(int id, Student newStd)
        {


            if (ModelState.IsValid == true)
            {
                //get old object
                studentRepository.Edit(id, newStd);


                return RedirectToAction("Index");
                //save
            }
            //model 
            ViewData["DeptList"] = departmentRepository.GetAll();

            return View("Edit", newStd);
        }

        [Authorize]
        public IActionResult Index()
        {
            string name = User.Identity.Name;

            string id =
                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return View(studentRepository.GetAllStudentsWithDepartmentData());
        }


    }
}
