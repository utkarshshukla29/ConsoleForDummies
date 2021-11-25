namespace Dummy.Arrays.Puzzles
{
    public class SumOfElements
    {
        public void Execute(int[] inputArray, int sumOfNumbers)
        {
            System.Console.WriteLine("Finding sum of numbers");
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if(inputArray[i] + inputArray[j]==sumOfNumbers)
                    {
                        System.Console.WriteLine($"numbers {inputArray[i]} and {inputArray[j]} are identified at position {i+1}, {j+1}");
                        break;
                    }
                }
            }
        }
    }
}