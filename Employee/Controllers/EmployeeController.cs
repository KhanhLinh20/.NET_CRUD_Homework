using Employee.Interface;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetEmployees());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTable employee)
        {
            if (ModelState.IsValid)
            {
                await repo.CreateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await repo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await repo.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeTable employee)
        {
            await repo.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
