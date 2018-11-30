using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using ContentBuilder.Content;

namespace ContentBuilder
{
    class Program
    {
        public static GraphicsDevice GraphicsDevice;
        static void Main(string[] args)
        {
            GraphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());
            ContentManager.Initialize();

            ContentManager.Read(args.Length >= 2 ? args[1] : System.Console.ReadLine());
            ContentManager.Write(args.Length >= 3 ? args[2] : System.Console.ReadLine());
        }
    }
}
