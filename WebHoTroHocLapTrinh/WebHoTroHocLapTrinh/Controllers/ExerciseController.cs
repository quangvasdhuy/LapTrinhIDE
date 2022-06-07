using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebHoTroHocLapTrinh.Data;
using WebHoTroHocLapTrinh.Models;

namespace WebHoTroHocLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ExerciseController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsBaiTap = _context.Exercises.ToList();
            return Ok(dsBaiTap);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var chuong = _context.Exercises.SingleOrDefault(mo => mo.IdExercise == id);
            if(chuong != null)
            {
                return Ok(chuong);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(ExerciseModel model)
        {
            try
            {
                var sub = new Exercise
                {
                    NameExercise = model.NameExercise,
                    CreatedAt = model.CreatedAt,
                    Description = model.Description,
                    Diffculty = model.Diffculty,
                    Image = model.Image,
                    IdChapter = model.IdChapter
                };
                _context.Add(sub);
                _context.SaveChanges();
                return Ok(sub);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(Guid id, ExerciseModel model)
        {
            var baitapItem = _context.Exercises.SingleOrDefault(mo => mo.IdExercise == id);
            if (baitapItem != null)
            {
                baitapItem.NameExercise = model.NameExercise;
                baitapItem.CreatedAt = model.CreatedAt;
                baitapItem.Description = model.Description;
                baitapItem.Diffculty = model.Diffculty;
                baitapItem.Image = model.Image;
                baitapItem.IdChapter = model.IdChapter;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExerciseItem(Guid id)
        {
            var monItem =  _context.Exercises.SingleOrDefault(mo => mo.IdExercise == id);

            if (monItem == null)
            {
                return BadRequest();
            }

            _context.Exercises.Remove(monItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
