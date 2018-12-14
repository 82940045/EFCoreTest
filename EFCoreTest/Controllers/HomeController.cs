using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreTest.Models;
using EFCoreTest.DataAccessModels;
using EFCoreTest.DBMySQLModels;

namespace EFCoreTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //saasoamanagerContext dbContext = new saasoamanagerContext();
            //dbContext.Tsysquestiontype.Add(new DataAccessModels.Tsysquestiontype()
            //{
            //    Id = 2,
            //    Name = "1",
            //    SystemId = "001",
            //    UserId = 7,
            //    EnterpriseId = 6,
            //    IsDeleted = "0",
            //    IsEnabled = "1",
            //    UtcCreatedDate = DateTime.Now.ToUniversalTime(),
            //    UtcUpdatedDate = DateTime.Now.ToUniversalTime()
            //});

            //dbContext.SaveChanges();
            //dbContext.Dispose();
            int count = 3;
            testContext dbMySqlContext = new testContext();

            for (int i = 0; i < 30; i++)
            {
                dbMySqlContext.Tsysquestiontype.Add(new DBMySQLModels.Tsysquestiontype()
                {
                    Id = count,
                    Name = count.ToString(),
                    SystemId = "001",
                    //UserId = 7,
                    EnterpriseId = 6,
                    IsDeleted = "0",
                    IsEnabled = "1",
                    UtcCreatedDate = DateTime.Now.ToUniversalTime(),
                    UtcUpdatedDate = DateTime.Now.ToUniversalTime()
                });

                count = count + 1;
            }

            dbMySqlContext.SaveChanges();
            dbMySqlContext.Dispose();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
