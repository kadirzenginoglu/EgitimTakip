using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgitimTakip.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _repo;

        public EmployeeController(IRepository<Employee> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll ()
        {
            var result = _context.Employees.Where(e=>!e.IsDeleted).Include(e=>e.Company).ToList();
            return Json(new { data = result });
        }

        public IActionResult Add(Employee employee)
            {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            employee.IsDeleted =true;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult HardDelete (int id)
        {
            Employee employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }





    }
}
