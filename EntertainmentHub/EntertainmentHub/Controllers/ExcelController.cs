using EntertainmentHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EntertainmentHub.Controllers
{
    public class ExcelController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Excel
        public ActionResult Index()
        {
            
            List<ExcelData> list = new List<ExcelData>();
            client.BaseAddress = new Uri("https://localhost:44300/api/ExcelApi");
            var response = client.GetAsync("ExcelApi");
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<ExcelData>>();
                display.Wait();
                list = display.Result;
            }
            return View(list);
        }

        public ActionResult Details(int id)
        {
            ExcelData f = null;
            client.BaseAddress = new Uri("https://localhost:44300/api/ExcelApi");
            var response = client.GetAsync("ExcelApi?Sr_No=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ExcelData>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExcelData f)
        {
            client.BaseAddress = new Uri("https://localhost:44300/api/ExcelApi");
            var response = client.PostAsJsonAsync<ExcelData>("ExcelApi", f);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //public ActionResult Delete(int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44300/api/");
        //        var response = client.DeleteAsync($"ExcelApi/{id}").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            Console.WriteLine("fail");
        //            return View();
        //        }
        //    }
        //}
    }
}