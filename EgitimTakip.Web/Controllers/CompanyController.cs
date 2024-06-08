using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EgitimTakip.Web.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly IRepository<Company> _repo;

        public CompanyController(IRepository<Company> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            //var result = _context.Companies.Where(c=>!c.IsDeleted).Include(c=>c.Employees).ToList();
            return Json(_repo.GetAll());
        }


        public IActionResult Add(Company company)
        {

            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //company.AppUserId= Convert.ToInt32(id);
            //_context.Companies.Add(company);
            //_context.SaveChanges();
            //return Ok(company);

            return Ok(_repo.Add(company));

        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //company.AppUserId = Convert.ToInt32(id);
            //_context.Companies.Update(company);
            //_context.SaveChanges();
            //return Ok(company);
            return Ok(_repo.Update(company));

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //Company company=_context.Companies.Find(id);
            //company.IsDeleted = true;
            //_context.Companies.Update(company);
            //_context.SaveChanges();
            //return Ok(company);
            
            
            //return Ok(_repo?.Delete(id));
            //return Ok(_repo.Delete(id) is object);  - Hileli olanı
            _repo.Delete(id);
            return Ok();
        }
        //[HttpPost]
        //public IActionResult HardDelete (int id)
        //{
        //    Company company = _context.Companies.Find(id);
        //    _context.Companies.Remove(company);
        //    _context.SaveChanges();
        //    return Ok(company);
        //}

    }
}
