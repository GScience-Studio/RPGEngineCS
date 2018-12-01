using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ContentExtension
{
    public class AutoFontDescription : FontDescription
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AutoFontDescription()
            : base("Arial", 14, 0)
        {
        }


        /// <summary>
        /// Add a new property to our font description, which will allow us to
        /// include a ResourceFiles element in the .spritefont XML. We use the
        /// ContentSerializer attribute to mark this as optional, so existing
        /// .spritefont files that do not include this ResourceFiles element
        /// can be imported as well.
        /// </summary>
        public string TextRes;
    }
}
