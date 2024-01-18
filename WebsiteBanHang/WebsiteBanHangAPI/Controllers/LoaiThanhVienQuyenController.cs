using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiThanhVienQuyenController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public LoaiThanhVienQuyenController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/LoaiThanhVienQuyen
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetLoaiThanhVienQuyens()
        {
            return _context.LoaiThanhVien_Quyen.Include(ltvq => ltvq.LoaiThanhVien).Select(ltvq => new
            {
                ltvq.MaLoaiTV,
                ltvq.MaQuyen,
                ltvq.GhiChu


            }).ToList();
        }

        // GET: api/LoaiThanhVienQuyen/5
        [HttpGet("{id}")]
        public ActionResult<LoaiThanhVien_Quyen> GetLoaiThanhVienQuyen(int id)
        {
            var loaiThanhVienQuyen = _context.LoaiThanhVien_Quyen.Find(id);

            if (loaiThanhVienQuyen == null)
            {
                return NotFound();
            }

            return loaiThanhVienQuyen;
        }

        // PUT: api/LoaiThanhVienQuyen/5
        [HttpPut("{id}")]
        public IActionResult PutLoaiThanhVienQuyen(int id, LoaiThanhVien_Quyen loaiThanhVienQuyen)
        {
            if (id != loaiThanhVienQuyen.MaLoaiTV)
            {
                return BadRequest();
            }

            _context.Entry(loaiThanhVienQuyen).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/LoaiThanhVienQuyen
        [HttpPost]
        public ActionResult<LoaiThanhVien_Quyen> PostLoaiThanhVienQuyen(LoaiThanhVien_QuyenDTO loaiThanhVienQuyenDTO)
        {
            var loaiThanhVienQuyen = new LoaiThanhVien_Quyen
            {
                MaQuyen = loaiThanhVienQuyenDTO.MaQuyen,
                GhiChu = loaiThanhVienQuyenDTO.GhiChu,

            };
            _context.LoaiThanhVien_Quyen.Add(loaiThanhVienQuyen);
            _context.SaveChanges();

            return CreatedAtAction("GetLoaiThanhVienQuyen", new { id = loaiThanhVienQuyen.MaLoaiTV }, loaiThanhVienQuyen);
        }

        // DELETE: api/LoaiThanhVienQuyen/5
        [HttpDelete("{id}")]
        public ActionResult<LoaiThanhVien_Quyen> DeleteLoaiThanhVienQuyen(int id)
        {
            var loaiThanhVienQuyen = _context.LoaiThanhVien_Quyen.Find(id);
            if (loaiThanhVienQuyen == null)
            {
                return NotFound();
            }

            _context.LoaiThanhVien_Quyen.Remove(loaiThanhVienQuyen);
            _context.SaveChanges();

            return loaiThanhVienQuyen;
        }
    }
}
