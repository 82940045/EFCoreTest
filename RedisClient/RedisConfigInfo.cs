using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisClient
{
    /// <summary>
    /// Redis Config Utilies Class
    /// </summary>
    public class RedisConfigInfo : ConfigurationSection
    {
        private static readonly ConfigurationProperty redisConfigProp = new ConfigurationProperty(string.Empty
                                        , typeof(RedisConfigCollection), null
                                        , ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public RedisConfigCollection RedisConfigs
        {
            get
            {
                return (RedisConfigCollection)this[redisConfigProp];
            }
        }

        /// <summary>
        /// 获取Redis 配置信息
        /// </summary>
        /// <returns></returns>
        internal static RedisConfigInfo GetConfig()
        {
            RedisConfigInfo section = null;
            try
            {
                //读取项目webconfig中配置redisConfig目录
                string filePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["redisConfig"];
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = filePath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                if (config.HasFile)
                {
                    section = (RedisConfigInfo)config.GetSection("redisConfig");
                    if (section == null)
                        throw new SystemException("Section  redisConfig is not found.");
                }
                else
                {
                    throw new SystemException("redis config file is not found. path：" + filePath);
                }
            }
            catch (Exception exp)
            {
                throw new SystemException("RedisConfigInfo-->RedisConfigInfo:" + exp.StackTrace);
            }

            return section;
        }

        /// <summary>
        /// 按照sectionName获取Redis配置信息
        /// </summary>
        /// <param name="sectionName">配置文件中 sectionName</param>
        /// <returns></returns>
        internal static RedisConfigElement GetConfig(string sectionName)
        {
            //XmlReader xr = null;
            //XmlDocument doc = new XmlDocument();
            RedisConfigElement configItem = null;
            try
            {
                RedisConfigInfo section = null;
                //读取项目webconfig中配置redisConfig目录
                string rootpath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("\\"));
                rootpath = rootpath.Substring(0, rootpath.LastIndexOf("\\"));
                rootpath = rootpath.Substring(0, rootpath.LastIndexOf("\\"));
                string filePath = rootpath + "\\" + ConfigurationManager.AppSettings["redisConfig"];
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = filePath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                if (config.HasFile)
                {
                    //xr = XmlReader.Create(System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read));
                    //doc.Load(xr);
                    //xr.Close();

                    //XmlNodeList listNode = doc.SelectNodes("configuration/redisConfigs/redisConfig");
                    section = config.GetSection("redisConfigs") as RedisConfigInfo;
                    if (section == null)
                        throw new SystemException("Section  redisConfigs is not found.");
                    else
                        foreach (RedisConfigElement item in section.RedisConfigs)
                        {
                            if (item.SectionName == sectionName)
                            {
                                configItem = item;
                            }
                        }
                }
                else
                {
                    throw new SystemException("redis config file is not found. path：" + filePath);
                }
            }
            catch (Exception exp)
            {
                throw new SystemException("RedisConfigInfo-->RedisConfigInfo:" + exp.StackTrace);
            }

            return configItem;
        }



    }

    [ConfigurationCollection(typeof(RedisConfigElement))]
    public class RedisConfigCollection : ConfigurationElementCollection
    {
        new RedisConfigElement this[string sectionName]
        {
            get
            {
                return (RedisConfigElement)base.BaseGet(sectionName);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RedisConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RedisConfigElement)element).SectionName;
        }
    }

    public class RedisConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("SectionName", IsRequired = false)]
        internal string SectionName
        {
            get
            {
                return (string)base["SectionName"];
            }
            set
            {
                base["SectionName"] = value;
            }
        }

        /// <summary>
        /// 可写的Redis链接地址
        /// </summary>
        [ConfigurationProperty("SocketAddress", IsRequired = false)]
        internal string SocketAddress
        {
            get
            {
                return (string)base["SocketAddress"];
            }
            set
            {
                base["SocketAddress"] = value;
            }
        }

        /// <summary>
        /// 端口号
        /// </summary>
        [ConfigurationProperty("SecuredPort", IsRequired = false, DefaultValue = 10679)]
        internal int SecuredPort
        {
            get
            {
                int _syncTimeout = (int)base["SecuredPort"];
                return _syncTimeout > 0 ? _syncTimeout : 10679;
            }
            set
            {
                base["SecuredPort"] = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        [ConfigurationProperty("Password", IsRequired = false)]
        internal string Password
        {
            get
            {
                return (string)base["Password"];
            }
            set
            {
                base["Password"] = value;
            }
        }

        /// <summary>
        /// 异步超时时间
        /// </summary>
        [ConfigurationProperty("SyncTimeout", IsRequired = false, DefaultValue = 6000)]
        internal int SyncTimeout
        {
            get
            {
                int _syncTimeout = (int)base["SyncTimeout"];
                return _syncTimeout > 0 ? _syncTimeout : 6000;
            }
            set
            {
                base["SyncTimeout"] = value;
            }
        }


        /// <summary>
        /// 使用sll加密
        /// </summary>
        [ConfigurationProperty("Ssl", IsRequired = false, DefaultValue = false)]
        internal bool Ssl
        {
            get
            {
                return (bool)base["Ssl"];
            }
            set
            {
                base["Ssl"] = value;
            }
        }

        /// <summary>
        /// 默认数据库bs
        /// </summary>
        [ConfigurationProperty("CurrentDatabase", IsRequired = false, DefaultValue = 1)]
        internal int CurrentDatabase
        {
            get
            {
                return (int)base["CurrentDatabase"];
            }
            set
            {
                base["CurrentDatabase"] = value;
            }
        }
    }
}
