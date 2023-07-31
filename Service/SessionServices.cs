using C4_ChauSolution.Models;
using Newtonsoft.Json;

namespace C4_ChauSolution.Service
{
    public class SessionServices
    {
        public static KhachHang GetObjFromSession(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return null;
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var KhachHangs = JsonConvert.DeserializeObject<KhachHang>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return KhachHangs;
        }


        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static List<CartDetail> GetObjFromSession1(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<CartDetail>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var CartDetails = JsonConvert.DeserializeObject<List<CartDetail>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return CartDetails;
        }
        public static List<ChiTietSanPham> GetObjRollBack(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<ChiTietSanPham>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var CartDetails = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return CartDetails;
        }
        public static List<ChiTietHoaDon> GetObjFromSession2(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<ChiTietHoaDon>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var CartDetails = JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return CartDetails;
        }
        public static List<HoaDon> GetObjFromSession3(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<HoaDon>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var CartDetails = JsonConvert.DeserializeObject<List<HoaDon>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return CartDetails;
        }
        public static bool CheckObjInList(Guid id, List<CartDetail> CartDetails)
        {
            return CartDetails.Any(x => x.IdChiTietSP == id);
        }
    }
}
