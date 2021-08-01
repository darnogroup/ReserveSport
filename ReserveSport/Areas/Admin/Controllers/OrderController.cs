using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Hosting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Access(1)]
    public class OrderController : Controller
    {
        private readonly IOrderService _order;
        private IHostingEnvironment _hostingEnvironment;
       
        public OrderController(IOrderService order, IHostingEnvironment hostingEnvironment)
        {
            _order = order; _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet][Route("/Admin/Orders/{search?}")]
        public IActionResult Index(string search="",int page=1)
        {
            ViewBag.Search = search;
            var model = _order.GetFinishedOrders(search??"",page);
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Order/{id}")]
        public IActionResult Order(int id)
        {
            var model = _order.GetItemOrder(id).Result;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/RemoveOrder/{id}")]
        public void RemoveOrder(int id)
        {
            _order.RemoveOrder(id);
        }
        [HttpGet]
        [Route("/Admin/RemoveOrderItem/{id}")]
        public void RemoveOrderItem(int id)
        {
            _order.RemoveOrderItem(id);
        }

        [HttpGet]
        [Route("/Admin/Finish-Orders/{search?}")]
        public IActionResult Finish(string search = "", int page = 1)
        {
            ViewBag.Search = search;
            var modelPage = _order.GetFinishOrders(search ?? "", page);
            return View(modelPage);
        }
        [HttpGet]
        [Route("/GetExcel/{count}")]
        public async Task<IActionResult> ExportToExcel(int count=0)
        {
            var list = _order.GetExports(count).Result;
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"Excel.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Demo");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("نام مجموعه");
                row.CreateCell(1).SetCellValue("ساعت شروع سانس");
                row.CreateCell(2).SetCellValue("ساعت اتمام سانس");
                row.CreateCell(3).SetCellValue("تاریخ سانس");
                row.CreateCell(4).SetCellValue("هزینه سانس");
                row.CreateCell(5).SetCellValue("کد سانس");
                row.CreateCell(6).SetCellValue("نام مشتری");
                row.CreateCell(7).SetCellValue("شماره تماس"); 
                row.CreateCell(8).SetCellValue("شماره فاکتور");
                row.CreateCell(9).SetCellValue("تاریخ فاکتور");
                foreach (var item in list)
                {

                    row = excelSheet.CreateRow(item.Id);
                    row.CreateCell(0).SetCellValue(item.CollectionName);
                    row.CreateCell(1).SetCellValue(item.StartTime);
                    row.CreateCell(2).SetCellValue(item.EndTime);
                    row.CreateCell(3).SetCellValue(item.DayTime);
                    row.CreateCell(4).SetCellValue(item.Price); 
                    row.CreateCell(5).SetCellValue(item.Code);
                    row.CreateCell(6).SetCellValue(item.UserName); 
                    row.CreateCell(7).SetCellValue(item.PhoneNumber);
                    row.CreateCell(8).SetCellValue(item.OrderCode);
                    row.CreateCell(9).SetCellValue(item.OrderDate);
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }




    }
}
