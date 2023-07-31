using C4_ChauSolution.IService;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Service
{
    public class CartDertailService : ICartDetailService
    {
        private VatLieuDbContext _context;
        public CartDertailService()
        {
            _context = new VatLieuDbContext();
        }
        public bool Create(CartDetail sp)
        {
            //try
            //{
                sp.Id = Guid.NewGuid();
                _context.CartDetails.Add(sp);
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
            var Kh = _context.CartDetails.Find(Id);
            _context.CartDetails.Remove(Kh);
            _context.SaveChanges();
            return true;
        }

        public List<CartDetail> GetAll(Guid id)
        {
            return _context.CartDetails.Where(c=>c.IdKH==id).ToList();
        }

        public CartDetail GetSpById(Guid IdSp, Guid IdKH)
        {
            return _context.CartDetails.FirstOrDefault(p => p.IdKH == IdKH && p.IdChiTietSP == IdSp);
        }

        public bool Update(CartDetail sp)
        {
            try
            {
                var Kh = _context.CartDetails.Find(sp.Id);
                Kh.SoLuong = sp.SoLuong;
                _context.CartDetails.Update(Kh);
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

