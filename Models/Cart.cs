namespace C4_ChauSolution.Models
{
    public class Cart
    {
        public Guid IdKH { get; set; }
        public string Description { get; set; }
        

        public virtual KhachHang KhachHangs { get; set; }
        public virtual IList<CartDetail> CartDetails { get; set; }
    }
}
