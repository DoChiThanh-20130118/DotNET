using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiThanhVienController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public LoaiThanhVienController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/LoaiThanhVien
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetLoaiThanhViens()
        {
            return _context.LoaiThanhViens.Include(ltv => ltv.LoaiThanhVien_Quyen).Select(ltv => new
            {
                ltv.MaLoaiTV,
                ltv.TenLoai,
                ltv.UuDai


            }).ToList();
        }


        // GET: api/LoaiThanhVien/5
        [HttpGet("{id}")]
        public ActionResult<LoaiThanhVien> GetLoaiThanhVien(int id)
        {
            var loaiThanhVien = _context.LoaiThanhViens.Find(id);

            if (loaiThanhVien == null)
            {
                return NotFound();
            }

            return loaiThanhVien;
        }

        // PUT: api/LoaiThanhVien/5
        [HttpPut("{id}")]
        public IActionResult PutLoaiThanhVien(int id, LoaiThanhVien loaiThanhVien)
        {
            if (id != loaiThanhVien.MaLoaiTV)
            {
                return BadRequest();
            }

            _context.Entry(loaiThanhVien).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/LoaiThanhVien
        [HttpPost]
        public ActionResult<LoaiThanhVien> PostLoaiThanhVien(LoaiThanhVienDTO loaiThanhVienDTO)
        {

            var loaiThanhVien = new LoaiThanhVien
            {
                TenLoai = loaiThanhVienDTO.TenLoai,
                UuDai = loaiThanhVienDTO.UuDai,

            };
            _context.LoaiThanhViens.Add(loaiThanhVien);
            _context.SaveChanges();

            return CreatedAtAction("GetLoaiThanhVien", new { id = loaiThanhVien.MaLoaiTV }, loaiThanhVien);
        }

        // DELETE: api/LoaiThanhVien/5
        [HttpDelete("{id}")]
        public ActionResult<LoaiThanhVien> DeleteLoaiThanhVien(int id)
        {
            var loaiThanhVien = _context.LoaiThanhViens.Find(id);
            if (loaiThanhVien == null)
            {
                return NotFound();
            }

            _context.LoaiThanhViens.Remove(loaiThanhVien);
            _context.SaveChanges();

            return loaiThanhVien;
        }
    }
}
