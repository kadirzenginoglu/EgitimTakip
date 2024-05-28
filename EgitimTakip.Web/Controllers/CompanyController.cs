using EgitimTakip.Data;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
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
            return Json(new {data=_context.Companies.ToList()});


        }
    }
}
