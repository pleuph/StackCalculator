using System.Text;

namespace StackCalculatorLogic
{
    public class StackCalculatorService
    {
        const string allowedCharacters = "0123456789+-*/";

        public int Calculate(string input)
        {
            throw new NotImplementedException();
        }

        public static string ScrubInput(string input)
        {
            var sb = new StringBuilder();
            foreach(var c in input)
                if(allowedCharacters.Contains(c))
                    sb.Append(c);
            return sb.ToString();
        }
    }
}