using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class ThanhToan
{
    public long ThanhToanId { get; set; }

    public long HoaDonId { get; set; }

    public decimal SoTien { get; set; }

    public DateTime NgayThanhToan { get; set; }

    public string PhuongThuc { get; set; } = null!;

    public string? MaGiaoDich { get; set; }

    public string? GhiChu { get; set; }

    public virtual HoaDon HoaDon { get; set; } = null!;
}
