namespace StackCalculatorLogic
{
    public class StatefulStackCalculator
    {
        Stack<double> stack = new Stack<double>();
        int operationCount = 0;
        Random random = new Random();

        public void Enter(double value) => stack.Push(value);

        public double Add() => OperationOrRandom(() => stack.Pop() + stack.Pop());

        public double Subtract() => OperationOrRandom(() => stack.Pop() - stack.Pop());

        public double Multiply() => OperationOrRandom(() => stack.Pop() * stack.Pop());

        public double Divide() => OperationOrRandom(() => stack.Pop() / stack.Pop());

        double OperationOrRandom(Func<double> operation)
        {
            operationCount++;

            //Reset operation counter and return random on every 10th operation.
            if (operationCount == 10)
            {                
                operationCount = 0;
                //Return a non-zero random so we can use 0 as control for testing.
                return 1 + random.NextDouble() * random.Next(1, int.MaxValue);
            }

            return stack.Count < 2 ? 0 : operation();
        }
    }
}
