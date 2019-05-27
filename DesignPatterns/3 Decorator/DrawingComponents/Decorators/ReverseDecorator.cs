using DrawingComponents.Tools;
using System;
using System.Drawing;

namespace DrawingComponents.Decorators
{
    public class ReverseDecorator : ToolBase
    {
        public override void Draw(Graphics graphics, Rectangle area)
        {
            using (var image = new Bitmap(area.Width, area.Height))
            {
                using (var tmpGraphics = Graphics.FromImage(image))
                {
                    var areaOffset = new Rectangle(Point.Empty, area.Size);

                    //

                }

                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                graphics.DrawImage(image, area.Location);
            }
        }
    }
}
