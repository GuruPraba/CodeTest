using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.Components
{
    public class BaseCanvas
    {
        private Canvas canvas;

        public void crateCanvas(uint width, uint height)
        {
            canvas = new Canvas(width, height);
        }

        public void addLine(uint x1, uint y1, uint x2, uint y2)
        {
            verifyCanvas();

            Line line = new Line(x1, y1, x2, y2);
            line.addTo(canvas);
        }

        public void addRectangle(uint x1, uint y1, uint x2, uint y2)
        {
            verifyCanvas();

            Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
            rectangle.addTo(canvas);
        }

        public void fill(uint x, uint y, char c)
        {
            verifyCanvas();
         
            canvas.fill(x, y, c);
        }

        public void draw()
        {
            verifyCanvas();

            canvas.draw();
        }

        private void verifyCanvas()
        {
            if (canvas == null)
                throw new InvalidOperationException("Canvas must be created firstly.\n");
        }
    }
}
