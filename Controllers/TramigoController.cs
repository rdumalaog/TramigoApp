using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TramigoController : ControllerBase
    {
        private readonly DataContext _context;
        public TramigoController(DataContext context)
        {
            _context = context;
        }
        
        // api/tramigo
        [HttpGet]
        public ActionResult<IEnumerable<Tramigo>> GetTramigo()
        {
            //var tra = _context.Reports.Join().ToList();
            var result = (from a in _context.Devices
                          join b in _context.Reports 
                          on a.ID equals b.Device_ID
                          
                          select new Tramigo
                          {
                               Name = a.Name,
                              Location = b.Location,
                              DateCreated = b.DateCreated
                          }
                          ).ToList();

            return result;
        }

        // api/tramigo/id
        [HttpGet("{id}")]
        public ActionResult<Tramigo> GetTramigo(int id)
        {
            var result = (from a in _context.Devices
                          join b in _context.Reports 
                          on a.ID equals b.Device_ID
                          where a.ID == id

                          select new Tramigo
                          {
                              Name = a.Name,
                              Location = b.Location,
                              DateCreated = b.DateCreated
                          }
                          ).FirstOrDefault();

            return result;
        }
    }
}