using System.Diagnostics;
using System.Text.RegularExpressions;
using C4_ChauSolution.IService;
using C4_ChauSolution.Models;
using C4_ChauSolution.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace C4_ChauSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanPhamService spService;
        private readonly ICartDetailService cartService;
        private readonly IKhachHangService khachHangService;
        private readonly IHoaDonService hoaDonService;
        private readonly IChiTietHoaDonService chiTietHoaDonService;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            spService = new SanPhamService();
            cartService = new CartDertailService();
            khachHangService = new KhachHangService();
            hoaDonService = new HoaDonService();
            chiTietHoaDonService = new ChiTietHoaDonService();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        #region crud sp
        public IActionResult ShowListSp(string namezzz = "")
        {
            if (namezzz == string.Empty)
            {
                return View(spService.GetAll().OrderByDescending(c=>c.SoLuong*c.GiaBan));
            }
            return View(spService.GetSpByName(namezzz).OrderByDescending(c => c.SoLuong * c.GiaBan));
        }
        public IActionResult AddSp1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSp1(ChiTietSanPham sp, [Bind] IFormFile imageFile)
        {
            var x = imageFile.FileName; // only for debug
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                sp.HinhAnh = imageFile.FileName;
            }
            if (spService.Add(sp))
            {
                return RedirectToAction("ShowListSp");
            }
            return BadRequest();
        }
        public IActionResult DetailSp(Guid Id)
        {
            ViewBag.SP = spService.GetSpById(Id);
            return View();
        }

        public IActionResult DeleteSp(Guid Id)
        {
            SessionServices.SetObjToSession(HttpContext.Session, "RollBack", spService.GetAll().Where(c => c.IdChiTietSP == Id));
            if (spService.Delete(Id))
            {
                return RedirectToAction("ShowListSp");
            }
            else return View("ShowListSp");
        }
        [HttpGet]
        public IActionResult UpdateSp(Guid Id)
        {
            return View(spService.GetSpById(Id));
        }
        public IActionResult UpdateSp(ChiTietSanPham s)
        {
            var ctsp = spService.GetAll().FirstOrDefault(c => c.IdChiTietSP == s.IdChiTietSP);
            HttpContext.Session.SetString("CTSP", JsonConvert.SerializeObject(ctsp));
            s.HinhAnh = ctsp.HinhAnh;
            //var list1 = spService.GetAll().Where(c => c.TenSp == s.TenSp && c.IdChiTietSP != s.IdChiTietSP);
            //var list2 = list1.Where(c => c.TenNhaCungCap == s.TenNhaCungCap);
            //if (list1.Count() == 0 || list2.Count() == 0)
            //{
                if (spService.Update(s))
                {
                    return RedirectToAction("ShowListSp");
                }
                else
                {
                    return Content("Sai Dau Do");
                }
            //}
            //return Content("Bi trung Sp nao do"); ;
        }
        #endregion


        #region Gio Hang
        public IActionResult ShowListCart()
        {
            ViewData["KH"] = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            if (SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang") != null)
            {
                var kh = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
                return View(cartService.GetAll(kh.IdKH));
            }
            else
            {
                return View(SessionServices.GetObjFromSession1(HttpContext.Session, "Cart"));
            }
        }
        public IActionResult ThemSPVaoCart(CartDetail cartDetail)
        {

            
            var kh = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            if (kh == null)
            {
                // Lấy được dữ liệu sản phẩm
                //var product = sanPhamSevice.GetProductById(ghct.IDSP);
                // Lấy dữ liệu từ Cart (Trong Session)
                var products = SessionServices.GetObjFromSession1(HttpContext.Session, "Cart");
                // Kiểm tra xem list dữ liệu đó có phần tử nào chưa...
                cartDetail.IdKH = Guid.Parse("28AD0A75-8D6F-429C-8520-7019CD588C28");
                if (products.Count == 0)
                {
                    cartDetail.Id = Guid.NewGuid();
                    products.Add(cartDetail);
                    SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                }
                else
                {
                    if (SessionServices.CheckObjInList(cartDetail.IdChiTietSP, products))
                    {
                        var sp = SessionServices.GetObjFromSession1(HttpContext.Session, "Cart");
                        foreach (var x in sp)
                        {
                            if (x.IdChiTietSP==cartDetail.IdChiTietSP)
                            {
                                x.SoLuong+=cartDetail.SoLuong;
                            }
                        }
                        SessionServices.SetObjToSession(HttpContext.Session, "Cart", sp);
                        var zz = SessionServices.GetObjFromSession1(HttpContext.Session, "Cart");
                    }
                    else
                    {
                        cartDetail.Id = Guid.NewGuid();
                        products.Add(cartDetail);  // Nếu chưa có sản phẩm đó trong list thì thêm vào
                                             // Sau đó gán lại giá trị vào trong Session
                        SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                        
                    }
                }
                return RedirectToAction("ShowListCart");
            }
            else
            {
                cartDetail.IdKH = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang").IdKH;
                if (cartService.GetSpById(cartDetail.IdChiTietSP, cartDetail.IdKH) == null)
                {
                    cartService.Create(cartDetail);
                    SessionServices.SetObjToSession(HttpContext.Session, "Cart", cartDetail);
                    return RedirectToAction("ShowListCart");
                }
                else
                {
                    var spCart = cartService.GetSpById(cartDetail.IdChiTietSP, cartDetail.IdKH);
                    spCart.SoLuong += cartDetail.SoLuong;
                    cartService.Update(spCart);
                    SessionServices.SetObjToSession(HttpContext.Session, "Cart", cartDetail);
                    return RedirectToAction("ShowListCart");
                }
            }

        }
        public IActionResult XoaSPCart(Guid id)
        {
            var kh = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            var cartDt = cartService.GetAll(kh.IdKH).Find(c => c.Id == id);
            if (cartService.Delete(cartDt.Id))
            {
                return RedirectToAction("ShowListCart");
            }
            return BadRequest();
        }

        #endregion


        #region Khach Hang
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }

        public IActionResult DangNhap(KhachHang name)
        {
            var kh = khachHangService.GetAll().FirstOrDefault(c=>c.TaiKoan==name.TaiKoan && c.MatKhau==name.MatKhau);
            SessionServices.SetObjToSession(HttpContext.Session, "KhachHang", kh);
            ViewData["KH"] = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            SessionServices.GetObjFromSession1(HttpContext.Session, "Cart").Clear();
            return RedirectToAction("ShowSP");
        }
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(KhachHang kh)
        {
            if (khachHangService.Create(kh))
            {
                SessionServices.SetObjToSession(HttpContext.Session, "KhachHang", kh);
                ViewData["KH"] = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
                return RedirectToAction("ShowSP");
            }
            return BadRequest();
        }
        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("KhachHang");
            return RedirectToAction("ShowSP");
        }
        #endregion


        #region Hoa Don
        public IActionResult ThanhToan(Guid Id)
        {
            var kh = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            
            Guid guidId = Guid.NewGuid();
            var hd = new HoaDon() { IdHoaDon = guidId, NgayTao = DateTime.Now, NgayThanhToan = DateTime.Now, TrangThai = 0, IdNhanVien = Guid.Parse("37ce2576-c198-4659-af7b-35fdb617a150") };
            int tt = 0;
            if (kh!= null)
            {
                var cart = cartService.GetSpById(Id, kh.IdKH);
                if (hoaDonService.Add(hd))
                {
                    var cthd = new ChiTietHoaDon()
                    {
                        IdHoaDon = hd.IdHoaDon,
                        IdCTHoaDon = Guid.NewGuid(),
                        IdChiTietSP = cart.IdChiTietSP,
                        DonGia = spService.GetSpById(cart.IdChiTietSP).GiaBan,
                        SoLuongMua = cart.SoLuong
                    };
                    var sp = spService.GetSpById(cart.IdChiTietSP);
                    sp.SoLuong = sp.SoLuong - cart.SoLuong;
                    if (chiTietHoaDonService.Add(cthd))
                    {
                        if (spService.Update(sp))
                        {
                            tt += (cthd.SoLuongMua * cthd.DonGia);
                        }
                    };
                }
                hd.TongTien = tt;
                if (hoaDonService.Update(hd))
                {
                    if (cartService.Delete(cart.Id))
                    {
                        return RedirectToAction("ListHoaDon");
                    };
                };
                return BadRequest();
            }
            else
            {
                var cart1 = SessionServices.GetObjFromSession1(HttpContext.Session, "Cart").FirstOrDefault(c => c.IdChiTietSP == Id);
                if (hoaDonService.Add(hd))
                {
                    var cthd = new ChiTietHoaDon()
                    {
                        IdHoaDon = hd.IdHoaDon,
                        IdCTHoaDon = Guid.NewGuid(),
                        IdChiTietSP = cart1.IdChiTietSP,
                        DonGia = spService.GetSpById(cart1.IdChiTietSP).GiaBan,
                        SoLuongMua = cart1.SoLuong
                    };
                    var sp = spService.GetSpById(cart1.IdChiTietSP);
                    sp.SoLuong = sp.SoLuong - cart1.SoLuong;
                    if (chiTietHoaDonService.Add(cthd))
                    {
                        if (spService.Update(sp))
                        {
                            var cartDelete = SessionServices.GetObjFromSession1(HttpContext.Session, "Cart");
                            var cart2 = SessionServices.GetObjFromSession1(HttpContext.Session, "Cart").FirstOrDefault(c => c.IdChiTietSP == Id);
                            var find = cartDelete.FindIndex(c=>c.IdChiTietSP==cart2.IdChiTietSP);
                            cartDelete.RemoveAt(find);
                            SessionServices.SetObjToSession(HttpContext.Session, "Cart", cartDelete);
                            tt += (cthd.SoLuongMua * cthd.DonGia);
                        }
                    };
                }
                hd.TongTien = tt;
                if (hoaDonService.Update(hd))
                {
                    return RedirectToAction("ListHoaDon");
                };
                return BadRequest();
            }
        }
        public IActionResult ListHoaDon()
        {
            return View(hoaDonService.GetAll());
        }
        public IActionResult ShowCTHoaDon(Guid Id)
        {
            var kh = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            return View(chiTietHoaDonService.GetAll().Where(c => c.IdHoaDon == Id));
        }
        public IActionResult DeleteHd(Guid id)
        {
            if (hoaDonService.GetHDById(id) != null)
            {
                foreach (var x in chiTietHoaDonService.GetAll().Where(c => c.IdCTHoaDon == id))
                {
                    if (chiTietHoaDonService.Delete(x.IdCTHoaDon))
                    {
                        continue;
                    }
                }
                if (hoaDonService.Delete(id))
                {
                    return RedirectToAction("ListHoaDon");
                }
            }
            return BadRequest();
        }
        #endregion


        #region Bai lam tren lop
        //public IActionResult Lab_5_6_ShowSession()
        //{
        //    string data = HttpContext.Session.GetString("CTSP");
        //    if (data == null)
        //    {
        //        return Content("Session đã bị xóa");
        //    }
        //    var ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(data);
        //    return View(ctsp);
        //}
        public IActionResult Lab_5_6_Rollback(Guid id)
        {
            string data = HttpContext.Session.GetString("CTSP");
            var ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(data).FirstOrDefault(c => c.IdChiTietSP == id);
            if (data == null)
            {
                return Content("Session đã bị xóa");
            }
            else
            {
                if (spService.Update(ctsp))
                {
                    return RedirectToAction("ShowListSp");
                }
                else
                {
                    return NotFound();
                }
            }

        }
        public IActionResult ShowSP()
        {
            ViewData["KH"] = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
            return View(spService.GetAll());
        }
        public IActionResult TransferData()
        {
            string[] tranfer = { "Chạ", " hiệu", " cái", " task", " cụa", " thầy", " là ", "gì?" };
            List<string> tranfer1 = new List<string>()
            {
                "Chạ"," hiệu"," cái"," task"," cụa"," thầy"," là ", "gì?"
            };
            string tranfer2 = "Chạ hiệu cái task cụa thầy là gì?";
            HttpContext.Session.SetString("tranfer2", tranfer2);

            ViewBag.Tranfer = tranfer;
            ViewData["Transfer1"] = tranfer1;
            string sessssion = HttpContext.Session.GetString("tranfer2");
            ViewData["transssf"] = sessssion;
            return View();
        }
        #endregion


        #region on Tap
        [HttpGet]
        public IActionResult Loggin()
        {
            return View();
        }
        
        public IActionResult Loggin(KhachHang khachHang)
        {
            if (Regex.IsMatch(khachHang.TaiKoan, "[!@#$&*]") == true)
            {

                return Content("Sai o dau do");
            }
            else
            {
                var kh = khachHangService.GetAll().FirstOrDefault(c => c.TaiKoan == khachHang.TaiKoan && c.MatKhau == khachHang.MatKhau);
                SessionServices.SetObjToSession(HttpContext.Session, "KhachHang", kh);
                ViewData["KH"] = SessionServices.GetObjFromSession(HttpContext.Session, "KhachHang");
                SessionServices.GetObjFromSession1(HttpContext.Session, "Cart").Clear();
                return RedirectToAction("ShowSp");
            }
        }
        public IActionResult Lab_5_6_ShowSession()
        {
            var data = SessionServices.GetObjRollBack(HttpContext.Session, "RollBack");
            if (data == null)
            {
                return Content("Session đã bị xóa");
            }
            return View(data);
        }
        public IActionResult RollBack(Guid id)
        {
            var data = SessionServices.GetObjRollBack(HttpContext.Session, "RollBack").FirstOrDefault(c => c.IdChiTietSP == id);
            if (spService.Add(data))
            {
                return RedirectToAction("ShowListSp");
            }
            return Content("Sai Dau Do");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//