using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = SortStringArrayInsertionSort("dcba");
           // var x = InsertionSortArray(new string[] { "geek", "balls", "codede", "rid" });


            Console.WriteLine();
        }

        public static string SortStringArrayInsertionSort(string x) 
        {
            char[] arr = x.ToCharArray();
            for(int i = 0; i < arr.Length; i++) 
            {
                char key = arr[i];
                int j = i - 1;

              //  Console.WriteLine($"arr[j] is {arr[j]}");
             //   Console.WriteLine($"key is {key}");
                while (j >= 0 && arr[j] > key) 
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                
            }
            return new string(arr);
        }
        public static string SortStrings(string x)
        {
            char[] arr = x.ToCharArray();
            for(int i = 0; i < arr.Length-1; i++) 
            {
                int minIndex = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[minIndex]) 
                    {
                        minIndex = j;
                    }
                }
                char temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }

            return new string(arr);
        }

        public static int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min_index = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min_index])
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


        public static string[] SortAlphabetically(string[] arr) 
        {
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                dict[arr[i]] = i;               
            }

            var m = 0;

            foreach(var item in dict.OrderBy(x => x.Key)) 
            {
                arr[m] = item.Key;
                m++;
            }

            return arr;

            
            
        }       

        public static string[] InsertionSortArray(string[] arr) 
        {
            for(int i = 0; i < arr.Length; i++) 
            {
                string key = arr[i];
                int j = i - 1;

               // Console.WriteLine(arr[j]);
                    while(j >= 0 && arr[j].Length > key.Length) 
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = key;
                
                
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
                //2,6,4,8,3,9
                int key = arr[i];
                int j = i - 1;

                Console.WriteLine($"key is {key}");
                Console.WriteLine($"arr[j] is {arr[j]}");
                Console.WriteLine();

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
