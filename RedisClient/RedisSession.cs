using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace RedisClient
{
    /// <summary>
    /// Redis Session entity
    /// </summary>
    public class RedisSession : IDisposable
    {
        private string _sectionName;
        private double _keyExpire;

        /// <summary>
        /// SectionName
        /// </summary>
        public string SectionName
        {
            get
            {
                return _sectionName;
            }
            set
            {
                _sectionName = value;
            }
        }

        /// <summary>
        /// 过期时间 小时 (0：取默认时间；-1：永久；N：N小时)
        /// </summary>
        public double KeyExpire
        {
            get
            {
                if (_keyExpire != 0)
                {
                    return _keyExpire;
                }
                else
                {
                    return ConstString.RedisKeyExpire;
                }
            }
            set
            {
                _keyExpire = value;
            }
        }

        private RedisManager _redisManager = null;

        /// <summary>
        /// 初始化RedisSession
        /// </summary>
        /// <param name="sectionName">sectionName</param>
        public RedisSession(string sectionName)
        {
            this._sectionName = sectionName;

            if (_redisManager == null)
            {
                _redisManager = new RedisManager(sectionName);
            }
        }

        /// <summary>
        /// 获取并设置在会话状态提供程序终止会话之前各请求之间所允许的时间（以分钟为单位）。
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 获取会话的唯一标识符。
        /// </summary>
        private string _sessionKey;

        /// <summary>
        /// 会话的唯一标识符。
        /// </summary>
        public string SessionKey
        {
            get
            { return _sessionKey; }

            set
            {
                _sessionKey = value;
                RedisKeyFactory.AddKey(_sessionKey);
            }
        }

        /// <summary>
        /// 按名称获取或设置会话值。
        /// </summary>
        /// <param name="name">会话值的键名。</param>
        /// <returns>具有指定名称的会话状态值；如果该项不存在，则为 null。</returns>
        public object this[string name]
        {
            get
            {
                return _redisManager.HashGet<object>(SessionKey, name);
            }
            set
            {
                _redisManager.HashSet<object>(SessionKey, value, name);//Session_18   object   CurrentUser

                //更新缓存过期时间
                if (KeyExpire == -1)
                {
                    _redisManager.KeyExpire(SessionKey, null);
                }
                else
                {
                    _redisManager.KeyExpire(SessionKey, DateTime.Now.AddHours(KeyExpire));
                }
            }
        }

        /// <summary>
        /// 通过key获得
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>键值</returns>
        public string GetUrl(string key)
        {
            return _redisManager.HashGet<string>(key, key);
        }

        /// <summary>
        /// 通过Key获得-string value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetStringValue()
        {
            return _redisManager.StringGet(SessionKey);
        }

        ///
        /// <summary>
        /// 判断会话中是否存在指定key
        /// </summary>
        /// <param name="name">键值</param>
        /// <returns>bool：是否</returns>
        public bool IsExistKey(string name)
        {
            return _redisManager.Hash_Exist<object>(SessionKey, name);
        }

        /// <summary>
        /// 向会话状态集合添加一个新项。
        /// </summary>
        /// <param name="name">要添加到会话状态集合的项的名称。</param>
        /// <param name="value">要添加到会话状态集合的项的值。</param>
        public void Add(string name, object value)
        {
            _redisManager.HashSet<object>(SessionKey, value, name);
        }

        /// <summary>
        /// 向会话状态集合添加一个新项-string value
        /// </summary>
        /// <param name="value">要添加到会话状态集合的项的值。</param>
        public void StringAdd(string value)
        {
            _redisManager.StringSetAdd(SessionKey, value);

            //更新缓存过期时间
            if (KeyExpire == -1)
            {
                _redisManager.KeyExpire(SessionKey, null);
            }
            else
            {
                _redisManager.KeyExpire(SessionKey, DateTime.Now.AddHours(KeyExpire));
            }
        }

        /// <summary>
        /// 从会话状态集合中移除所有的键和值。
        /// </summary>
        public void Clear()
        {
            _redisManager.DelKey(SessionKey);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="urls">批量删除的key</param>
        public void Clears(List<string> urls)
        {
            RedisKey[] keys = new RedisKey[urls.Count];
            for (int i = 0; i < urls.Count; i++)
            {
                keys[i] = urls[i];
            }
            _redisManager.DelKeys(keys);
        }

        /// <summary>
        /// 删除会话状态集合中的项。
        /// </summary>
        /// <param name="name">要从会话状态集合中删除的项的名称。</param>
        public void Remove(string name)
        {
            _redisManager.HashDelete(SessionKey, name);
        }

        /// <summary>
        /// 从会话状态集合中移除所有的键和值。
        /// </summary>
        public void RemoveAll()
        {
            Clear();
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            _redisManager.Dispose();
        }
    }
}
