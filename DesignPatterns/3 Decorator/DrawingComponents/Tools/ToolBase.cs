using System.Drawing;

namespace DrawingComponents.Tools
{
    public abstract class ToolBase
    {
        public abstract void Draw(Graphics graphics, Rectangle area);
    }
}
