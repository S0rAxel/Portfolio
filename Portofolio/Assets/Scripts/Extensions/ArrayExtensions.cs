public static class ArrayExtensions
{
    public static void Reverse<T>(this T[] array)
    {
        if (array.Length <= 0) return;

        int n = array.Length;
        T[] aux = new T[n];
        for (int i = 0; i < n; i++)
            aux[n - 1 - i] = array[i];

        for (int i = 0; i < n; i++)
            array[i] = aux[i];
    }

    public static T RandomElement<T>(this T[] array)
    {
        if (array.Length == 0) return default(T);
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static void Shuffle<T>(this T[] array)
    {
        if (array.Length <= 0) return;

        System.Random random = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    public static T Mode<T>(this T[] array)
    {
        if (array.Length <= 0) return default(T);

        var dictionary = new System.Collections.Generic.Dictionary<T, int>();

        foreach (T element in array)
        {
            if (dictionary.ContainsKey(element))
                dictionary[element]++;
            else
                dictionary.Add(element, 1);
        }

        int max = 0;
        T mostElement = default(T);
        foreach (T element in dictionary.Keys)
        {
            dictionary.TryGetValue(element, out int count);
            if (count > max)
            {
                max = count;
                mostElement = element;
            }
        }

        return mostElement;
    }

    public static int Sum(this int[] array)
    {
        if (array.Length <= 0) return 0;
        int sum = 0;
        foreach (int num in array)
            sum += num;
        return sum;
    }

    public static int Average(this int[] array)
    {
        if (array.Length <= 0) return 0;
        return array.Sum() / array.Length;
    }

    public static float Sum(this float[] array)
    {
        if (array.Length <= 0) return 0.0f;
        float sum = 0.0f;
        foreach (float num in array)
            sum += num;
        return sum;
    }

    public static float Average(this float[] array)
    {
        if (array.Length <= 0) return 0.0f;
        return array.Sum() / array.Length;
    }

    public static void QuickSort(this int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    public static void MergeSort(this int[] array)
    {
        MergeSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int a, int b)
    {
        if (a < b)
        {
            int p = Partition(array, a, b);

            QuickSort(array, a, p - 1);
            QuickSort(array, p + 1, b);
        }
    }

    private static int Partition(int[] array, int a, int b)
    {
        int pivot = array[b];

        int index = a - 1;

        for (int i = a; i < b - 1; i++)
        {
            if (array[i] < pivot)
            {
                index++;
                Swap(array, index, i);
            }
        }
        Swap(array, index + 1, b);
        return index + 1;
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    private static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int m = left + (right - 1) / 2;

            MergeSort(array, left, m);
            MergeSort(array, m + 1, right);

            Merge(array, left, m, right);
        }
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        int i;
        int j;

        for (i = 0; i < n1; i++)
        {
            leftArray[i] = array[left + i];
        }
        for (j = 0; j < n2; j++)
        {
            rightArray[j] = array[middle + 1 + j];
        }

        i = 0;
        j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }

    }
}
