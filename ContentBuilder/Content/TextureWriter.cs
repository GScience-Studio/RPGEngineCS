using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace ContentBuilder.Content
{
    public class TextureWriter : IContentWriter
    {
        private void WriteColorData(Texture2D texture2D, BinaryWriter to)
        {
            var length = texture2D.Width * texture2D.Height;

            switch (texture2D.Format)
            {
                case SurfaceFormat.Color:
                    var colorData = new Color[length];
                    texture2D.GetData(colorData);

                    foreach (var data in colorData)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Bgr565:
                    var bgr565Data = new Bgr565[length];
                    texture2D.GetData(bgr565Data);
                    foreach (var data in bgr565Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Bgra5551:
                    var bgra5551Data = new Bgra5551[length];
                    texture2D.GetData(bgra5551Data);
                    foreach (var data in bgra5551Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Bgra4444:
                    var bgra44441Data = new Bgra4444[length];
                    texture2D.GetData(bgra44441Data);
                    foreach (var data in bgra44441Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.NormalizedByte2:
                    var normalizedByte2Data = new NormalizedByte2[length];
                    texture2D.GetData(normalizedByte2Data);
                    foreach (var data in normalizedByte2Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.NormalizedByte4:
                    var normalizedByte4Data = new NormalizedByte4[length];
                    texture2D.GetData(normalizedByte4Data);
                    foreach (var data in normalizedByte4Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Rgba1010102:
                    var rgba1010102Data = new Rgba1010102[length];
                    texture2D.GetData(rgba1010102Data);
                    foreach (var data in rgba1010102Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Rg32:
                    var rg32Data = new Rg32[length];
                    texture2D.GetData(rg32Data);
                    foreach (var data in rg32Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Rgba64:
                    var rgba64Data = new Rgba64[length];
                    texture2D.GetData(rgba64Data);
                    foreach (var data in rgba64Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Alpha8:
                    var alpha8Data = new Alpha8[length];
                    texture2D.GetData(alpha8Data);
                    foreach (var data in alpha8Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.Single:
                    var singleData = new float[length];
                    texture2D.GetData(singleData);
                    foreach (var data in singleData)
                        to.Write(data);

                    break;
                case SurfaceFormat.HalfSingle:
                    var halfSingleData = new HalfSingle[length];
                    texture2D.GetData(halfSingleData);
                    foreach (var data in halfSingleData)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.HalfVector2:
                    var halfVector2Data = new HalfVector2[length];
                    texture2D.GetData(halfVector2Data);
                    foreach (var data in halfVector2Data)
                        to.Write(data.PackedValue);
                    break;
                case SurfaceFormat.HalfVector4:
                    var halfVector4Data = new HalfVector4[length];
                    texture2D.GetData(halfVector4Data);
                    foreach (var data in halfVector4Data)
                        to.Write(data.PackedValue);
                    break;
                default:
                    throw new Exception("Texture surface format not supported");
            }
        }
        public void Write(object obj, BinaryWriter to)
        {
            var texture2D = (Texture2D) obj;

            to.Write(texture2D.Width);
            to.Write(texture2D.Height);

            to.Write((short) texture2D.Format);

            //获取各点颜色信息
            WriteColorData(texture2D, to);
        }

        /// <summary>
        ///     从原始文件中加载
        /// </summary>
        /// <param name="fileName">文件名</param>
        public object LoadFromOriginal(string fileName)
        {
            return Texture2D.FromStream(Program.GraphicsDevice, File.Open(fileName, FileMode.Open));
        }

        public string[] GetExtensions()
        {
            return new[]
            {
                ".jpg",
                ".bmp",
                ".jpeg",
                ".png",
                ".gif",
                ".pict",
                ".tga"
            };
        }

        public string ReaderName()
        {
            return "RPGEngine.Content.TextureReader";
        }
    }
}