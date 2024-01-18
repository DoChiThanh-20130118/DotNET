using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhVienController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public ThanhVienController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/ThanhVien
        [HttpGet]
        public ActionResult<IEnumerable<ThanhVien>> GetThanhViens()
        {
            return _context.ThanhViens.ToList();
        }

        // GET: api/ThanhVien/5
        [HttpGet("{id}")]
        public ActionResult<ThanhVien> GetThanhVien(int id)
        {
            var thanhVien = _context.ThanhViens.Find(id);

            if (thanhVien == null)
            {
                return NotFound();
            }

            return thanhVien;
        }

        // PUT: api/ThanhVien/5
        [HttpPut("{id}")]
        public IActionResult PutThanhVien(int id, ThanhVien thanhVien)
        {
            if (id != thanhVien.MaThanhVien)
            {
                return BadRequest();
            }

            _context.Entry(thanhVien).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/ThanhVien
        [HttpPost]
        public ActionResult<ThanhVien> PostThanhVien(ThanhVien thanhVien)
        {
            _context.ThanhViens.Add(thanhVien);
            _context.SaveChanges();

            return CreatedAtAction("GetThanhVien", new { id = thanhVien.MaThanhVien }, thanhVien);
        }

        // DELETE: api/ThanhVien/5
        [HttpDelete("{id}")]
        public ActionResult<ThanhVien> DeleteThanhVien(int id)
        {
            var thanhVien = _context.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return NotFound();
            }

            _context.ThanhViens.Remove(thanhVien);
            _context.SaveChanges();

            return thanhVien;
        }
    }
}
