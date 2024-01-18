using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public NhaCungCapController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/NhaCungCap
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetNhaCungCaps()
        {
            return _context.NhaCungCaps.Select(ddh => new
            {
                ddh.MaNCC,
                ddh.TenNCC,
                ddh.DiaChi,
                ddh.Email,
                ddh.SoDienThoai,
                ddh.Fax,

            }).ToList();
        }

        // GET: api/NhaCungCap/5
        [HttpGet("{id}")]
        public ActionResult<NhaCungCap> GetNhaCungCap(int id)
        {
            var nhaCungCap = _context.NhaCungCaps.Find(id);

            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return nhaCungCap;
        }

        // PUT: api/NhaCungCap/5
        [HttpPut("{id}")]
        public IActionResult PutNhaCungCap(int id, NhaCungCap nhaCungCap)
        {
            if (id != nhaCungCap.MaNCC)
            {
                return BadRequest();
            }

            _context.Entry(nhaCungCap).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/NhaCungCap
        [HttpPost]
        public ActionResult<NhaCungCap> PostNhaCungCap(NhaCungCapDTO nhaCungCapDTO)
        {

            var nhaCungCap = new NhaCungCap
            {
                TenNCC = nhaCungCapDTO.TenNCC,
                DiaChi = nhaCungCapDTO.DiaChi,
                Email = nhaCungCapDTO.Email,
                SoDienThoai = nhaCungCapDTO.SoDienThoai,
                Fax = nhaCungCapDTO.Fax,


            };
            _context.NhaCungCaps.Add(nhaCungCap);
            _context.SaveChanges();

            return CreatedAtAction("GetNhaCungCap", new { id = nhaCungCap.MaNCC }, nhaCungCap);
        }

        // DELETE: api/NhaCungCap/5
        [HttpDelete("{id}")]
        public ActionResult<NhaCungCap> DeleteNhaCungCap(int id)
        {
            var nhaCungCap = _context.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            _context.NhaCungCaps.Remove(nhaCungCap);
            _context.SaveChanges();

            return nhaCungCap;
        }
    }
}
