using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public LoaiSanPhamController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/LoaiSanPham
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetLoaiSanPhams()
        {
            return _context.LoaiSanPhams.Select(lsp => new
            {
                lsp.MaLoaiSP,
                lsp.TenLoai,
                lsp.Icon,
                lsp.BiDanh,


            }).ToList();
        }

        // GET: api/LoaiSanPham/5
        [HttpGet("{id}")]
        public ActionResult<LoaiSanPham> GetLoaiSanPham(int id)
        {
            var loaiSanPham = _context.LoaiSanPhams.Find(id);

            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return loaiSanPham;
        }

        // PUT: api/LoaiSanPham/5
        [HttpPut("{id}")]
        public IActionResult PutLoaiSanPham(int id, LoaiSanPham loaiSanPham)
        {
            if (id != loaiSanPham.MaLoaiSP)
            {
                return BadRequest();
            }

            _context.Entry(loaiSanPham).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/LoaiSanPham
        [HttpPost]
        public ActionResult<LoaiSanPham> PostLoaiSanPham(LoaiSanPhamDTO loaiSanPhamDTO)
        {
            var loaiSanPham = new LoaiSanPham
            {
                TenLoai = loaiSanPhamDTO.TenLoai,
                Icon = loaiSanPhamDTO.Icon,
                BiDanh = loaiSanPhamDTO.BiDanh,
          
            };
            _context.LoaiSanPhams.Add(loaiSanPham);
            _context.SaveChanges();

            return CreatedAtAction("GetLoaiSanPham", new { id = loaiSanPham.MaLoaiSP }, loaiSanPham);
        }

        // DELETE: api/LoaiSanPham/5
        [HttpDelete("{id}")]
        public ActionResult<LoaiSanPham> DeleteLoaiSanPham(int id)
        {
            var loaiSanPham = _context.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            _context.LoaiSanPhams.Remove(loaiSanPham);
            _context.SaveChanges();

            return loaiSanPham;
        }
    }
}
