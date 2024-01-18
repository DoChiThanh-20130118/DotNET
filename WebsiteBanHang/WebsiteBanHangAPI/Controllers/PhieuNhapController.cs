using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuNhapController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public PhieuNhapController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/PhieuNhap
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetPhieuNhaps()
        {
             return _context.PhieuNhaps.Include(ltvq => ltvq.ChiTietPhieuNhaps).Select(lsp => new
            {
                lsp.MaPN,
                lsp.MaNCC,
                lsp.NgayNhap,
                lsp.DaXoa,


            }).ToList();
        }

        // GET: api/PhieuNhap/5
        [HttpGet("{id}")]
        public ActionResult<PhieuNhap> GetPhieuNhap(int id)
        {
            var phieuNhap = _context.PhieuNhaps.Find(id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            return phieuNhap;
        }

        // PUT: api/PhieuNhap/5
        [HttpPut("{id}")]
        public IActionResult PutPhieuNhap(int id, PhieuNhap phieuNhap)
        {
            if (id != phieuNhap.MaPN)
            {
                return BadRequest();
            }

            _context.Entry(phieuNhap).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/PhieuNhap
        [HttpPost]
        public ActionResult<PhieuNhap> PostPhieuNhap(PhieuNhapDTO phieuNhapDTO)
        {
            var phieuNhap = new PhieuNhap
            {
                MaNCC = phieuNhapDTO.MaNCC,
                NgayNhap = phieuNhapDTO.NgayNhap,
                DaXoa = phieuNhapDTO.DaXoa
            };
            _context.PhieuNhaps.Add(phieuNhap);
            _context.SaveChanges();

            return CreatedAtAction("GetPhieuNhap", new { id = phieuNhap.MaPN }, phieuNhap);
        }

        // DELETE: api/PhieuNhap/5
        [HttpDelete("{id}")]
        public ActionResult<PhieuNhap> DeletePhieuNhap(int id)
        {
            var phieuNhap = _context.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            _context.PhieuNhaps.Remove(phieuNhap);
            _context.SaveChanges();

            return phieuNhap;
        }
    }
}
