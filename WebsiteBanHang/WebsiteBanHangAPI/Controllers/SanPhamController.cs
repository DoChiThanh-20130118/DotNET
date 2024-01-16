using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public SanPhamController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/SanPham
        [HttpGet]
        public ActionResult<IEnumerable<SanPham>> GetSanPhams()
        {
            return _context.SanPhams.ToList();
        }

        // GET: api/SanPham/5
        [HttpGet("{id}")]
        public ActionResult<SanPham> GetSanPham(int id)
        {
            var sanPham = _context.SanPhams.Find(id);

            if (sanPham == null)
            {
                return NotFound();
            }

            return sanPham;
        }

        // PUT: api/SanPham/5
        [HttpPut("{id}")]
        public IActionResult PutSanPham(int id, SanPham sanPham)
        {
            if (id != sanPham.MaSP)
            {
                return BadRequest();
            }

            _context.Entry(sanPham).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/SanPham
        [HttpPost]
        public ActionResult<SanPham> PostSanPham(SanPham sanPham)
        {
            _context.SanPhams.Add(sanPham);
            _context.SaveChanges();

            return CreatedAtAction("GetSanPham", new { id = sanPham.MaSP }, sanPham);
        }

        // DELETE: api/SanPham/5
        [HttpDelete("{id}")]
        public ActionResult<SanPham> DeleteSanPham(int id)
        {
            var sanPham = _context.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            _context.SanPhams.Remove(sanPham);
            _context.SaveChanges();

            return sanPham;
        }
    }
}
