using C4_ChauSolution.Models;

namespace C4_ChauSolution.IService
{
    public interface IChiTietHoaDonService
    {
        public bool Add(ChiTietHoaDon cthd);
        public bool Update(ChiTietHoaDon cthd);
        public bool Delete(Guid Id);
        public List<ChiTietHoaDon> GetAll();
        public ChiTietHoaDon GetCTHDById(Guid cthd);
    }
}
