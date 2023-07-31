using C4_ChauSolution.Models;

namespace C4_ChauSolution.IService
{
    public interface IKhachHangService
    {
        public bool Create(KhachHang sp);
        public bool Update(KhachHang sp);
        public bool Delete(Guid Id);
        public List<KhachHang> GetAll();
        public KhachHang GetSpById(Guid Id);
        public KhachHang GetSpByName(string name);
    }
}
