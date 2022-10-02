using System.Net.Http.Json;

namespace StackCalculatorLogic
{
    public class StatefulStackCalculator
    {
        Stack<double> stack = new Stack<double>();
        int operationCount = 0;
        Random random = new Random();
        HttpClient httpClient = new HttpClient();

        public void Enter(double value) => stack.Push(value);

        public async Task<double> Add() => await OperationOrRandom(() => stack.Pop() + stack.Pop());

        public async Task<double> Subtract() => await OperationOrRandom(() => stack.Pop() - stack.Pop());

        public async Task<double> Multiply() => await OperationOrRandom(() => stack.Pop() * stack.Pop());

        public async Task<double> Divide() => await OperationOrRandom(() => stack.Pop() / stack.Pop());

        internal async Task<int> GetRandom()
        {
            var request = $"https://www.randomnumberapi.com/api/v1.0/random?min=1&max={int.MaxValue}";
            var response = await httpClient.GetAsync(request);
            var result = await response.Content.ReadFromJsonAsync<int[]>();
            return result.First();
        }

        async Task<double> OperationOrRandom(Func<double> operation)
        {
            operationCount++;

            //Reset operation counter and return random on every 10th operation.
            if (operationCount == 10)
            {
                operationCount = 0;
                //Return a non-zero random so we can use 0 as control for testing.
                return 1 + random.NextDouble() * await GetRandom();
            }

            return stack.Count < 2 ? 0 : operation();
        }
    }
}
