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
    public class ChapterController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ChapterController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsChuong = _context.Chapters.ToList();
            return Ok(dsChuong);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var chuong = _context.Chapters.SingleOrDefault(mo => mo.IdChapter == id);
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
        public IActionResult CreateNew(ChapterModel model)
        {
            try
            {
                var sub = new Chapter
                {
                    NameChapter = model.NameChapter,
                    IdSubject = model.IdSubject
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
        public IActionResult UpdateById(Guid id, ChapterModel model)
        {
            var mon = _context.Chapters.SingleOrDefault(mo => mo.IdChapter == id);
            if (mon != null)
            {
                mon.NameChapter = model.NameChapter;
                mon.IdSubject = model.IdSubject;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteChapterItem(Guid id)
        {
            var monItem =  _context.Chapters.SingleOrDefault(mo => mo.IdChapter == id);

            if (monItem == null)
            {
                return BadRequest();
            }

            _context.Chapters.Remove(monItem);
            _context.SaveChanges();

            return NoContent();
        }

        [Route("GetAllSubject")]
        [HttpGet]
        public IActionResult GetAllSubject()
        {
            var dsMon = _context.Subjects.ToList();
            return Ok(dsMon);
        }
    }
}
