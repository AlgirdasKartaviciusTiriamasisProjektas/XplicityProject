using DrawingComponents;
using System.Linq;
using System.Windows.Forms;

namespace Stratup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var gr = e.Graphics;

            ToolsFactory.Create()
                .ToList()
                .ForEach(tuple => tuple.Item1.Draw(gr, tuple.Item2));

            base.OnPaint(e);
        }
    }
}
