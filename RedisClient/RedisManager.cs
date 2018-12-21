using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace RedisClient
{
    /// <summary>
    /// Redis Manager Class
    /// </summary>
    public class RedisManager
    {
        /// <summary>
        /// redis配置文件信息
        /// </summary>
        //private static RedisConfigElement redisConfigInfo = null;

        private ConnectionMultiplexer redis;

        private int db;

        /// <summary>
        /// 初始化链接池管理对象
        /// </summary>
        /// <param name="isSession"></param>
        public RedisManager(string sectionName)
        {
            RedisConfigElement redisConfigInfo = GetRedisConfigInfo(sectionName);
            var options = new ConfigurationOptions
            {
                EndPoints = { { redisConfigInfo.SocketAddress, redisConfigInfo.SecuredPort } },
                Password = redisConfigInfo.Password,
                SyncTimeout = redisConfigInfo.SyncTimeout
            };
            try
            {
                redis = ConnectionMultiplexer.Connect(options);
                if (redisConfigInfo.CurrentDatabase != 0)
                {
                    db = redisConfigInfo.CurrentDatabase;
                    var logMessage = string.Format("redis  connection ,configname:{0},SocketAddress:{1},db:{2}", sectionName, redisConfigInfo.SocketAddress, db);
                    //LogHelper.Info(logMessage);
                }
                else
                {
                    throw new Exception("redisConfigInfo CurrentDatabase is null " + sectionName);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error(string.Format("redis not connection ,configname:{0},points:{1}", sectionName, options.EndPoints));
                throw new Exception(string.Format("redis not connection {0} ，message:{1}", sectionName, ex.Message));
            }

        }

        /// <summary>
        /// 初始化Redis 根据不同的SctionName进行初始化
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private static RedisConfigElement GetRedisConfigInfo(string sectionName)
        {
            return RedisConfigInfo.GetConfig(sectionName);
        }
        ///// <summary>
        ///// 初始化链接池管理对象
        ///// </summary>
        ///// <param name="isSession"></param>
        //public RedisManager(int Db)
        //{
        //    var options = new ConfigurationOptions
        //    {
        //        EndPoints = { { redisConfigInfo.SocketAddress, redisConfigInfo.SecuredPort } },
        //        Password = redisConfigInfo.Password,
        //        SyncTimeout = redisConfigInfo.SyncTimeout
        //    };
        //    redis = ConnectionMultiplexer.Connect(options);
        //    db = Db;
        //}

        /// <summary>
        /// 根据key获取field
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="fieldId">filed的标识</param>
        /// <returns></returns>
        private String GetField(String key, String fieldId)
        {
            if (RedisKeyFactory.RedisKeyConfig.ContainsKey(key))
            {
                String fieldFormat = RedisKeyFactory.RedisKeyConfig[key];

                return String.Format(fieldFormat, fieldId);

            }
            else
            {

                throw new Exception("redis 不存这个键");
            }

        }

        /// <summary>
        ///  批量删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="delIds"></param>
        /// <returns></returns>
        public Int32 HashDelete(String key, List<Int32> delIds)
        {
            if (delIds == null || delIds.Count <= 0)
                return 1;

            var dataBase = redis.GetDatabase(db);

            Int32 count = delIds.Count;

            RedisValue[] delValues = new RedisValue[count];

            for (Int32 i = 0; i < count; i++)
            {
                delValues[i] = GetField(key, delIds[i].ToString());
            }

            return dataBase.HashDelete(key, delValues) >= 0 ? 1 : 0;
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="delIds"></param>
        /// <returns></returns>
        public bool HashDelete(String key, string hashKey)
        {
            if (string.IsNullOrEmpty(hashKey))
                return false;

            var dataBase = redis.GetDatabase(db);
            RedisKey keyValue = key;
            RedisValue hashField = hashKey;
            return dataBase.HashDelete(keyValue, hashField);
        }

        /// <summary>
        /// 设置集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="listIds"></param>
        /// <returns></returns>
        public Int32 SetAdd(String key, List<Int32> listIds)
        {

            var dataBase = redis.GetDatabase(db);

            Int32 count = listIds.Count;

            RedisValue[] setValues = new RedisValue[count];

            for (Int32 i = 0; i < count; i++)
            {
                setValues[i] = listIds[i];
            }

            return dataBase.SetAdd(key, setValues) > 0 ? 1 : 0;

        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="listInstance"></param>
        /// <returns></returns>
        public Int32 HashSet<T>(String key, List<T> listInstance, Func<T, String> getModelId)
        {
            if (listInstance == null || listInstance.Count <= 0)
                return 1;

            var dataBase = redis.GetDatabase(db);

            Int32 count = listInstance.Count;

            HashEntry[] upValues = new HashEntry[count];

            for (Int32 i = 0; i < count; i++)
            {
                var item = listInstance[i];
                string itemJson = JsonConvert.SerializeObject(item);
                upValues[i] = new HashEntry(GetField(key, getModelId(item)), itemJson);
            }
            dataBase.HashSet(key, upValues);
            return 1;

        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="listInstance"></param>
        /// <returns></returns>
        public Int32 HashSet<T>(String key, T instance, String HashKey)
        {
            if (instance == null)
                return 1;
            var dataBase = redis.GetDatabase(db);
            string itemJson = JsonConvert.SerializeObject(instance);
            HashEntry upValue = new HashEntry(HashKey, itemJson);
            HashEntry[] upValues = new HashEntry[1];
            upValues[0] = upValue;
            dataBase.HashSet(key, upValues);
            return 1;
        }

        /// <summary>
        /// 过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public void KeyExpire(String key, DateTime? expiry)
        {
            var dataBase = redis.GetDatabase(db);
            dataBase.KeyExpire(key, expiry);
        }

        /// <summary>
        /// 分批更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="listInstance"></param>
        /// <param name="getModelId"></param>
        /// <param name="batchCount"></param>
        /// <returns></returns>
        public Int32 BatchHashSet<T>(String key, List<T> listInstance, Func<T, String> getModelId, Int32 batchCount)
        {
            if (listInstance == null || listInstance.Count <= 0)
                return 1;

            Int32 count = listInstance.Count;

            if (count <= batchCount)
                return this.HashSet<T>(key, listInstance, getModelId);

            var dataBase = redis.GetDatabase(db);

            Int32 batch = count / batchCount;

            batch = count % batchCount == 0 ? batch : batch + 1;

            for (Int32 i = 0; i < batch; i++)
            {
                Int32 thisCount = (i == batch - 1) ? count % batchCount : batchCount;
                HashEntry[] upValues = new HashEntry[thisCount];

                for (Int32 j = 0; j < thisCount; j++)
                {
                    var item = listInstance[i * batchCount + j];
                    string itemJson = JsonConvert.SerializeObject(item);
                    upValues[i] = new HashEntry(GetField(key, getModelId(item)), itemJson);

                }

                dataBase.HashSet(key, upValues);

            }

            return 1;

        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T">获取什么类型的列表</typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="listFieldId">标识ID</param>
        /// <returns></returns>
        public List<T> HashGet<T>(String key, List<Int32> listFieldId)
        {
            List<T> listResult = new List<T>();

            if (listFieldId == null || listFieldId.Count < 0)
            {
                return listResult;
            }

            var dataBase = redis.GetDatabase(db);

            Int32 count = listFieldId.Count;

            //  转化为Redis数据结构
            RedisValue[] filedValue = new RedisValue[count];
            for (Int32 i = 0; i < count; i++)
            {
                filedValue[i] = GetField(key, listFieldId[i].ToString());
            }

            // 取出结果集
            RedisValue[] arrResult = dataBase.HashGet(key, filedValue);

            // 将Redis结果转为化所需类型的列表
            if (arrResult != null && arrResult.Length > 0)
            {
                foreach (RedisValue item in arrResult)
                {
                    if (!item.IsNullOrEmpty)
                    {
                        listResult.Add(JsonConvert.DeserializeObject<T>(item));
                    }
                }
            }
            return listResult;
        }

        /// <summary>
        /// 获取单个结果
        /// </summary>
        /// <typeparam name="T">获取结果的类型</typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="fieldId">Redis Field 标识</param>
        /// <returns></returns>
        public T HashGet<T>(String key, Int32 fieldId)
        {
            if (fieldId > 0)
            {
                var dataBase = redis.GetDatabase(db);

                // 取出结果
                RedisValue result = dataBase.HashGet(key, GetField(key, fieldId.ToString()));

                // 将Redis结果转为化所需类型的列表
                if (!result.IsNullOrEmpty)
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 获取单个结果
        /// </summary>
        /// <typeparam name="T">获取结果的类型</typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="fieldId">Redis Field 标识</param>
        /// <returns></returns>
        public T HashGet<T>(String key, string hashKey)
        {
            if (!string.IsNullOrEmpty(hashKey))
            {
                var dataBase = redis.GetDatabase(db);

                // 取出结果
                RedisValue result = dataBase.HashGet(key, hashKey);

                // 将Redis结果转为化所需类型的列表
                if (!result.IsNullOrEmpty)
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 设置单个 string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="listIds"></param>
        /// <returns></returns>
        public bool StringSetAdd(String key, String value)
        {
            var dataBase = redis.GetDatabase(db);
            return dataBase.StringSet(key, value);
        }

        /// <summary>
        /// 获取单个结果-String
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public string StringGet(String key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                var dataBase = redis.GetDatabase(db);

                // 取出结果
                RedisValue result = dataBase.StringGet(key);

                // 将Redis结果转为化所需类型的列表
                if (!result.IsNullOrEmpty)
                {
                    return result.ToString();
                }
            }
            return null;
        }

        public Int32 DelKey(String key)
        {
            if (RedisKeyFactory.RedisKeyConfig.ContainsKey(key))
            {
                var dataBase = redis.GetDatabase(db);

                dataBase.KeyDelete(key);
            }
            return 1;
        }

        internal Int32 DelKeys(RedisKey[] keys)
        {
            var dataBase = redis.GetDatabase(db);

            dataBase.KeyDelete(keys);
            return 1;
        }

        public bool Hash_Exist<T>(string key, string hashField)
        {
            bool exist = false;
            if (RedisKeyFactory.RedisKeyConfig.ContainsKey(key))
            {
                var dataBase = redis.GetDatabase(db);
                exist = dataBase.HashExists(key, hashField);
            }
            return exist;
        }

        internal void Dispose()
        {
            if (redis != null)
                redis.Dispose();
        }
    }
}
