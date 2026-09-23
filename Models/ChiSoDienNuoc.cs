using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class ChiSoDienNuoc
{
    public long ChiSoId { get; set; }

    public int PhongId { get; set; }

    public int Thang { get; set; }

    public int Nam { get; set; }

    public DateOnly NgayGhi { get; set; }

    public decimal DienCu { get; set; }

    public decimal DienMoi { get; set; }

    public decimal NuocCu { get; set; }

    public decimal NuocMoi { get; set; }

    public decimal? TieuThuDien { get; set; }

    public decimal? TieuThuNuoc { get; set; }

    public virtual PhongTro Phong { get; set; } = null!;
}
