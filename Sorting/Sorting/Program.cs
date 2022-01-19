using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new string[] { "GeeksforGeeeks", "I", "from", "am" };
            var t = SortArray(x);
            Console.WriteLine();
        }

        public static string[] SortArray(string[] arr) 
        {
            for(int i = 1; i < arr.Length; i++) 
            {
                string temp = arr[i];

                //insert s[i] at it's correct position
                int j = i - 1;
                while (j >= 0 && temp.Length < arr[j].Length)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
            return arr;
        }

        public static string[] SortElements(string[] arr)
        {
            var dict = new Dictionary<string, int>();

            foreach (var item in arr)
            {
                dict[item] = item.Length;
            }

            var n = 0;

            foreach (var item in dict.OrderBy(x => x.Value)) 
            {
                
                arr[n] = item.Key;
                n++;
            }

                return arr;
        }

        public static int[] SelectionSort(int[] arr) 
        {
           for(int i = 0; i < arr.Length-1; i++) 
            {
                int min_index = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[min_index]) 
                    {
                        min_index = j;
                    }
                }

                int temp = arr[min_index];
                arr[min_index] = arr[i];
                arr[i] = temp;
            }

            
            return arr;
        }

        public static int[] BubbleSort(int[] arr) 
        {
            int n = arr.Length;
            for (int i = 0; i < n-1; i++)
            {
                Console.WriteLine(n-i-1);
                for (int j = 0; j < n-i-1; j++)
                {
                    if(arr[j] > arr[j + 1]) 
                    {
                        //swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        public static int[] BubbleSortOpt(int[] arr, int n)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j] and arr[j+1]
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // IF no two elements were 
                // swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                //8,5,4,2,3
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        

    }
}
