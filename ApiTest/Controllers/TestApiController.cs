using ApiTest.WebStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class TestApiController : ApiController
    {
        public class TestModel
        {
            public string TestStr { get; set; }
        }

        /// <summary>
        /// 防SQL注入测试Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns>防SQL过滤后model 如：TestStr = "select '8282' = '8282"转为TestStr = "8282=8282"</returns>
        [AntiSqlInject]
        public HttpResponseMessage Test(TestModel model)
        {
            string testStr = model.TestStr;

            return new HttpResponseMessage { Content = new StringContent(testStr, Encoding.GetEncoding("UTF-8"), "application/json") };
        }
    }
}
