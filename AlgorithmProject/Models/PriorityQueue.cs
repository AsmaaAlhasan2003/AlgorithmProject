class PriorityQueue
{
    private List<KeyValuePair<int, string>> queue;

    public PriorityQueue()
    {
        queue = new List<KeyValuePair<int, string>>();
    }

    //  ≈œ—«Ã ⁄‰’— „⁄ √Ê·ÊÌ…
    public void Enqueue(string item, int priority)
    {
        KeyValuePair<int, string> newItem = new KeyValuePair<int, string>(priority, item);
        queue.Add(newItem);
        queue.Sort((a, b) => a.Key.CompareTo(b.Key)); //  — Ì» «·√Ê·ÊÌ«  ( ’«⁄œÌ)
    }

    // ≈“«·… «·⁄‰’— –Ê «·√Ê·ÊÌ… «·√⁄·Ï
    public string Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        string item = queue[0].Value;
        queue.RemoveAt(0);
        return item;
    }

    //  ≈—Ã«⁄ «·⁄‰’— –Ê «·√Ê·ÊÌ… «·√⁄·Ï œÊ‰ Õ–›Â
    public string Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return queue[0].Value;
    }

    //  «· Õﬁﬁ „„« ≈–« ﬂ«‰  «·ﬁ«∆„… ›«—€…
    public bool IsEmpty()
    {
        return queue.Count == 0;
    }

    //  ÿ»«⁄… ⁄‰«’— «·ÿ«»Ê— Õ”» «·√Ê·ÊÌ…
    public void Print()
    {
        Console.WriteLine("Priority Queue:");
        foreach (var item in queue)
        {
            Console.WriteLine($"Item: {item.Value}, Priority: {item.Key}");
        }
    }

    //  «·»ÕÀ ⁄‰ ⁄‰’— »«” Œœ«„ «·ﬁÌ„…
    public bool SearchByValue(string value)
    {
        return queue.Exists(x => x.Value == value);
    }

    //  «·»ÕÀ ⁄‰ ⁄‰’— »«” Œœ«„ «·√Ê·ÊÌ…
    public List<string> SearchByPriority(int priority)
    {
        List<string> results = new List<string>();
        foreach (var item in queue)
        {
            if (item.Key == priority)
            {
                results.Add(item.Value);
            }
        }
        return results;
    }

    //  «·»ÕÀ ⁄‰ ⁄‰’— »«” Œœ«„ «·ﬁÌ„… Ê«·√Ê·ÊÌ… „⁄«
    public bool SearchByValueAndPriority(string value, int priority)
    {
        return queue.Exists(x => x.Value == value && x.Key == priority);
    }

    //////ŒÊ«—“„Ì«««  «· — Ì» 
    public static int BubbleSort(int[] arr)
    {
        int comparisons = 0, swaps = 0;
        bool isSorted = false;
        for (int i = 0; i < arr.Length; i++)
        {
            isSorted = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                comparisons++;
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swaps++;
                    isSorted = true;
                }
            }
            if (!isSorted) break;
        }
        Console.WriteLine($"Bubble Sort - Comparisons: {comparisons}, Swaps: {swaps}");
        return comparisons + swaps;
    }

    public static int SelectionSort(int[] arr)
    {
        int comparisons = 0, swaps = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                comparisons++;
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
                swaps++;
            }
        }
        Console.WriteLine($"Selection Sort - Comparisons: {comparisons}, Swaps: {swaps}");
        return comparisons + swaps;
    }

    public static int InsertionSort(int[] arr)
    {
        int comparisons = 0, swaps = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                comparisons++;
                arr[j + 1] = arr[j];
                j--;
                swaps++;
            }
            arr[j + 1] = key;
        }
        Console.WriteLine($"Insertion Sort - Comparisons: {comparisons}, Swaps: {swaps}");
        return comparisons + swaps;
    }

    public static int MergeSort(int[] arr, int start, int end)
    {
        int comparisons = 0;
        if (start < end)
        {
            int mid = start + (end - start) / 2;
            comparisons += MergeSort(arr, start, mid);
            comparisons += MergeSort(arr, mid + 1, end);
            comparisons += Merge(arr, start, mid, end);
        }
        return comparisons;
    }

    public static int Merge(int[] arr, int start, int mid, int end)
    {
        int comparisons = 0;
        int leftSize = mid - start + 1;
        int rightSize = end - mid;
        int[] left = new int[leftSize];
        int[] right = new int[rightSize];

        Array.Copy(arr, start, left, 0, leftSize);
        Array.Copy(arr, mid + 1, right, 0, rightSize);

        int i = 0, j = 0, k = start;
        while (i < leftSize && j < rightSize)
        {
            comparisons++;
            if (left[i] <= right[j])
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }
        while (i < leftSize) arr[k++] = left[i++];
        while (j < rightSize) arr[k++] = right[j++];

        return comparisons;
    }
    ////////////œ«·…  ﬁ«—‰ √œ«¡ ŒÊ«—“„Ì«  «· — Ì» «·„Œ ·›…
    public static void CompareSortingAlgorithms(int[] arr)
    {
        int[] temp;

        temp = (int[])arr.Clone();
        BubbleSort(temp);

        temp = (int[])arr.Clone();
        SelectionSort(temp);

        temp = (int[])arr.Clone();
        InsertionSort(temp);

        temp = (int[])arr.Clone();
        Console.WriteLine($"Merge Sort - Comparisons: {MergeSort(temp, 0, temp.Length - 1)}");
    }
}
