using System;
using System.Collections.Generic;

namespace Quan_Ly_Nha_Tro.Models;

public partial class PhongTro
{
    public int PhongId { get; set; }

    public string SoPhong { get; set; } = null!;

    public int Tang { get; set; }

    public decimal DienTich { get; set; }

    public decimal GiaThue { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<BaoTri> BaoTris { get; set; } = new List<BaoTri>();

    public virtual ICollection<ChiSoDienNuoc> ChiSoDienNuocs { get; set; } = new List<ChiSoDienNuoc>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();
}
