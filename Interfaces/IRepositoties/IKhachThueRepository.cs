using Quan_Ly_Nha_Tro.Models;

namespace Quan_Ly_Nha_Tro.Interfaces.IRepositoties
{
    public interface IKhachThueRepository
    {
        public Task<List<KhachThue>> GetAllKhachThueAsync();
        public Task<KhachThue?> GetKhachThueByIdAsync(int id);
        public Task<KhachThue> CreateKhachThueAsync(KhachThue khachThue);
        public Task<KhachThue?> UpdateKhachThueAsync(int id, KhachThue khachThue);

    }
}
