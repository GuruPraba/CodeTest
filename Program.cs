using CanvasApp.Common;
using CanvasApp.Components;
using CanvasApp.Model;
using System;

namespace CanvasApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            CanvasAppCommands command = CanvasAppCommands.OTHER;
            CanvasModel canvasModel = null;
            BaseCanvas baseCanvas = null;
            string input = string.Empty;

            do
            {
                try
                {
                    Console.Write("Enter the command: ");
                    input = Console.ReadLine().Trim();
                    if (Helper.IsValidInput(input))
                    {
                        if (Helper.IsExitCommand(input))
                            break;

                        command = Helper.GetCommandName(input);
                        if (canvasModel == null)
                        {
                            canvasModel = ModelExtractor.GetCanvasModel(input);

                            baseCanvas = new BaseCanvas();
                            baseCanvas.crateCanvas(canvasModel.Width, canvasModel.Height);
                        }

                        if (canvasModel != null)
                        {
                            
                            if (command == CanvasAppCommands.LINE)
                            {
                                LineModel lineModal = new LineModel();

                                lineModal = ModelExtractor.GetLineModal(input);
                                baseCanvas.addLine(lineModal.X1, lineModal.Y1, lineModal.X2, lineModal.Y2);
                            }

                            if (command == CanvasAppCommands.RECTANGLE)
                            {
                                RectangleModel rectangleModel = new RectangleModel();

                                rectangleModel = ModelExtractor.GetRectangleModel(input);
                                baseCanvas.addRectangle(rectangleModel.X1, rectangleModel.Y1, rectangleModel.X2, rectangleModel.Y2);
                            }

                            if (command == CanvasAppCommands.BUCKET_FILL)
                            {
                                BucketFillModel bucketFillModel = new BucketFillModel();

                                bucketFillModel = ModelExtractor.GetBucketFillModel(input);
                                baseCanvas.fill(bucketFillModel.X, bucketFillModel.Y, Convert.ToChar(bucketFillModel.Colour));
                            }


                            baseCanvas.draw();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command!!! Please try again...\n");
                    }
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to create Canvas!!!");
                    Console.WriteLine("Please try again C 10 4 ==>  C widht height \n");
                }

                input = string.Empty;

            } while (command != CanvasAppCommands.QUIT);
        }
              
    }
}
