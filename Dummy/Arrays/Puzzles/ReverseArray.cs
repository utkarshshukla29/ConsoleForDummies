namespace Dummy.Arrays.Puzzles
{
    public class ReverseArray
    {
        public void Execute(int[] inputArray)
        {
            System.Console.WriteLine("Reverse Array");
            for (int i = 0, j = inputArray.Length- 1; i < j; i++, j--)
            {
                int temp = inputArray[i];
                inputArray[i] = inputArray[j];
                inputArray[j] = temp;
            }
            System.Console.WriteLine(string.Join(",", inputArray));
        }
    }
}