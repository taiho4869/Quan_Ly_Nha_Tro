using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class HopDong
{
    public int HopDongId { get; set; }

    public int PhongId { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public decimal GiaThue { get; set; }

    public decimal TienCoc { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual HopDongKhachThue? HopDongKhachThue { get; set; }

    public virtual PhongTro Phong { get; set; } = null!;
}
