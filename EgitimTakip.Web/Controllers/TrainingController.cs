using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgitimTakip.Web.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll() 
        {
            return Json(new {data= _context.Trainings.Include(t=>t.Company).Include(t=>t.Employees).Where(t=>!t.IsDeleted).ToList()});
        }

        [HttpPost]
        public IActionResult Add(Training training, List<TrainingsSubjectsMap> trainingSubjectsMaps)
        {
            _context.Trainings.Add(training);
            _context.SaveChanges();

            foreach (var item in trainingSubjectsMaps)
            {
                _context.TrainingsSubjectsMaps.Add(item);
            }
            _context.SaveChanges();
            var returndata = _context.Trainings.Where(h => h.Id == training.Id).Include(t => t.Company).Include(t => t.Employees).FirstOrDefault();
            return Ok(returndata);
        }
        [HttpPost]
        public IActionResult Update(Training training)
        {
            _context.Trainings.Update(training);
            _context.SaveChanges();
            var returndata = _context.Trainings.Where(h => h.Id == training.Id).Include(t => t.Company).Include(t => t.Employees).FirstOrDefault();
            return Ok(returndata);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //SOFT DELETE
            Training training = _context.Trainings.Find(id);
            training.IsDeleted=true;
            _context.Trainings.Update(training);
            _context.SaveChanges();
            return Ok(training);

        }



    }
}
