using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhieuNhapController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public ChiTietPhieuNhapController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietPhieuNhap
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetChiTietPhieuNhaps()
        {
            return _context.ChiTietPhieuNhaps.Select(ctpn => new
            {
                ctpn.MaChiTietPN,
                ctpn.MaPN,
                ctpn.DonGiaNhap,
                ctpn.SoLuongNhap,
            
            }).ToList();
        }

        // GET: api/ChiTietPhieuNhap/5
        [HttpGet("{id}")]
        public ActionResult<ChiTietPhieuNhap> GetChiTietPhieuNhap(int id)
        {
            var chiTietPhieuNhap = _context.ChiTietPhieuNhaps.Find(id);

            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return chiTietPhieuNhap;
        }

        // PUT: api/ChiTietPhieuNhap/5
        [HttpPut("{id}")]
        public IActionResult PutChiTietPhieuNhap(int id, ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (id != chiTietPhieuNhap.MaChiTietPN)
            {
                return BadRequest();
            }

            _context.Entry(chiTietPhieuNhap).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/ChiTietPhieuNhap
        [HttpPost]
        public ActionResult<ChiTietPhieuNhap> PostChiTietPhieuNhap(ChiTietPhieuNhapDTO chiTietPhieuNhapDTO)
        {

            var chiTietPhieuNhap = new ChiTietPhieuNhap
            {
                MaPN = chiTietPhieuNhapDTO.MaPN,
                DonGiaNhap = chiTietPhieuNhapDTO.DonGiaNhap,
                SoLuongNhap = chiTietPhieuNhapDTO.SoLuongNhap
            };
            _context.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
            _context.SaveChanges();

            return CreatedAtAction("GetChiTietPhieuNhap", new { id = chiTietPhieuNhap.MaChiTietPN }, chiTietPhieuNhap);
        }

        // DELETE: api/ChiTietPhieuNhap/5
        [HttpDelete("{id}")]
        public ActionResult<ChiTietPhieuNhap> DeleteChiTietPhieuNhap(int id)
        {
            var chiTietPhieuNhap = _context.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            _context.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
            _context.SaveChanges();

            return chiTietPhieuNhap;
        }
    }
}
