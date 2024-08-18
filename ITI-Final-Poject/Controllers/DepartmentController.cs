
using ITI_Final_Poject.Models;
using ITI_Final_Poject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Final_Poject.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationContext context = new ApplicationContext();

        I_StudentRepo studentRepository;
        I_DepartmentRepo departmentRepository;

        public DepartmentController(I_StudentRepo _stdRepo, I_DepartmentRepo _Deptrepo)
        {
            studentRepository = _stdRepo;
            departmentRepository = _Deptrepo;
        }







        public IActionResult GetStudent(int DeptID)
        {
            return Json(context.Students.Where(s => s.Dept_Id == DeptID).ToList());
        }

        [Authorize(Roles = "Admin")]

        public IActionResult New()
        {
            return View(new Department());
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult SaveNEw(Department dept)
        {
            if (dept.Name != null)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("NEw", dept);

        }

        public IActionResult Index()
        {
            List<Department> deptList = context.Departments.ToList();


            return View(deptList);

        }

        public IActionResult Details(int id)
        {
            Department dept = context.Departments.FirstOrDefault(d => d.Id == id);
            return View("DEtails", dept);
        }



        public IActionResult Delete(int id)
        {
            Department Dep = departmentRepository.GetById(id);
            return View(Dep);

        }

        [Authorize(Roles = "Admin")]
        public IActionResult ConfirmDelete(int id)
        {
            departmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}






