using Microsoft.AspNetCore.Mvc;

namespace C4_ChauSolution.Controllers
{
    public class TranferControlller : Controller
    {
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
    }
}
