using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class BaoTri
{
    public int BaoTriId { get; set; }

    public int PhongId { get; set; }

    public DateOnly NgayYeuCau { get; set; }

    public string MoTaVanDe { get; set; } = null!;

    public decimal ChiPhiDuKien { get; set; }

    public decimal ChiPhiThucTe { get; set; }

    public DateOnly? NgayHoanThanh { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? NguoiChiuChiPhi { get; set; }

    public virtual PhongTro Phong { get; set; } = null!;
}
