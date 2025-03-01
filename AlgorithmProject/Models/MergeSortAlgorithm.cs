using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmProject.Models
{
    public static class SortAlgorithms
    {
        // دالة ترتيب Merge Sort التي تأخذ مصفوفة من الأرقام وترجع المصفوفة المرتبة
        public static List<int> MergeSort(List<int> array)
        {
            if (array == null || array.Count <= 1)
                return array;

            int mid = array.Count / 2;
            // تقسيم المصفوفة إلى جزأين
            List<int> left = array.Take(mid).ToList();
            List<int> right = array.Skip(mid).ToList();

            // ترتيب الجزأين بشكل منفصل
            left = MergeSort(left);
            right = MergeSort(right);

            // دمج الجزأين المرتبين
            return Merge(left, right);
        }

        // دالة لدمج مصفوفتين مرتبتين في مصفوفة واحدة مرتبة
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }
            // إضافة العناصر المتبقية في المصفوفة اليسرى (إن وجدت)
            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }
            // إضافة العناصر المتبقية في المصفوفة اليمنى (إن وجدت)
            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }
            return result;
        }

        // دالة لحذف عنصر من المصفوفة باستخدام MergeSort
        public static List<int> RemoveItem(List<int> array, int item)
        {
            if (array.Contains(item))
            {
                array.Remove(item);
                return MergeSort(array); // إعادة ترتيب المصفوفة بعد الحذف
            }
            return array;
        }

        // دالة لتعديل قيمة عنصر في المصفوفة
        public static List<int> UpdateItem(List<int> array, int oldItem, int newItem)
        {
            int index = array.IndexOf(oldItem);
            if (index != -1)
            {
                array[index] = newItem;
                return MergeSort(array); // إعادة ترتيب المصفوفة بعد التعديل
            }
            return array;
        }

        // خوارزمية BubbleSort
        public static (List<int>, int, int) BubbleSort(List<int> array)
        {
            int comparisons = 0, swaps = 0;
            for (int i = 0; i < array.Count - 1; i++)
            {
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        swaps++;
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return (array, comparisons, swaps);
        }

        // خوارزمية SelectionSort
        public static (List<int>, int, int) SelectionSort(List<int> array)
        {
            int comparisons = 0, swaps = 0;
            for (int i = 0; i < array.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    comparisons++;
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    swaps++;
                    var temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
            return (array, comparisons, swaps);
        }

        // خوارزمية InsertionSort
        public static (List<int>, int, int) InsertionSort(List<int> array)
        {
            int comparisons = 0, swaps = 0;
            for (int i = 1; i < array.Count; i++)
            {
                int current = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > current)
                {
                    comparisons++;
                    swaps++;
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
            return (array, comparisons, swaps);
        }
    }
}
