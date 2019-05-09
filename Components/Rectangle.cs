using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.Components
{
    public class Rectangle : IShape
    {
        private static char REPRESENTATION = 'x';

        uint x1, y1, x2, y2;

        public Rectangle(uint x1, uint y1, uint x2, uint y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public void addTo(Canvas canvas)
        {
            if (!validRectangleOnCanvas(canvas))
                throw new InvalidOperationException("Invalid rectangle!");

            // horizontal lines
            for (uint i = 0; i < width(); i++)
                canvas.lineAt(x1 + i, y1, REPRESENTATION);
            for (uint i = 0; i < width(); i++)
                canvas.lineAt(x1 + i, y2, REPRESENTATION);

            // vertical lines
            for (uint i = 0; i < height() - 2; i++)
                canvas.lineAt(x1, y1 + i + 1, REPRESENTATION);
            for (uint i = 0; i < height() - 2; i++)
                canvas.lineAt(x2, y1 + i + 1, REPRESENTATION);
        }

        private uint height()
        {
            return y2 - y1 + 1;
        }

        private uint width()
        {
            return x2 - x1 + 1;
        }

        private bool validRectangleOnCanvas(Canvas canvas)
        {
            // rectangle on canvas?
            if (x1 < 0 || y1 < 0 || x2 > canvas.Width || y2 > canvas.Height)
                return false;

            return true;
        }
    }
}
