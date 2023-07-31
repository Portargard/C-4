using C4_ChauSolution.IService;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Service
{
    public class KhachHangService : IKhachHangService
    {
        private VatLieuDbContext _context;
        public KhachHangService()
        {
            _context = new VatLieuDbContext();
        }
        public bool Create(KhachHang sp)
        {
            try
            {
                sp.IdKH = Guid.NewGuid();
                _context.KhachHangs.Add(sp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            var Kh = _context.KhachHangs.Find(Id);
            _context.KhachHangs.Remove(Kh);
            _context.SaveChanges();
            return true;
        }

        public List<KhachHang> GetAll()
        {
            return _context.KhachHangs.ToList();
        }

        public KhachHang GetSpById(Guid Id)
        {
            return _context.KhachHangs.FirstOrDefault(p => p.IdKH == Id);
        }

        public KhachHang GetSpByName(string name)
        {
            return _context.KhachHangs.FirstOrDefault(p=>p.TenKh.Contains(name));
        }

        public bool Update(KhachHang sp)
        {
            try
            {
                KhachHang Kh = _context.KhachHangs.Find(sp.IdKH);
                Kh.TenKh = sp.TenKh;
                Kh.DiaChi = sp.DiaChi;
                Kh.SDT = sp.SDT;
                Kh.GioiTinh = sp.GioiTinh;
                _context.KhachHangs.Update(Kh);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
