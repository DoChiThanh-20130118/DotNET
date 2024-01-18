using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public QuyenController(QuanLyBanHangContext context)
        {
            _context = context;
        }
        private string SerializeObjectWithPreserveReferenceHandling(object obj)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(obj, options);
        }

        // GET: api/Quyen
        [HttpGet]
        public ActionResult<IEnumerable<Quyen>> GetQuyens()
        {
            return _context.Quyens.Include(q => q.LoaiThanhVien_Quyen).ToList();
        }


        // GET: api/Quyen/5
        [HttpGet("{id}")]
        public ActionResult<Quyen> GetQuyen(string id)
        {
            var quyen = _context.Quyens.Find(id);

            if (quyen == null)
            {
                return NotFound();
            }

            return quyen;
        }

        // PUT: api/Quyen/5
        [HttpPut("{id}")]
        public IActionResult PutQuyen(string id, Quyen quyen)
        {
            if (id != quyen.MaQuyen)
            {
                return BadRequest();
            }

            _context.Entry(quyen).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Quyen
        [HttpPost]
        public ActionResult<Quyen> PostQuyen(Quyen quyen)
        {
            _context.Quyens.Add(quyen);
            _context.SaveChanges();

            return CreatedAtAction("GetQuyen", new { id = quyen.MaQuyen }, quyen);
        }

        // DELETE: api/Quyen/5
        [HttpDelete("{id}")]
        public ActionResult<Quyen> DeleteQuyen(string id)
        {
            var quyen = _context.Quyens.Find(id);
            if (quyen == null)
            {
                return NotFound();
            }

            _context.Quyens.Remove(quyen);
            _context.SaveChanges();

            return quyen;
        }
    }
}
