using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.Content
{
    /// <summary>
    /// 资源管理器\n
    /// 自动加载经压缩的资源文件包\n
    /// 取代XNA自带的Content
    /// </summary>
    public class ContentManager
    {
        private static readonly Dictionary<string, IContentReader> mReaderList 
            = new Dictionary<string, IContentReader>();
        private static readonly Dictionary<string, object> mLoadedResources
            = new Dictionary<string, object>();

        public static void Initialize()
        {
            foreach (var type in typeof(ContentManager).Assembly.DefinedTypes)
                if (type.GetInterfaces().FirstOrDefault((t) => t == typeof(IContentReader)) != null)
                {
                    if (type.FullName == null)
                        continue;

                    var contentWriter = (IContentReader)typeof(ContentManager).Assembly.CreateInstance(type.FullName);

                    if (contentWriter == null)
                        continue;

                    mReaderList.Add(type.FullName, contentWriter);
                }

            Read("Content.pkg");
        }

        /// <summary>
        /// 从指定素材包读取资源
        /// </summary>
        /// <param name="from">从哪里</param>
        /// <param name="rootKey">根Key，默认为空</param>
        public static void Read(string from, string rootKey = "")
        {
            var reader = new BinaryReader(File.OpenRead(from));
            string resName;
            while ((resName = reader.ReadString()) != "")
            {
                var readerName = reader.ReadString();
                if (!mReaderList.ContainsKey(readerName))
                    throw new NotSupportedException("Unknown reader: " + readerName);

                var typeReader = mReaderList[readerName];
                var resKey = resName;
                mLoadedResources.Add(resKey, typeReader.Read(reader));
            }
        }

        public static T Get<T>(string key) where T : class
        {
            return mLoadedResources[key] as T;
        }
    }
}
