using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_test_1.Models;

namespace P_test_1.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext iticontext = new ITIContext();
        IEmployeeRepository empRepo;
        IGenRepository<Department> deptRepo;

        public DepartmentController(IEmployeeRepository _empRepo, IGenRepository<Department> _deptRepo)
        {
            empRepo = _empRepo;
            deptRepo = _deptRepo;
        }

        public IActionResult EmpList()
        {
            return View("EmpList",deptRepo.GetAll());
        }
        public IActionResult GetEmpsByDeptId(int DeptId)
        {
            return Json(empRepo.GetByDept(DeptId).ToList());
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Department> departments = deptRepo.GetAll();
            return View("Index", departments);
        }
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult saveAdd(Department department)
        {
            if(department.Name != null)
            {
                deptRepo.Add(department);
                deptRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add", department);
            }
        }
    }
}
