using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class KhachThue
{
    public int KhachThueId { get; set; }

    public string HoTen { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChiThuongTru { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<HopDongKhachThue> HopDongKhachThues { get; set; } = new List<HopDongKhachThue>();
}
