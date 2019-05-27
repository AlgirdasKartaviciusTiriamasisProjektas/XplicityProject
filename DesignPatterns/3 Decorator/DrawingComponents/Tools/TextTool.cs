using System;
using System.Drawing;

namespace DrawingComponents.Tools
{
    public class TextTool : ToolBase
    {
        private readonly string _text;

        public TextTool(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override void Draw(Graphics graphics, Rectangle area)
        {
            graphics.DrawString(_text, new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.Black), area);
        }
    }
}
