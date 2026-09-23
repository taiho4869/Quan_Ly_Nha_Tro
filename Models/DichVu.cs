using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class DichVu
{
    public int DichVuId { get; set; }

    public string TenDichVu { get; set; } = null!;

    public decimal DonGiaHienTai { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
