using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisClient
{
    /// <summary>
    /// Redis Key 工厂管理
    /// </summary>
    public class RedisKeyFactory
    {
        private static Dictionary<String, String> _redisKeyConfig = new Dictionary<string, string>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        public static void AddKey(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (!_redisKeyConfig.ContainsKey(key))
                {
                    _redisKeyConfig.Add(key, "id:{0}");
                }
            }
        }
        internal static Dictionary<String, String> RedisKeyConfig
        {
            get { return _redisKeyConfig; }
        }
    }
}
