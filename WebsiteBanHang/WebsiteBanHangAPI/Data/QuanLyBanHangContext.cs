using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;

namespace WebsiteBanHangAPI.Data
{
    public partial class QuanLyBanHangContext : DbContext
    {
        public QuanLyBanHangContext(DbContextOptions<QuanLyBanHangContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>().ToTable("SanPham");
            modelBuilder.Entity<ChiTietDonDatHang>().ToTable("ChiTietDonDatHang");
            modelBuilder.Entity<BinhLuan>().ToTable("BinhLuan");
            modelBuilder.Entity<ChiTietPhieuNhap>().ToTable("ChiTietPhieuNhap");
            modelBuilder.Entity<LoaiSanPham>().ToTable("LoaiSanPham");
            modelBuilder.Entity<LoaiThanhVien>().ToTable("LoaiThanhVien");
            modelBuilder.Entity<LoaiThanhVien_Quyen>().ToTable("LoaiThanhVien_Quyen");
            modelBuilder.Entity<NhaCungCap>().ToTable("NhaCungCap");
            modelBuilder.Entity<NhaSanXuat>().ToTable("NhaSanXuat");
            modelBuilder.Entity<PhieuNhap>().ToTable("PhieuNhap");
            modelBuilder.Entity<Quyen>().ToTable("Quyen");
            modelBuilder.Entity<ThanhVien>().ToTable("ThanhVien");
            modelBuilder.Entity<DonDatHang>().ToTable("DonDatHang");


        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LoaiThanhVien> LoaiThanhViens { get; set; }
        public virtual DbSet<LoaiThanhVien_Quyen> LoaiThanhVien_Quyen { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }

    }
}
