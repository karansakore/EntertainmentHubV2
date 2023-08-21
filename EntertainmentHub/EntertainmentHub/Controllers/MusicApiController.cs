using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntertainmentHub.Models;

namespace EntertainmentHub.Controllers
{
    public class MusicApiController : ApiController
    {
        MusicClass db = new MusicClass();



        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {
            var file = new FileInfo(@"C:\Users\a881875\Downloads\MusicBook.xlsx");
            var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;
            var list = new List<MusicClass>();
            for (int row = 2; row <= rowCount; row++)
            {
                var item = new MusicClass
                {
                    Sr_No = int.Parse(worksheet.Cells[row, 1].Value.ToString()),
                    Image = worksheet.Cells[row, 2].Value.ToString(),
                    Title = worksheet.Cells[row, 3].Value.ToString(),
                    URL = worksheet.Cells[row, 4].Value.ToString(),
                };
                list.Add(item);
            }
            return Ok(list);
        }



        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData(int id)
        {
            var file = new FileInfo(@"C:\Users\a881875\Downloads\MusicBook.xlsx");
            var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;
            var list = new List<MusicClass>();
            for (int row = 2; row <= rowCount; row++)
            {
                var item = new MusicClass
                {
                    Sr_No = int.Parse(worksheet.Cells[row, 1].Value.ToString()),
                    Image = worksheet.Cells[row, 2].Value.ToString(),
                    Title = worksheet.Cells[row, 3].Value.ToString(),

                    URL = worksheet.Cells[row, 4].Value.ToString(),
                };
                list.Add(item);
            }
            var obj = list.Where(model => model.Sr_No == id).FirstOrDefault();
            return Ok(obj);
        }



        [System.Web.Http.HttpPost]
        public IHttpActionResult PostFriends(MusicClass f)
        {
            var file = new FileInfo(@"C:\Users\a881875\Downloads\MusicBook.xlsx");
            var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;

            var newRow = rowCount + 1;



            // Set the cell values for the new row
            worksheet.Cells[newRow, 1].Value = newRow - 1;
            worksheet.Cells[newRow, 2].Value = f.Image;
            worksheet.Cells[newRow, 3].Value = f.Title;
            worksheet.Cells[newRow, 4].Value = f.URL;



            // Save the changes to the file
            package.Save();
            return Ok();
        }
    }
}
