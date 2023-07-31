using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_ChauSolution.Models
{
    public class NhanVien
    {
        public Guid IdNhanVien { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
        public bool TrangThaiPass { get; set; }
        public string TenNv { get; set; }
        public DateTime NamSinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public virtual List<HoaDon> HoaDons { get; set; }
       
    }
}
