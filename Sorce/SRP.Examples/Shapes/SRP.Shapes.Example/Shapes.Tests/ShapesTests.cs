using System.Windows.Forms;
using NUnit.Framework;

namespace Shapes.Tests
{
    [TestFixture]
    public class ShapesTestFixture
    {
        [Test]
        public void Problem_TestRectangleShape_AddHeightWidhtAndForm_TestResultAreaAndFormDrawing()
        {
            const int expected = 4 * 5;

            //Arrange
            var rectangleShape = new Shapes.Problem.RectangleShape { Height = 4, Width = 5 };

            //Act
            var area = rectangleShape.Area();
            var form = new Form();
            rectangleShape.Draw(form);

            //Assert 
            Assert.That(area, Is.EqualTo(expected));
            Assert.That(form.Text, Is.EqualTo("RectangleDrawn"));
        }

        [Test]
        public void Solution_TestRectangleShape_AddHeightWidhtAndForm_TestResultAreaAndFormDrawing()
        {
            const int expected = 4 * 5;

            //Arrange
            var rectangleShape = new Shapes.Solution.RectangleShape();
            var rectangleDraw = new Shapes.Solution.RectangleDraw();

            rectangleShape.Height = 4;
            rectangleShape.Width = 5;
            //Act
            var area = rectangleShape.Area();
            var form = new Form();

            rectangleDraw.Draw(form, rectangleShape);

            //Assert 
            Assert.That(area, Is.EqualTo(expected));
            Assert.That(form.Text, Is.EqualTo("RectangleDrawn"));
        }
    }
}
