namespace Dummy.Arrays.Sorting
{
    public class MergeSort
    {
        public void Execute(int[] inputArray)
        {
            System.Console.WriteLine("Merge Sort");

            MergingArray(inputArray, 0, inputArray.Length - 1);

            System.Console.WriteLine(string.Join(",", inputArray));
        }

        private void MergingArray(int[] inputArray, int min, int max)
        {
            if (min < max)
            {
                int middle = min + (max - min) / 2;

                MergingArray(inputArray, min, middle);

                MergingArray(inputArray, middle + 1, max);

                Merge(inputArray, min, middle, max);
            }
        }

        private void Merge(int[] inputArray, int min, int middle, int max)
        {
            int k1 = middle - min + 1;
            int k2 = max - middle;

            int[] subArray1 = new int[k1];
            int[] subArray2 = new int[k2];

            for (int i = 0; i < k1; i++)
            {
                subArray1[i] = inputArray[min + i];
            }

            for (int i = 0; i < k2; i++)
            {
                subArray2[i] = inputArray[middle + 1 + i];
            }
            int j = 0, k = 0, l = min;
            while (j < k1 && k < k2)
            {
                if (subArray1[j] > subArray2[k])
                {
                    inputArray[l] = subArray2[k];
                    k++;
                }
                else
                {
                    inputArray[l] = subArray1[j];
                    j++;
                }
                l++;
            }
            while (j < k1)
            {
                inputArray[l] = subArray1[j];
                j++;
                l++;
            }
            while (k < k2)
            {
                inputArray[l] = subArray2[k];
                k++;
                l++;
            }

        }
    }
}