using System.Linq;
using System.Web.Mvc;
using TeamManagement.Models;
using TeamManagement.ViewModels;

namespace TeamManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EmployeeDbContext _dbContext;

        public DepartmentController()
        {
            this._dbContext = new EmployeeDbContext();
        }
        // GET: Employee  
        public ActionResult Index()
        {
            var departmentList = this._dbContext.Department.ToList();
            return View(departmentList);
        }

        public ActionResult AddDepartments()
        {
            var employeeViewModel = new DepartmentViewModel()
            {
                Department = new Department()
            };
            return View("DepartmentForm", employeeViewModel);
        }

        public ActionResult Edit(int id)
        {
            var department = this._dbContext.Department.FirstOrDefault(x => x.DepartmentId == id);

            var viewModel = new DepartmentViewModel()
            {
                Department = department
            };
            return View("DepartmentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddDepartments", "Department");
            }

            if (department.DepartmentId == 0)
                this._dbContext.Department.Add(department);

            else
            {
                var departmentDb = this._dbContext.Department.FirstOrDefault(x => x.DepartmentId == department.DepartmentId);
                departmentDb.DepartmentName = department.DepartmentName;
            }

            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        public ActionResult Delete(int id)
        {
            var departmentDb = this._dbContext.Department.FirstOrDefault(x => x.DepartmentId == id);
            this._dbContext.Department.Remove(departmentDb);
            this._dbContext.SaveChanges();

            return RedirectToAction("Index", "Department");
        }
    }
}