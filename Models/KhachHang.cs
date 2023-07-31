using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_ChauSolution.Models
{
    public class KhachHang
    {
        public Guid IdKH { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public int GioiTinh { get; set; }
        public string TaiKoan { get; set; }
        public string MatKhau { get; set; }
        public virtual Cart Carts { get; set; }
    }
}
