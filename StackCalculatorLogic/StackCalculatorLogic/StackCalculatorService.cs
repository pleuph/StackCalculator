using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("StackCalculatorLogic.Tests")]

namespace StackCalculatorLogic
{
    public class StackCalculatorService
    {
        const string allowedCharacters = "0123456789+-*/";

        public string TryCalculate(string input)
        {
            var scrubbedInput = ScrubInput(input);
            try
            {
                return Calculate(input).ToString();
            }
            catch (Exception)
            {
                return "Invalid input";
            }
        }

        internal static int Calculate(string scrubbedInput)
        {
            var stack = new Stack<int>();
            foreach(var c in scrubbedInput)
            {
                if (int.TryParse(c.ToString(), out int number))
                    stack.Push(number);
                else
                {
                    var a = stack.Pop();
                    var b = stack.Pop();
                    var result = c switch
                    {
                        '+' => a + b,
                        '-' => a - b,
                        '*' => a * b,
                        '/' => a / b
                    };
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }

        internal static string ScrubInput(string input)
        {
            var sb = new StringBuilder();
            foreach(var c in input)
                if(allowedCharacters.Contains(c))
                    sb.Append(c);
            return sb.ToString();
        }
    }
}