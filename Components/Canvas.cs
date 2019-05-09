using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.Components
{
    public class Canvas
    {
        private static char BLANK = ' ';

        public uint Width { get; set; }
        public uint Height { get; set; }
        public char[,] squares;

        public Canvas(uint w, uint h)
        {
            this.Width = w;
            this.Height = h;
            squares = new char[w, h];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                    squares[i, j] = BLANK;
            }
        }

        public void lineAt(uint x1, uint y1, char c)
        {
            squares[x1 - 1, y1 - 1] = c;
        }

        public void fill(uint x, uint y, char c)
        {
            if (x <= 0 || x > Width || y <= 0 || y > Height || squares[x - 1, y - 1] != BLANK)
                return;

            squares[x - 1, y - 1] = c;

            fill(x + 1, y, c);
            fill(x - 1, y, c);
            fill(x, y + 1, c);
            fill(x, y - 1, c);
        }

        public void draw()
        {

            // First row of canvas
            for (int i = 0; i < Width + 2; i++)
                System.Console.Write('-');

            System.Console.WriteLine();

            for (int i = 0; i < Height; i++)
            {
                System.Console.Write('|');
                for (int j = 0; j < Width; j++)
                    System.Console.Write(squares[j, i]);
                System.Console.Write('|');
                System.Console.WriteLine();
            }

            // Last row of canvas
            for (int i = 0; i < Width + 2; i++)
                System.Console.Write('-');

            System.Console.WriteLine();
        }
    }
}
