using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApp.Common
{
    public static class Helper
    {
        public static CanvasAppCommands GetCommandName(string input)
        {
            CanvasAppCommands command = CanvasAppCommands.OTHER;
            string code = input.Split(' ')[0];

            try
            {
                switch (code.ToUpper())
                {
                    case "C":
                        command = CanvasAppCommands.CREATE;
                        break;

                    case "L":
                        command = CanvasAppCommands.LINE;
                        break;

                    case "R":
                        command = CanvasAppCommands.RECTANGLE;
                        break;

                    case "B":
                        command = CanvasAppCommands.BUCKET_FILL;
                        break;

                    case "Q":
                        command = CanvasAppCommands.QUIT;
                        break;
                    default:
                        command = CanvasAppCommands.OTHER;
                        break;
                }
            }
            catch (Exception)
            {
                throw new InvalidCastException("Invalid command");
            }

            return command;
        }

        public static bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string[] inputValues = input.Split(' ');
            string command = inputValues[0] != null ? inputValues[0].ToUpper() : string.Empty;

            if (!(command.Length == 1 && (command.Equals("C") || command.Equals("L") || command.Equals("R") || command.Equals("B") || command.Equals("Q"))))
            {
                return false;
            }

            return true;
        }

        public static bool IsExitCommand(string input)
        {
            string[] values = input.Split(' ');
            bool flag = false;

            if (values.Length == 1 && values[0].ToUpper() == "Q")
                flag = true;

            return flag;
        }
    }
}
