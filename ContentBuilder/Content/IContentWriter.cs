using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentBuilder.Content
{
    interface IContentWriter
    {
        /// <summary>
        /// 将指定资源写入文件
        /// </summary>
        /// <param name="obj">资源</param>
        /// <param name="to">文件</param>
        void Write(object obj, BinaryWriter to);

        /// <summary>
        /// 从原始文件中加载
        /// </summary>
        /// <param name="fileName">文件名</param>
        object LoadFromOriginal(string fileName);

        /// <summary>
        /// 获取扩展名
        /// </summary>
        /// <returns></returns>
        string[] GetExtensions();

        /// <summary>
        /// 绑定的加载器
        /// </summary>
        /// <returns></returns>
        string ReaderName();
    }
}
