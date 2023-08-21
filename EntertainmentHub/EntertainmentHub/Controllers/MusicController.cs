using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntertainmentHub.Models;
using OfficeOpenXml;
using System.IO;
using System.Net.Http;


namespace EntertainmentHub.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<MusicClass> list = new List<MusicClass>();
            client.BaseAddress = new Uri("https://localhost:44300/api/MusicApi");
            var response = client.GetAsync("MusicApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<MusicClass>>();
                display.Wait();
                list = display.Result;
            }
            return View(list);
        }

        public ActionResult Details(int id)
        {
            MusicClass f = null;
            client.BaseAddress = new Uri("https://localhost:44300/api/MusicApi");
            var response = client.GetAsync("MusicApi?Sr_No=" + id.ToString());
            response.Wait();



            var test = response.Result;



            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<MusicClass>();
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
        public ActionResult Create(MusicClass f)
        {
            client.BaseAddress = new Uri("https://localhost:44300/api/MusicApi");
            var response = client.PostAsJsonAsync<MusicClass>("MusicApi", f);
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
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44300/api/MusicApi");
        //        var response = client.DeleteAsync($"MusicApi/{id}").Result;



        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            Console.WriteLine("fail");
        //            return View();
        //        }
        //    }
        //}
    }
}