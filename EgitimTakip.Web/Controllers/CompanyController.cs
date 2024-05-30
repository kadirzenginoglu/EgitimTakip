using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EgitimTakip.Web.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var result = _context.Companies.Where(c=>!c.IsDeleted).Include(c=>c.Employees).ToList();
            return Json(new { data = result });
        }


        public IActionResult Add(Company company)
        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            company.AppUserId= Convert.ToInt32(id);
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            company.AppUserId = Convert.ToInt32(id);
            _context.Companies.Update(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Company company=_context.Companies.Find(id);
            company.IsDeleted = true;
            _context.Companies.Update(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult HardDelete (int id)
        {
            Company company = _context.Companies.Find(id);
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return Ok(company);
        }




    }
}
