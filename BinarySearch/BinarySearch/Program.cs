using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new int[] { 3,6,7,11 };
            var y = MinimumEatingSpeed(x, 8);
            Console.WriteLine();
           
        }

        public static int BinarySearch(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                Console.WriteLine(inputArray[mid]);
                if (inputArray[mid] == key)
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public static int FirstIndexOccurance(int[] nums, int element)
        {
            int min = 0;
            int max = nums.Length - 1;
            int result = -1;
            while(min <= max) 
            {
                int mid = (min + max) / 2;

                if(element == nums[mid]) 
                {
                    result = mid;
                    max = mid - 1;
                }
                else if(element < nums[mid]) 
                {
                    max = mid - 1;
                }
                else 
                {
                    min = mid + 1;
                }
            }
            return result;
        }

        public static int LastIndexOccurance(int[] nums, int element)
        {
            int min = 0;
            int max = nums.Length - 1;
            int result = -1;
            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (element == nums[mid] && nums[mid] == nums[mid - 1])
                {
                    result = mid;
                    min = mid + 1;
                }
                else if (element < nums[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return result;
        }

        public static int MinimumEatingSpeed(int[] piles, int H) 
        {
            int start = 1;

            // Maximum speed of eating
            // is the maximum bananas in given piles
            int end = piles.Max();

            while (start < end)
            {
                int mid = start + (end - start) / 2;

                // Check if the mid(hours) is valid
                if ((Check(piles, mid, H)) == true)
                {

                    // If valid continue to search
                    // lower speed
                    end = mid;
                }
                else
                {
                    // If cant finish bananas in given
                    // hours, then increase the speed
                    start = mid + 1;
                }
            }
            return end;
        }

        /// <summary>
        /// Create a boolean function to check if the chosen speed (bananas/hour) is enough 
        /// to eat all bananas within given H hours time or not
        /// </summary>
        /// <param name="bananas"></param>
        /// <param name="midVal"></param>
        /// <param name="H"></param>
        /// <returns></returns>

        public static bool Check(int[] bananas, int midVal, int H) 
        {
            int time = 0;
            for (int i = 0; i < bananas.Length; i++)
            {

                // to get the ceil value
                if (bananas[i] % midVal != 0)
                {

                    // in case of odd number
                    time += ((bananas[i] / midVal) + 1);
                }
                else
                {

                    // in case of even number
                    time += (bananas[i] / midVal);
                }
            }

            // check if time is less than
            // or equals to given hour
            if (time <= H)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
