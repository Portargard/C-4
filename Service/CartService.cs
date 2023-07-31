using C4_ChauSolution.IService;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Service
{
    public class CartService : ICartService
    {
        private VatLieuDbContext _context;
        public CartService()
        {
            _context = new VatLieuDbContext();
        }
        public bool Create(Guid id)
        {
            var sp = new Cart()
            {
                IdKH = id,
                Description = "Khong"
            };
            _context.Carts.Add(sp);
            _context.SaveChanges();
            return true;
        }
    }
}
