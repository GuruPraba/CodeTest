using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.Components
{
    public class Line : IShape
    {
        private static char SKETCH = 'x';
        uint x1, y1, x2, y2;

        public Line(uint x1, uint y1, uint x2, uint y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public void addTo(Canvas canvas)
        {
            if (!validLineOnCanvas(canvas))
                throw new InvalidOperationException("Invalid line!\n");

            if (isHorizontal())
            {
                for (uint i = 0; i <= length(); i++)
                    canvas.lineAt(x1 + i, y1, SKETCH);
            }
            else
            {
                for (uint i = 0; i <= length(); i++)
                    canvas.lineAt(x1, y1 + i, SKETCH);
            }
        }

        private uint length()
        {
            if (isHorizontal())
                return x2 - x1;
            return y2 - y1;
        }

        private bool validLineOnCanvas(Canvas canvas)
        {
            // check that line completely on canvas
            if (x1 < 0 || y1 < 0 || x2 > canvas.Width || y2 > canvas.Height)
                return false;

            // diagonal line not supported in this version
            if (x1 != x2 && y1 != y2)
                return false;

            return true;
        }

        private bool isHorizontal()
        {
            return y1 == y2;
        }
    }
}
