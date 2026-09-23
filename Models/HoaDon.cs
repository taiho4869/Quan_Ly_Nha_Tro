using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class HoaDon
{
    public long HoaDonId { get; set; }

    public int HopDongId { get; set; }

    public int Thang { get; set; }

    public int Nam { get; set; }

    public DateOnly NgayLap { get; set; }

    public DateOnly? HanThanhToan { get; set; }

    public decimal TongTien { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual HopDong HopDong { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
