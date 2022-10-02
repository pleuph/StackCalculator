namespace StackCalculatorLogic
{
    public class StatefulStackCalculator
    {
        Stack<double> stack = new Stack<double>();
        int operationCount = 0;
        Random random = new Random();

        public void Enter(double value) => stack.Push(value);

        public double Add(double value) => OperationOrRandom(value, () => stack.Pop() + value);

        public double Subtract(double value) => OperationOrRandom(value, () => stack.Pop() - value);

        public double Multiply(double value) => OperationOrRandom(value, () => stack.Pop() * value);

        public double Divide(double value) => OperationOrRandom(value, () => stack.Pop() / value);

        double OperationOrRandom(double value, Func<double> operation)
        {
            operationCount++;

            //Reset operation counter and return random on every 10th operation.
            if (operationCount == 10)
            {                
                operationCount = 0;
                //Return a non-zero random so we can use 0 as control for testing.
                return 1 + random.NextDouble() * random.Next(1, int.MaxValue);
            }

            //If there's nothing on the stack, return the value. Otherwise, perform operation.
            return stack.Count == 0 ? value : operation();
        }
    }
}
