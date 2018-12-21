using System;
using System.Threading;
using Newtonsoft.Json;

namespace RedisClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RedisClient.RedisSession session = new RedisClient.RedisSession("Menu"))
            {
                TestModel model = new TestModel()
                {
                    Name = "aaaa",
                    Class = "几几班"
                };

                session.SessionKey = "MenuTest";
                session.StringAdd("测试" + DateTime.Now.ToString() + "：" + JsonConvert.SerializeObject(model));
                string cc = session.GetStringValue();

                string aa = "";
            }
        }

        private class TestModel
        {
            public string Name { get; set; }
            public string Class { get; set; }
        }


    }
}
