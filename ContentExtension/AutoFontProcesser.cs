using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using Microsoft.Xna.Framework.Input;

namespace ContentExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same if
    /// the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    [ContentProcessor(DisplayName = "Auto Font Processer")]
    public class AutoFontProcesser : ContentProcessor<AutoFontDescription, SpriteFontContent>
    {
        public override SpriteFontContent Process(AutoFontDescription input, ContentProcessorContext context)
        {
            var textRes = input.TextRes;
            var textXml = new XmlDocument();
            textXml.Load(File.OpenRead(textRes));
            var textNode = textXml.SelectNodes("XnaContent/Asset/Text");
            if (textNode == null)
                throw new Exception("Can't find node XnaContent/Asset/Text");

            if (textNode.Count == 0)
                Console.WriteLine("WARNING: Find nothing in " + textRes);

            foreach (XmlNode node in textNode)
            {
                var strItem = node["Item"];
                if (strItem?["Value"] == null)
                    throw new Exception("Can't read value in XnaContent.Asset.Text");
                var str = strItem["Value"].InnerText;

                foreach (var c in str.ToCharArray())
                    input.Characters.Add(c);
            }
            return context.Convert<FontDescription, SpriteFontContent>(input, "FontDescriptionProcessor");
        }
    }
}