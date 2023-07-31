using C4_ChauSolution.IService;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Service
{
    public class ChiTietHoaDonService : IChiTietHoaDonService
    {
        private VatLieuDbContext _context;
        public ChiTietHoaDonService()
        {
            _context = new VatLieuDbContext();
        }
        public bool Add(ChiTietHoaDon cthd)
        {
            //try
            //{
                cthd.IdCTHoaDon = Guid.NewGuid();
                _context.ChiTietHoaDons.Add(cthd);
                _context.SaveChanges();
                return true;
            //}
            //catch (Exception)
            //{

            //    return false;
            //}
        }

        public bool Delete(Guid Id)
        {
            var Sp = _context.ChiTietHoaDons.Find(Id);
            _context.ChiTietHoaDons.Remove(Sp);
            _context.SaveChanges();
            return true;
        }

        public List<ChiTietHoaDon> GetAll()
        {

            return _context.ChiTietHoaDons.ToList();
        }

        public ChiTietHoaDon GetCTHDById(Guid Id)
        {
            return _context.ChiTietHoaDons.FirstOrDefault(p => p.IdCTHoaDon == Id);
        }

        public bool Update(ChiTietHoaDon cthd)
        {
            try
            {
                var spz = _context.ChiTietHoaDons.Find(cthd.IdHoaDon);


                _context.ChiTietHoaDons.Update(spz);
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
