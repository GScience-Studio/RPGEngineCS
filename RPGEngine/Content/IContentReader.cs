using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPGEngine.Content
{
    /// <summary>
    /// 资源读取器接口
    /// </summary>
    interface IContentReader
    {
        /// <summary>
        /// 从Binary流中读取资源
        /// </summary>
        /// <param name="from">从哪里读取</param>
        /// <returns></returns>
        object Read(BinaryReader from);
    }
}
