using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using WebsiteBanHangAPI.Data;

namespace WebsiteBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDatHangController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public DonDatHangController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/DonDatHang
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetDonDatHangs()
        {
            return _context.DonDatHangs.Select(ddh => new
            {
                ddh.MaDDH,
                ddh.NgayDat,
                ddh.TinhTrangGiaoHang,
                ddh.NgayGiao,
                ddh.DaThanhToan,
                ddh.MaKH,
                ddh.UuDai,
                ddh.DaHuy,
                ddh.DaXoa

            }).ToList();
        }

        // GET: api/DonDatHang/5
        [HttpGet("{id}")]
        public ActionResult<DonDatHang> GetDonDatHang(int id)
        {
            var donDatHang = _context.DonDatHangs.Find(id);

            if (donDatHang == null)
            {
                return NotFound();
            }

            return donDatHang;
        }

        // PUT: api/DonDatHang/5
        [HttpPut("{id}")]
        public IActionResult PutDonDatHang(int id, DonDatHang donDatHang)
        {
            if (id != donDatHang.MaDDH)
            {
                return BadRequest();
            }

            _context.Entry(donDatHang).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/DonDatHang
        [HttpPost]
        public ActionResult<DonDatHang> PostDonDatHang(DonDatHangDTO donDatHangDTO)
        {
            var donDatHang = new DonDatHang
            {
                NgayDat = donDatHangDTO.NgayDat,
                TinhTrangGiaoHang = donDatHangDTO.TinhTrangGiaoHang,
                NgayGiao = donDatHangDTO.NgayGiao,
                DaThanhToan = donDatHangDTO.DaThanhToan,
                MaKH = donDatHangDTO.MaKH,
                UuDai = donDatHangDTO.UuDai,
                DaHuy = donDatHangDTO.DaHuy,
                DaXoa = donDatHangDTO.DaXoa


            };
            _context.DonDatHangs.Add(donDatHang);
            _context.SaveChanges();

            return CreatedAtAction("GetDonDatHang", new { id = donDatHang.MaDDH }, donDatHang);
        }

        // DELETE: api/DonDatHang/5
        [HttpDelete("{id}")]
        public ActionResult<DonDatHang> DeleteDonDatHang(int id)
        {
            var donDatHang = _context.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return NotFound();
            }

            _context.DonDatHangs.Remove(donDatHang);
            _context.SaveChanges();

            return donDatHang;
        }
    }
}
