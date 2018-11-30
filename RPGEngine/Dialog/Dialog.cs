using System;
using System.Collections.Generic;
using System.Text;
using RPGEngine.Scenes;

namespace RPGEngine.Dialog
{
    public abstract class Dialog
    {
        public abstract void Show(Scene owner);
    }
}
