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
    public class SubjectController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SubjectController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsMon = _context.Subjects.ToList();
            return Ok(dsMon);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var mon = _context.Subjects.SingleOrDefault(mo => mo.IdSubject == id);
            if(mon != null)
            {
                return Ok(mon);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(SubjectModel model)
        {
            try
            {
                var sub = new Subject
                {
                    NameSubject = model.NameSubject,
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
        public IActionResult UpdateById(Guid id, SubjectModel model)
        {
            var mon = _context.Subjects.SingleOrDefault(mo => mo.IdSubject == id);
            if (mon != null)
            {
                mon.NameSubject = model.NameSubject;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubjectItem(Guid id)
        {
            var monItem =  _context.Subjects.SingleOrDefault(mo => mo.IdSubject == id);

            if (monItem == null)
            {
                return BadRequest();
            }

            _context.Subjects.Remove(monItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
