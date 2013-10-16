using System.Drawing;
using System.Windows.Forms;

namespace Shapes.Problem
{
    /// <summary>
    /// Class calculates the area and can also draw it on a windows form object.
    /// </summary>
    public class RectangleShape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Area()
        {
            return Width * Height;
        }

        public void Draw(Form form)
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Red);
            Graphics formGraphics = form.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, Width, Height));
            form.Text = "RectangleDrawn";
        }
    }
}
