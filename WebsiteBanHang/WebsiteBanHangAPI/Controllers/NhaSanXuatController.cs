using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaSanXuatController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public NhaSanXuatController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/NhaSanXuat
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetNhaSanXuats()
        {
            return _context.NhaSanXuats.Select(nsx => new
            {
                nsx.MaNSX,
                nsx.TenNSX,
                nsx.ThongTin
            }).ToList();
        }


        // GET: api/NhaSanXuat/5
        [HttpGet("{id}")]
        public ActionResult<NhaSanXuat> GetNhaSanXuat(int id)
        {
            var nhaSanXuat = _context.NhaSanXuats.Find(id);

            if (nhaSanXuat == null)
            {
                return NotFound();
            }

            return nhaSanXuat;
        }

        // PUT: api/NhaSanXuat/5
        [HttpPut("{id}")]
        public IActionResult PutNhaSanXuat(int id, NhaSanXuat nhaSanXuat)
        {
            if (id != nhaSanXuat.MaNSX)
            {
                return BadRequest();
            }

            _context.Entry(nhaSanXuat).State = EntityState.Modified;
            _context.Entry(nhaSanXuat).Property(x => x.SanPhams).IsModified = false;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/NhaSanXuat
        [HttpPost]
        public ActionResult<NhaSanXuat> PostNhaSanXuat(NhaSanXuatDTO nhaSanXuatDTO)
        {
            var nhaSanXuat = new NhaSanXuat
            {
                TenNSX = nhaSanXuatDTO.TenNSX,
                ThongTin = nhaSanXuatDTO.ThongTin
            };

            _context.NhaSanXuats.Add(nhaSanXuat);
            _context.SaveChanges();

            return CreatedAtAction("GetNhaSanXuat", new { id = nhaSanXuat.MaNSX }, nhaSanXuat);
        }


        // DELETE: api/NhaSanXuat/5
        [HttpDelete("{id}")]
        public ActionResult<NhaSanXuat> DeleteNhaSanXuat(int id)
        {
            var nhaSanXuat = _context.NhaSanXuats.Find(id);
            if (nhaSanXuat == null)
            {
                return NotFound();
            }

            _context.NhaSanXuats.Remove(nhaSanXuat);
            _context.SaveChanges();

            return nhaSanXuat;
        }
    }
}
