using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_ChauSolution.Models
{
    public class HoaDon
    {
        public Guid IdHoaDon { get; set; }
        public Guid IdNhanVien { get; set; }
        public int TongTien { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    }
}
