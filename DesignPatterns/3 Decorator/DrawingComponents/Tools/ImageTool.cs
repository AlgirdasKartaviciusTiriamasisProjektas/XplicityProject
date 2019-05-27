using System;
using System.Drawing;

namespace DrawingComponents.Tools
{
    public class ImageTool : ToolBase
    {
        private readonly Image _image;

        public ImageTool(string resourceName)
        {
            var stream = typeof(ImageTool).Assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw  new ArgumentException($"Resource '{resourceName}' does not exist");
            }

            _image = Image.FromStream(stream);
        }

        public override void Draw(Graphics graphics, Rectangle area)
        {
            graphics.DrawImage(_image, area);
        }
    }
}
