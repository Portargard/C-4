using C4_ChauSolution.Models;

namespace C4_ChauSolution.IService
{
    public interface ISanPhamService
    {
        public bool Add(ChiTietSanPham sp);
        public bool Update(ChiTietSanPham sp);
        public bool Delete(Guid Id);
        public List<ChiTietSanPham> GetAll();
        public ChiTietSanPham GetSpById(Guid Id);
        public List<ChiTietSanPham> GetSpByName(string name);
    }
}
