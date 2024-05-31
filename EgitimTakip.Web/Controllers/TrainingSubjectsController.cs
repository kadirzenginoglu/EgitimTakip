using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    [Authorize]
    public class TrainingSubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TrainingSubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var result = _context.TrainingSubjects.Where(o=>!o.IsDeleted).ToList();
            return Json(new { data= result });
        }
        [HttpPost]
        public IActionResult Add(TrainingSubjects trainingSubjects)
        {
            _context.TrainingSubjects.Add(trainingSubjects);
            _context.SaveChanges();
            return Ok(trainingSubjects);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            TrainingSubjects trainingSubjects = _context.TrainingSubjects.Find(id);
            trainingSubjects.IsDeleted= true;
            _context.TrainingSubjects.Update(trainingSubjects);
            _context.SaveChanges();
            return Ok(trainingSubjects);

        }
        [HttpPost]
        public IActionResult Update (TrainingSubjects trainingSubjects)
        {
            _context.TrainingSubjects.Update(trainingSubjects);
            _context.SaveChanges();
            return Ok(trainingSubjects);
        }




    }
}
