using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class ChiTietHoaDon
{
    public long ChiTietHoaDonId { get; set; }

    public long HoaDonId { get; set; }

    public int? DichVuId { get; set; }

    public string LoaiKhoanThu { get; set; } = null!;

    public string? NoiDung { get; set; }

    public decimal SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual DichVu? DichVu { get; set; }

    public virtual HoaDon HoaDon { get; set; } = null!;
}
