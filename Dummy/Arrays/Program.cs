// See https://aka.ms/new-console-template for more information
using Dummy.Arrays.Sorting;

namespace Dummy.Arrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] inputArray = new int[] { 5, 4, 30, 2, 1, 6, 7, -1, 8 };
            new SingleLoop().Execute(inputArray);
            new Puzzles.ReverseArray().Execute(inputArray);
            new Puzzles.MinMax().Execute(inputArray);
            int [] arrayParam = new int[]{1,4,5,6,3,8,9,1,5,6,8,0,2};
            new Puzzles.SumOfElements().Execute(arrayParam, 2);
            new Sorting.MergeSort().Execute(arrayParam);
        }
    }
}
