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
                //过期时间 小时；-1为长期
                session.KeyExpire = 1;
                //添加
                session.StringAdd("测试" + DateTime.Now.ToString() + "：" + JsonConvert.SerializeObject(model));
                //获取
                string cc = session.GetStringValue();
                //删除
                session.Clear();

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
