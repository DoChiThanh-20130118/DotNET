using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public BinhLuanController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/BinhLuan
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetBinhLuans()
        {
            return _context.BinhLuans.Select(bl => new
            {
                bl.MaBL,
                bl.NoidungBL,
                bl.MaThanhVien,
                bl.MaSP
            }).ToList();
        }

        // GET: api/BinhLuan/5
        [HttpGet("{id}")]
        public ActionResult<BinhLuan> GetBinhLuan(int id)
        {
            var binhLuan = _context.BinhLuans.Find(id);

            if (binhLuan == null)
            {
                return NotFound();
            }

            return binhLuan;
        }

        // PUT: api/BinhLuan/5
        [HttpPut("{id}")]
        public IActionResult PutBinhLuan(int id, BinhLuan binhLuan)
        {
            if (id != binhLuan.MaBL)
            {
                return BadRequest();
            }

            _context.Entry(binhLuan).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/BinhLuan
        [HttpPost]
        public ActionResult<BinhLuan> PostBinhLuan(BinhLuanDTO binhLuanDTO)
        {
            var binhLuan = new BinhLuan
            {
                NoidungBL = binhLuanDTO.NoidungBL,
                MaThanhVien = binhLuanDTO.MaThanhVien,
                MaSP = binhLuanDTO.MaSP
              
            };


            _context.BinhLuans.Add(binhLuan);
            _context.SaveChanges();

            return CreatedAtAction("GetBinhLuan", new { id = binhLuan.MaBL }, binhLuan);
        }

        // DELETE: api/BinhLuan/5
        [HttpDelete("{id}")]
        public ActionResult<BinhLuan> DeleteBinhLuan(int id)
        {
            var binhLuan = _context.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            _context.BinhLuans.Remove(binhLuan);
            _context.SaveChanges();

            return binhLuan;
        }
    }
}
