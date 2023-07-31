namespace C4_ChauSolution.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid IdChiTietSP { get; set; }
        public Guid IdKH { get; set; }
        public int SoLuong { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
