using C4_ChauSolution.IService;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Service
{
    public class HoaDonService: IHoaDonService
    {
        private VatLieuDbContext _context;
        public HoaDonService()
        {
            _context = new VatLieuDbContext();
        }
        public bool Add(HoaDon Hd)
        {
            //try
            //{
                _context.HoaDons.Add(Hd);
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
            var Sp = _context.HoaDons.Find(Id);
            _context.HoaDons.Remove(Sp);
            _context.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAll()
        {

            return _context.HoaDons.ToList();
        }

        public HoaDon GetHDById(Guid Id)
        {
            return _context.HoaDons.FirstOrDefault(p => p.IdHoaDon == Id);
        }



        public bool Update(HoaDon Hd)
        {
            //try
            //{
                var spz = _context.HoaDons.Find(Hd.IdHoaDon);


                _context.HoaDons.Update(spz);
                _context.SaveChanges();
                return true;


            //}
            //catch (Exception)
            //{

            //    return false;
            //}
        }
    }
}
