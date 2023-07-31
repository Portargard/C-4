using C4_ChauSolution.Models;

namespace C4_ChauSolution.IService
{
    public interface IHoaDonService
    {
        public bool Add(HoaDon Hd);
        public bool Update(HoaDon Hd);
        public bool Delete(Guid Id);
        public List<HoaDon> GetAll();
        public HoaDon GetHDById(Guid Id);
    }
}
