using DrawingComponents.Tools;
using System;
using System.Drawing;
using DrawingComponents.Decorators;

namespace DrawingComponents
{
    public static class ToolsFactory
    {
        public static Tuple<ToolBase, Rectangle>[] Create()
        {
            return new[]
            {
                Tuple.Create<ToolBase, Rectangle>(
                    new TextTool("This is a simple text"),
                    new Rectangle(0, 0, 250, 50)),

                Tuple.Create<ToolBase, Rectangle>(
                    new TextTool("This is another text"),
                    new Rectangle(250, 0, 250, 50)),

                Tuple.Create<ToolBase, Rectangle>(
                    new TextTool("This is also a text"),
                    new Rectangle(0, 50, 250, 50)),

                Tuple.Create<ToolBase, Rectangle>(
                    new TextTool("This is an awesome text"),
                    new Rectangle(250, 50, 250, 50)),

                Tuple.Create<ToolBase, Rectangle>(
                    new TextTool("This is an awesome text"),
                    new Rectangle(250, 50, 250, 50)),


                Tuple.Create<ToolBase, Rectangle>(
                    new ImageTool("DrawingComponents.Properties.xplicity.jpg"),
                    
                    new Rectangle(150, 100, 170, 149)),

                Tuple.Create<ToolBase, Rectangle>(
                    new BorderDecorator(),
                    new Rectangle(150, 100, 170, 149)),
            };
        }
    }
}