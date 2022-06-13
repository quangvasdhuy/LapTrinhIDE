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
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsMon = _context.Users.ToList();
            return Ok(dsMon);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var mon = _context.Users.SingleOrDefault(mo => mo.IdUser == id);
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
        public IActionResult CreateNew(UserModel model)
        {
            try
            {
                var sub = new User
                {
                    Name = model.Name,
                    Username = model.Username,  
                    Email = model.Email,
                    Password = model.Password,
                    YearOfBirth = model.YearOfBirth,
                    YearOfStudent = model.YearOfStudent,
                    IsAdmin = model.IsAdmin,
                    IsTeacher = model.IsTeacher
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
        public IActionResult UpdateById(Guid id, UserModel model)
        {
            var mon = _context.Users.SingleOrDefault(mo => mo.IdUser == id);
            if (mon != null)
            {
                mon.Name = model.Name;
                mon.Username = model.Username;
                mon.Email = model.Email;
                mon.Password = model.Password;
                mon.YearOfBirth = model.YearOfBirth;
                mon.YearOfStudent = model.YearOfStudent;
                mon.IsTeacher = model.IsTeacher;
                mon.IsAdmin = model.IsAdmin;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUserItem(Guid id)
        {
            var monItem =  _context.Users.SingleOrDefault(mo => mo.IdUser == id);

            if (monItem == null)
            {
                return BadRequest();
            }

            _context.Users.Remove(monItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
