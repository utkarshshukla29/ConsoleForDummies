namespace Dummy.Arrays.Sorting
{
    public class InsertionSort
    {
        public void Execute(int[] inputArrays)
        {
            System.Console.WriteLine("Insertion Sort");

            for (int counter = 1; counter < inputArrays.Length; counter++)
            {
               // int currentValue = inputArrays[counter];
                for (int j = counter - 1; j >= 0; j--)
                {
                    if(inputArrays[j+1] < inputArrays[j])
                    {
                        int temp = inputArrays[j+1];
                        inputArrays[j+1] = inputArrays[j];
                        inputArrays[j] = temp;
                    }
                }
            }

            System.Console.WriteLine(string.Join(",", inputArrays));
        }
    }
}