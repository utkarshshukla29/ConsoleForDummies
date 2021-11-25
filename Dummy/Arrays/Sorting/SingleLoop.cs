namespace Dummy.Arrays.Sorting
{
    public class SingleLoop
    {
        public void Execute(int[] inputArrays)
        {
            System.Console.WriteLine("Single loop Sort");

            for (int counter = 0; counter < inputArrays.Length - 1; counter++)
            {
               if(inputArrays[counter] > inputArrays[counter+1])
               {
                   int temp = inputArrays[counter];
                   inputArrays[counter] = inputArrays[counter + 1];
                   inputArrays[counter+1] = temp;                   
                   counter = -1;
               }
            }
            System.Console.WriteLine(string.Join(",", inputArrays));
        }
    }
}