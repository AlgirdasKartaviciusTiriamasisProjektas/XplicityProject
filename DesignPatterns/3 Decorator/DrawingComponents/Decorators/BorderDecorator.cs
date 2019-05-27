using DrawingComponents.Tools;
using System;
using System.Drawing;

namespace DrawingComponents.Decorators
{
    public class BorderDecorator : ToolBase
    {
        public override void Draw(Graphics graphics, Rectangle area)
        {
            const int width = 2;

            var restrictedArea = new Rectangle(area.X + width / 2, area.Y + width / 2, area.Width - width, area.Height - width);

            graphics.DrawRectangle(new Pen(Color.Red, width), restrictedArea);

             
        }
    }
}
