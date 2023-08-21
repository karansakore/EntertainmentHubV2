using EntertainmentHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EntertainmentHub.Controllers
{
    public class PDFController : Controller
    {
        // GET: PDF
        
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<PDFclass> list = new List<PDFclass>();
            client.BaseAddress = new Uri("https://localhost:44300/api/PdfApi");
            var response = client.GetAsync("PdfApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<PDFclass>>();
                display.Wait();
                list = display.Result;
                
            }
            
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PDFclass f)
        {
            client.BaseAddress = new Uri("https://localhost:44300/api/PdfApi");
            var response = client.PostAsJsonAsync<PDFclass>("PdfApi", f);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}