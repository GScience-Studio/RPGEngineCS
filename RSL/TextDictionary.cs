using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSL
{
    /// <summary>
    /// 文本存储器
    /// </summary>
    public class TextDictionary
    {
        public Dictionary<string, string> Text = new Dictionary<string, string>();

        public string this[string key] => Text[key];
    }
}
