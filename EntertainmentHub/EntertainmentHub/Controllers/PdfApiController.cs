using EntertainmentHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OfficeOpenXml;
using System.Drawing;

namespace EntertainmentHub.Controllers
{
    public class PdfApiController : ApiController
    {
        PDFclass db = new PDFclass();


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {
            var file = new FileInfo(@"C:\Users\a881875\Downloads\StoryBooks.xlsx");
            var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;
            var list = new List<PDFclass>();
            for (int row = 2; row <= rowCount; row++)
            {
                var item = new PDFclass
                {
                    image = worksheet.Cells[row,1].Value.ToString(),
                    Name = worksheet.Cells[row, 2].Value.ToString(),
                    Links = worksheet.Cells[row, 3].Value.ToString(),
                };
                list.Add(item);
            }
            return Ok(list);
        }

        

        [System.Web.Http.HttpPost]
        public IHttpActionResult PostFriends(PDFclass f)
        {
            var file = new FileInfo(@"C:\Users\a881875\Downloads\StoryBooks.xlsx");
            var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;
            //******************************************************
            //var list = new List<ExcelData>();
            //for (int row = 2; row <= rowCount; row++)
            //{
            //    var item = new ExcelData
            //    {
            //        Sr_No = int.Parse(worksheet.Cells[row, 1].Value.ToString()),
            //        Name = worksheet.Cells[row, 2].Value.ToString(),
            //        Email = worksheet.Cells[row, 3].Value.ToString(),
            //        Das_Id = worksheet.Cells[row, 4].Value.ToString(),
            //    };
            //    list.Add(item);

            //}
            //list.Add(f);
            //*****************************************************
            // Find the next available row
            var newRow = rowCount + 1;

            // Set the cell values for the new row
            worksheet.Cells[newRow, 1].Value = f.image;
            worksheet.Cells[newRow, 2].Value = f.Name;
            worksheet.Cells[newRow, 3].Value = f.Links;

            // Save the changes to the file
            package.Save();
            return Ok();
        }
    }
}
