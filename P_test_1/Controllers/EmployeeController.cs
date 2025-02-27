using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_test_1.Models;
using P_test_1.View_Model;
using Microsoft.Identity.Client;

namespace P_test_1.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context = new ITIContext();
        //EmployeeRepository empRepo;
        //DeparmentRepository depRepo;
            
        IGenRepository<Employee> empRepo;
        IGenRepository<Department> depRepo;

        public EmployeeController(IGenRepository<Employee> empRepo, IGenRepository<Department> depRepo)
        {
            this.empRepo = empRepo;
            this.depRepo = depRepo;
        }

        public IActionResult Index()
        {
            return View("Index", empRepo.GetAll ());
        }

        public IActionResult CheckName(string name, string Address)
        {
            if (!name.Contains("ITI"))
                return Json(true);
            return Json(false);
        }
        
        public IActionResult Edit(int id)
        {
            Employee employee = empRepo.GetByID(id);

            EmpwithDeptListVM cap = new EmpwithDeptListVM();
            cap.Id = employee.Id;
            cap.Name = employee.Name;
            cap.Salary = employee.Salary;
            cap.Address = employee.Address;
            cap.ImageURL = employee.ImageURL;
            cap.DptID = employee.DptID;
            cap.JobTitle = employee.JobTitle;

            cap.Departments = depRepo.GetAll();


            return View("Edit", cap);
        }
        [HttpPost]
        public IActionResult SaveEdit(EmpwithDeptListVM employee)
        {
            if (employee.Name == null)
            {
                employee.Departments = depRepo.GetAll();
                return View("Edit", employee);
            }
            Employee emp = empRepo.GetByID(employee.Id);
            emp.Name = employee.Name;
            emp.Address = employee.Address;
            emp.Salary = employee.Salary;
            emp.DptID = employee.DptID;
            emp.JobTitle = employee.JobTitle;
            emp.ImageURL = employee.ImageURL;
            empRepo.Update(emp);
            empRepo.Save();

            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.departments = depRepo.GetAll();
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveAdd(Employee emp)
        {
            if(ModelState.IsValid)
            {
                if (emp.Image == null)
                {
                    ModelState.AddModelError("Image", "Image is required.");
                    ViewBag.departments = depRepo.GetAll();
                    return View("New", emp);
                }

                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string fileName = Path.GetFileNameWithoutExtension(emp.Image.FileName);
                string extension = Path.GetExtension(emp.Image.FileName);
                string filePath = Path.Combine(wwwRootPath, "images", fileName + extension);

                if (emp.DptID != 0)
                {

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        emp.Image.CopyToAsync(fileStream);
                    }

                    emp.ImageURL = "~/images/" + Path.GetFileName(filePath);

                    empRepo.Add(emp);
                    empRepo.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Invalid_DptID", "plz select department");

                }
            }
            ViewData["departments"] = depRepo.GetAll();
            return View("New", emp);
        }

        public IActionResult Delete(int id)
        {
            Employee emp = empRepo.GetByID(id);
            empRepo.Remove(id);
            empRepo.Save();

            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            string msg = "hello from action";
            int temp = 50;
            List<string> branches = new List<string>();
            branches.Add("minya");
            branches.Add("cario");
            branches.Add("alex");

            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewBag.Branches = branches;
                
            Employee emp = empRepo.GetByID(id);
            return View("Details", emp);
        }
        public IActionResult DetailsVM(int id)
        {
            Employee emp = empRepo.GetByID(id);

            List<string> branches = new List<string>();
            branches.Add("minya");
            branches.Add("cario");
            branches.Add("alex");

            Emp_Details emp_Details = new Emp_Details();
            emp_Details.EmpName = emp.Name;
            emp_Details.DeptNzme = emp.Department.Name;
            emp_Details.Color = "Red";
            emp_Details.Temp = 50;
            emp_Details.Msg = "Hello form VM";
            emp_Details.Branches = branches;

            return View("DetailsVM", emp_Details);
        }


        public IActionResult DetailsPartial(int id)
        {
            Employee emp = empRepo.GetByID(id);
            return PartialView("_EmpCard", emp);
        }
    }
}
