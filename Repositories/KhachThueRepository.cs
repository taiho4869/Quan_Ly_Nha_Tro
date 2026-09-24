using Microsoft.EntityFrameworkCore;
using Quan_Ly_Nha_Tro.Interfaces.IRepositoties;
using Quan_Ly_Nha_Tro.Models;

namespace Quan_Ly_Nha_Tro.Repositories
{
    public class KhachThueRepository: IKhachThueRepository
    {
        private readonly AppDbContext _context;
        public KhachThueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<KhachThue>> GetAllKhachThueAsync()
        {
            return await _context.KhachThues.ToListAsync();
        }
        public async Task<KhachThue?> GetKhachThueByIdAsync(int id)
        {
            return await _context.KhachThues.FindAsync(id);
        }

        public async Task<KhachThue> CreateKhachThueAsync(KhachThue khachThue)
        {
            _context.KhachThues.Add(khachThue);
            await _context.SaveChangesAsync();
            return khachThue;
        }

        public async Task<KhachThue?> UpdateKhachThueAsync(int id, KhachThue khachThue)
        {
            var existingKhachThue = await _context.KhachThues.FindAsync(id);
            if (existingKhachThue == null)
            {
                return null;
            }
            existingKhachThue.HoTen = khachThue.HoTen;
            existingKhachThue.SoDienThoai = khachThue.SoDienThoai;
            existingKhachThue.Cccd = khachThue.Cccd;
            existingKhachThue.NgaySinh = khachThue.NgaySinh;
            existingKhachThue.GioiTinh = khachThue.GioiTinh;
            existingKhachThue.DiaChiThuongTru = khachThue.DiaChiThuongTru;
            existingKhachThue.TrangThai = khachThue.TrangThai;
            await _context.SaveChangesAsync();
            return existingKhachThue;
        }


    }
}
