using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContentBuilder.Content
{
    public class ContentManager
    {
        private static readonly Dictionary<string, IContentWriter> mWriterList 
            = new Dictionary<string, IContentWriter>();
        private static readonly Dictionary<string, KeyValuePair<object, IContentWriter>> mResources 
            = new Dictionary<string, KeyValuePair<object, IContentWriter>>();

        public static void Initialize()
        {
            foreach (var type in typeof(ContentManager).Assembly.DefinedTypes)
                if (type.GetInterfaces().FirstOrDefault((t) => t == typeof(IContentWriter)) != null)
                {
                    var contentWriter = (IContentWriter)Activator.CreateInstance(type);

                    foreach (var extensionName in contentWriter.GetExtensions())
                        mWriterList.Add(extensionName, contentWriter);
                }
        }

        /// <summary>
        /// 把Content写入文件
        /// </summary>
        /// <param name="to">写入的位置</param>
        public static void Write(string to)
        {
            var writer = new BinaryWriter(File.OpenWrite(to));
            foreach (var objWithWriter in mResources)
            {
                var contentWriter = objWithWriter.Value.Value;
                var obj = objWithWriter.Value.Key;

                //写入资源Key
                writer.Write(objWithWriter.Key);

                //写入加载器
                writer.Write(contentWriter.ReaderName());

                //写入数据
                contentWriter.Write(obj, writer);
            }
            //写入结尾
            writer.Write("");

            //关闭
            writer.Close();
        }

        /// <summary>
        /// 从指定目录读取资源
        /// </summary>
        /// <param name="from">从哪里</param>
        /// <param name="rootKey">根Key，默认为空</param>
        public static void Read(string from, string rootKey = "")
        {
            foreach (var resFile in Directory.GetFiles(from))
            {
                var extensionName = resFile.Substring(resFile.LastIndexOf('.'));
                if (!mWriterList.ContainsKey(extensionName))
                    throw new NotSupportedException("Don't support extension: " + extensionName);

                var fileName = resFile.Substring(resFile.LastIndexOf('\\') + 1);

                mResources.Add(
                    (rootKey == "" ? "" : (rootKey + ".")) + fileName.Substring(0, fileName.LastIndexOf('.')),
                        new KeyValuePair<object, IContentWriter>
                        (
                        mWriterList[extensionName].LoadFromOriginal(resFile),
                        mWriterList[extensionName]
                        )
                    );
            }

            foreach (var dir in Directory.GetDirectories(from))
                Read(from + "/" + dir, rootKey != "" ? "." : "" + dir);
        }
    }
}
