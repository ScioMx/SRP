using System.Drawing;
using System.Windows.Forms;

namespace Shapes.Solution
{
    /// <summary>
    /// Class draws a rectangle on a windows form object.
    /// </summary>
    public class RectangleDraw
    {
        public void Draw(Form form, RectangleShape rectangleShape)
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Red);
            Graphics formGraphics = form.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, rectangleShape.Width, rectangleShape.Height));
            form.Text = "RectangleDrawn";
        }
    }
}