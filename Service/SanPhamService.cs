using C4_ChauSolution.IService;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Service
{
    public class SanPhamService : ISanPhamService
    {
        private VatLieuDbContext _context;
        public SanPhamService()
        {
            _context = new VatLieuDbContext();
        }
        public bool Add(ChiTietSanPham sp)
        {
            try
            {
                sp.IdChiTietSP = Guid.NewGuid();
                _context.ChiTietSanPhams.Add(sp);
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
            var Sp = _context.ChiTietSanPhams.Find(Id);
            _context.ChiTietSanPhams.Remove(Sp);
            _context.SaveChanges();
            return true;
        }

        public List<ChiTietSanPham> GetAll()
        {
            
            return _context.ChiTietSanPhams.ToList();
        }

        public ChiTietSanPham GetSpById(Guid Id)
        {
            return _context.ChiTietSanPhams.FirstOrDefault(p => p.IdChiTietSP == Id);
        }

        public List<ChiTietSanPham> GetSpByName(string name)
        {
            return _context.ChiTietSanPhams.Where(p => p.TenSp.Contains(name)).ToList();
        }

        public bool Update(ChiTietSanPham sp)
        {
            try
            {
                var spz = _context.ChiTietSanPhams.Find(sp.IdChiTietSP);

                    spz.TenLoaiSp = sp.TenLoaiSp;
                    spz.TenNhaCungCap = sp.TenNhaCungCap;
                    spz.TenSp = sp.TenSp;
                    spz.TenDanhMuc = sp.TenDanhMuc;
                    spz.TenDonVi = sp.TenDonVi;
                    spz.GiaNhap = sp.GiaNhap;
                    spz.SoLuong = sp.SoLuong;
                    spz.GiaNhap = sp.GiaNhap;   
                    spz.GiaBan = sp.GiaBan;
                    spz.HinhAnh = sp.HinhAnh;
                    _context.ChiTietSanPhams.Update(spz);
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
