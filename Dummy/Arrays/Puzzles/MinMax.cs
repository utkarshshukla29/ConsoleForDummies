namespace Dummy.Arrays.Puzzles
{
    public class MinMax
    {
        public void Execute(int[] inputArray)
        {
            System.Console.WriteLine("Finding Min - Max");
            int min = inputArray[0];
            int max = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++)
            {
                if(inputArray[i] < min)
                {
                    min = inputArray[i];
                }
                if(inputArray[i] > max)
                {
                    max = inputArray[i];
                }
            }

            System.Console.WriteLine($"min element {min} and max element {max}");
        }
    }
}