using C4_ChauSolution.Models;

namespace C4_ChauSolution.IService
{
    public interface ICartDetailService
    {
        public bool Create(CartDetail sp);
        public bool Update(CartDetail sp);
        public bool Delete(Guid Id);
        public List<CartDetail> GetAll(Guid id);
        public CartDetail GetSpById(Guid IdSp, Guid IdKH);
    }
}
