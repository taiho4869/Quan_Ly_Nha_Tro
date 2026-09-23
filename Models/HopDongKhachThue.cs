using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class HopDongKhachThue
{
    public int HopDongId { get; set; }

    public int KhachThueId { get; set; }

    public bool LaNguoiDaiDien { get; set; }

    public DateOnly NgayThamGia { get; set; }

    public DateOnly? NgayRoiDi { get; set; }

    public virtual HopDong HopDong { get; set; } = null!;

    public virtual KhachThue KhachThue { get; set; } = null!;
}
