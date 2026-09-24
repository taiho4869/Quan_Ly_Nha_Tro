using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoTri> BaoTris { get; set; }

    public virtual DbSet<ChiSoDienNuoc> ChiSoDienNuocs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HopDong> HopDongs { get; set; }

    public virtual DbSet<HopDongKhachThue> HopDongKhachThues { get; set; }

    public virtual DbSet<KhachThue> KhachThues { get; set; }

    public virtual DbSet<PhongTro> PhongTros { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BaoTri>(entity =>
        {
            entity.HasKey(e => e.BaoTriId).HasName("PK__BaoTri__56159A50CB47686B");

            entity.ToTable("BaoTri");

            entity.Property(e => e.ChiPhiDuKien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChiPhiThucTe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MoTaVanDe).HasMaxLength(500);
            entity.Property(e => e.NgayYeuCau).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguoiChiuChiPhi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("CHU_TRO");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("CHO_XU_LY");

            entity.HasOne(d => d.Phong).WithMany(p => p.BaoTris)
                .HasForeignKey(d => d.PhongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaoTri_Phong");
        });

        modelBuilder.Entity<ChiSoDienNuoc>(entity =>
        {
            entity.HasKey(e => e.ChiSoId).HasName("PK__ChiSoDie__3746C156E9749FA4");

            entity.ToTable("ChiSoDienNuoc");

            entity.HasIndex(e => new { e.PhongId, e.Thang, e.Nam }, "UQ_ChiSo_Phong_ThangNam").IsUnique();

            entity.Property(e => e.DienCu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DienMoi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgayGhi).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NuocCu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NuocMoi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TieuThuDien)
                .HasComputedColumnSql("([DienMoi]-[DienCu])", false)
                .HasColumnType("decimal(19, 2)");
            entity.Property(e => e.TieuThuNuoc)
                .HasComputedColumnSql("([NuocMoi]-[NuocCu])", false)
                .HasColumnType("decimal(19, 2)");

            entity.HasOne(d => d.Phong).WithMany(p => p.ChiSoDienNuocs)
                .HasForeignKey(d => d.PhongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiSo_Phong");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.ChiTietHoaDonId).HasName("PK__ChiTietH__6BB67135ED5F235E");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoaiKhoanThu)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NoiDung).HasMaxLength(255);
            entity.Property(e => e.SoLuong)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("(CONVERT([decimal](18,2),[SoLuong]*[DonGia]))", false)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.DichVu).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.DichVuId)
                .HasConstraintName("FK_ChiTietHoaDon_DichVu");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.HoaDonId)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.DichVuId).HasName("PK__DichVu__8DB8EDC18E7ACDA2");

            entity.ToTable("DichVu");

            entity.HasIndex(e => e.TenDichVu, "UQ_DichVu_Ten").IsUnique();

            entity.Property(e => e.DonGiaHienTai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenDichVu).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.HoaDonId).HasName("PK__HoaDon__6956CE499B86CA30");

            entity.ToTable("HoaDon");

            entity.HasIndex(e => new { e.HopDongId, e.Thang, e.Nam }, "UQ_HoaDon_HopDong_ThangNam").IsUnique();

            entity.Property(e => e.NgayLap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("CHUA_THANH_TOAN");

            entity.HasOne(d => d.HopDong).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.HopDongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_HopDong");
        });

        modelBuilder.Entity<HopDong>(entity =>
        {
            entity.HasKey(e => e.HopDongId).HasName("PK__HopDong__A2D6D347AE0FED25");

            entity.ToTable("HopDong");

            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienCoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("HIEU_LUC");

            entity.HasOne(d => d.Phong).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.PhongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_Phong");
        });

        modelBuilder.Entity<HopDongKhachThue>(entity =>
        {
            entity.HasKey(e => new { e.HopDongId, e.KhachThueId });

            entity.ToTable("HopDong_KhachThue");

            entity.HasIndex(e => e.HopDongId, "UX_HopDong_NguoiDaiDien")
                .IsUnique()
                .HasFilter("([LaNguoiDaiDien]=(1))");

            entity.Property(e => e.NgayThamGia).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HopDong).WithOne(p => p.HopDongKhachThue)
                .HasForeignKey<HopDongKhachThue>(d => d.HopDongId)
                .HasConstraintName("FK_HDKT_HopDong");

            entity.HasOne(d => d.KhachThue).WithMany(p => p.HopDongKhachThues)
                .HasForeignKey(d => d.KhachThueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HDKT_KhachThue");
        });

        modelBuilder.Entity<KhachThue>(entity =>
        {
            entity.HasKey(e => e.KhachThueId).HasName("PK__KhachThu__9FD07F1C8DD93AFF");

            entity.ToTable("KhachThue");

            entity.HasIndex(e => e.Cccd, "UQ_KhachThue_CCCD").IsUnique();

            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChiThuongTru).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<PhongTro>(entity =>
        {
            entity.HasKey(e => e.PhongId).HasName("PK__PhongTro__FC6699A7D9656898");

            entity.ToTable("PhongTro");

            entity.HasIndex(e => e.SoPhong, "UQ_PhongTro_SoPhong").IsUnique();

            entity.Property(e => e.DienTich).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.SoPhong)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tang).HasDefaultValue(1);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("TRONG");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.ThanhToanId).HasName("PK__ThanhToa__24A8D6E48E01FAD2");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NgayThanhToan).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PhuongThuc)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.HoaDonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_HoaDon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
