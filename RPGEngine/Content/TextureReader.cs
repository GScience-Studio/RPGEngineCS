using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace RPGEngine.Content
{
    /// <summary>
    /// 纹理加载器
    /// 0x00-0x03 宽度
    /// 0x04-0x07 高度
    /// 0x08-0x12 图像格式
    /// 0x12-0x?? 图像数据
    /// </summary>
    public class TextureReader : IContentReader
    {
        private void ReadColorData(Texture2D texture2D, BinaryReader from)
        {
            var length = texture2D.Width * texture2D.Height;

            switch (texture2D.Format)
            {
                case SurfaceFormat.Color:
                    var colorData = new Color[length];
                    for (var i = 0; i < colorData.Length; ++i)
                        colorData[i].PackedValue = (uint)from.ReadInt32();
                    texture2D.SetData(colorData);
                    break;
                case SurfaceFormat.Bgr565:
                    var bgr565Data = new Bgr565[length];
                    for (var i = 0; i < bgr565Data.Length; ++i)
                        bgr565Data[i].PackedValue = (ushort)from.ReadInt16();
                    texture2D.SetData(bgr565Data);
                    break;
                case SurfaceFormat.Bgra5551:
                    var bgra5551Data = new Bgra5551[length];
                    for (var i = 0; i < bgra5551Data.Length; ++i)
                        bgra5551Data[i].PackedValue = (ushort)from.ReadInt16();
                    texture2D.SetData(bgra5551Data);
                    break;
                case SurfaceFormat.Bgra4444:
                    var bgra44441Data = new Bgra4444[length];
                    for (var i = 0; i < bgra44441Data.Length; ++i)
                        bgra44441Data[i].PackedValue = (ushort)from.ReadInt16();
                    texture2D.SetData(bgra44441Data);
                    break;
                case SurfaceFormat.NormalizedByte2:
                    var normalizedByte2Data = new NormalizedByte2[length];
                    for (var i = 0; i < normalizedByte2Data.Length; ++i)
                        normalizedByte2Data[i].PackedValue = (ushort) from.ReadInt16();
                    texture2D.SetData(normalizedByte2Data);
                    break;
                case SurfaceFormat.NormalizedByte4:
                    var normalizedByte4Data = new NormalizedByte4[length];
                    for (var i = 0; i < normalizedByte4Data.Length; ++i)
                        normalizedByte4Data[i].PackedValue = (uint)from.ReadInt32();
                    texture2D.SetData(normalizedByte4Data);
                    break;
                case SurfaceFormat.Rgba1010102:
                    var rgba1010102Data = new Rgba1010102[length];
                    for (var i = 0; i < rgba1010102Data.Length; ++i)
                        rgba1010102Data[i].PackedValue = (uint)from.ReadInt32();
                    texture2D.SetData(rgba1010102Data);
                    break;
                case SurfaceFormat.Rg32:
                    var rg32Data = new Rg32[length];
                    for (var i = 0; i < rg32Data.Length; ++i)
                        rg32Data[i].PackedValue = (uint)from.ReadInt32();
                    texture2D.SetData(rg32Data);
                    break;
                case SurfaceFormat.Rgba64:
                    var rgba64Data = new Rgba64[length];
                    for (var i = 0; i < rgba64Data.Length; ++i)
                        rgba64Data[i].PackedValue = (ulong) from.ReadInt64();
                    texture2D.SetData(rgba64Data);
                    break;
                case SurfaceFormat.Alpha8:
                    var alpha8Data = new Alpha8[length];
                    for (var i = 0; i < alpha8Data.Length; ++i)
                        alpha8Data[i].PackedValue = from.ReadByte();
                    texture2D.SetData(alpha8Data);
                    break;
                case SurfaceFormat.Single:
                    var singleData = new float[length];
                    for (var i = 0; i < singleData.Length; ++i)
                        singleData[i] = from.ReadSingle();
                    texture2D.SetData(singleData);
                    break;
                case SurfaceFormat.HalfSingle:
                    var halfSingleData = new HalfSingle[length];
                    for (var i = 0; i < halfSingleData.Length; ++i)
                        halfSingleData[i].PackedValue = (ushort) from.ReadInt16();
                    texture2D.SetData(halfSingleData);
                    break;
                case SurfaceFormat.HalfVector2:
                    var halfVector2Data = new HalfVector2[length];
                    for (var i = 0; i < halfVector2Data.Length; ++i)
                        halfVector2Data[i].PackedValue = (uint)from.ReadInt32();
                    texture2D.SetData(halfVector2Data);
                    break;
                case SurfaceFormat.HalfVector4:
                    var halfVector4Data = new HalfVector4[length];
                    for (var i = 0; i < halfVector4Data.Length; ++i)
                        halfVector4Data[i].PackedValue = (ulong) from.ReadInt64();
                    texture2D.SetData(halfVector4Data);
                    break;
                default:
                    throw new Exception("Texture surface format not supported");
            }
        }

        public object Read(BinaryReader from)
        {
            var width = from.ReadInt32();
            var height = from.ReadInt32();

            var format = (SurfaceFormat)from.ReadInt16();
            var texture = new Texture2D(RPGGame.Game.GraphicsDevice, width, height, false, format);

            ReadColorData(texture, from);

            return texture;
        }
    }
}
