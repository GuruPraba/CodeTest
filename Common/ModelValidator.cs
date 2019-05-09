using CanvasApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.Common
{
    public static class ModelExtractor
    {
        public static BucketFillModel GetBucketFillModel(string input)
        {
            BucketFillModel model = new BucketFillModel();

            string[] values = input.Split(' ');
            string code = values[0].ToUpper();
            string colour = string.Empty;
            uint x, y;


            if (values.Length != 4 || code != "B")
                throw new ArgumentOutOfRangeException("Fill dimensions are not valid!");

            if (uint.TryParse(values[1], out x) && x > 0 && uint.TryParse(values[2], out y) && y > 0)
            {
                model.Code = code;
                model.X = x;
                model.Y = y;
                model.Colour = !string.IsNullOrWhiteSpace(values[3]) ? values[3] : "c";
            }
            else
            {
                throw new ArgumentException("Fill dimensions must be positive integers!");
            }

            return model;
        }

        public static RectangleModel GetRectangleModel(string input)
        {
            RectangleModel model = new RectangleModel();

            string[] values = input.Split(' ');
            string code = values[0].ToUpper();
            uint x1, y1, x2, y2;

            if (values.Length != 5 || code != "R")
                throw new ArgumentOutOfRangeException("Rectangle dimensions are not valid!");

            if (uint.TryParse(values[1], out x1) && x1 > 0 && uint.TryParse(values[2], out y1) && y1 > 0 && uint.TryParse(values[3], out x2) && x2 > 0 && uint.TryParse(values[4], out y2) && y2 > 0)
            {
                model.Code = code;
                model.X1 = x1;
                model.Y1 = y1;
                model.X2 = x2;
                model.Y2 = y2;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Rectangle dimensions must be positive integers!");
            }

            return model;
        }

        public static LineModel GetLineModal(string input)
        {
            LineModel model = new LineModel();

            string[] values = input.Split(' ');
            string code = values[0].ToUpper();
            uint x1, y1, x2, y2;

            if (values.Length != 5 || code != "L")
                throw new ArgumentOutOfRangeException("Line dimensions are not valid!");

            if (uint.TryParse(values[1], out x1) && x1 > 0 && uint.TryParse(values[2], out y1) && y1 > 0 && uint.TryParse(values[3], out x2) && x2 > 0 && uint.TryParse(values[4], out y2) && y2 > 0)
            {
                model.Code = code;
                model.X1 = x1;
                model.Y1 = y1;
                model.X2 = x2;
                model.Y2 = y2;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Line dimensions must be positive integers!");
            }

            return model;
        }

        public static CanvasModel GetCanvasModel(string input)
        {
            CanvasModel model = null;
            string[] values = input.Split(' ');
            uint width = 0, height = 0;

            if (values.Length != 3 || values[0].ToUpper() != "C")
                throw new ArgumentOutOfRangeException("Canvas dimensions are not valid!");

            if (uint.TryParse(values[1], out width) && width > 0 && uint.TryParse(values[2], out height) && height > 0)
            {
                model = new CanvasModel();
                model.Width = width;
                model.Height = height;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Canvas dimensions must be positive integers!");
            }

            return model;
        }


    }
}
