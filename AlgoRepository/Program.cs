using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AlgoRepository
{
    class Program
    {


        static void Main(string[] args)
        {


            // int[] sequence = Enumerable.Range(1, 11).ToArray();
            //Enumerable.Range(1, 10).Aggregate(0, (acc, x) => acc + x);
            //strings.Aggregate(0, (count, val) => count + 1);



            //  int[] sequence = Enumerable.Range(1, 11).ToArray();


            //  let hrs = piles.reduce((acc, currentPile) => {
            //     acc += currentPile % middleNumber == 0 ? currentPile / middleNumber : Math.floor(currentPile / middleNumber) + 1



            //var m = arr.Aggregate(0, (acc, x) => acc += x % 6 == 0 ? x / 6 : (x / 6) + 1);
            // var y = sequence.Select(x => x + 2);
            // IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z" };
            //var sum = strings.Select(x => x.Aggregate(0, (count, val) => count += val/2));

            //var z = TwoSumLessThan(new int[] { 34,23,1,24,75,33,54,8}, 60);

            //var isNumeric = double.TryParse("5", out double n);
            // var str = "10000 123 +";
            //var x = MaxSumArr(new int[] { 1,7,-2,-5,10,-1}, 6);

            var arr = new string[] { "3/6+2/12", "7/10+13/12" };
            var x = arr[1].Split("+");
            var m = x[1].Substring(x[1].IndexOf("/") + 1);

            var f = AddingFractions(arr);

            Console.WriteLine();
        }




        /// <summary>
        /// Adding fractions
        /// </summary>
        /// <param name="fractions"></param>
        /// <returns></returns>
        public static string[] AddingFractions(string[] fractions)
        {
            var arr = new List<string>();
            for(int i = 0; i < fractions.Length; i++) 
            {
                var x = SplitString(fractions[i]);
                var firstNumerator = x[0];
                var secondNumerator = x[2];
                var firstDem = x[1];
                var secondDem = x[3];
                var gcd = Gcd(firstDem, secondDem);
                var lcm = (firstDem * secondDem) / gcd;

                var addition = firstNumerator * (lcm / firstDem) + secondNumerator*(lcm / secondDem);
                var lowestForm = Lowest(lcm, addition);
                arr.Add(lowestForm);

            }
            return arr.ToArray();
        }

        public static List<int> SplitString(string str) 
        {
            var arr = str.Split("+");
            var list = new List<int>();
            foreach(var item in arr) 
            {
                var newArr = item.Split("/");
                foreach (var i in newArr)
                    list.Add(int.Parse(i));
            }

            return list;
        }

        public static string Lowest(int den3, int num3)
        {
            // Finding gcd of both terms
            int common_factor = Gcd(num3, den3);

            // Converting both terms into simpler
            // terms by dividing them by common factor
            den3 = den3 / common_factor;
            num3 = num3 / common_factor;
            return $"{num3}/{den3}";
        }

        public static int Gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return Gcd(b % a, a);
        }







        /// <summary>
        /// Calculate the sum of all numbers present in a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public static int FindSum(string str) 
        {
            string temp = "0";
            int sum = 0;

            for(int i = 0; i < str.Length; i++) 
            {
                if (char.IsDigit(str[i])) 
                {
                    temp += str[i];
                }

                else 
                {
                    sum += int.Parse(temp);
                    temp = "0";
                }
            }
            return sum + int.Parse(temp);
        }

        public static void DigitsNum(int n) 
        {
            if(n == 0)
                Console.WriteLine("0");

            if(n % 9 != 0)
                Console.Write(n % 9);

            for(int i = 1; i <= (n/9); i++) 
            {
                Console.Write("9");
            }

            for (int i = 1; i <= n; ++i)
                Console.Write("0");
            Console.WriteLine("");
        }




        public static int CountDivisibleSubSequence(string str, int n)
        {
            int len = str.Length;

            // division by n can leave only n remainder
            // [0..n-1]. dp[i][j] indicates number of
            // subsequences in string [0..i] which leaves
            // remainder j after division by n.
            int[,] dp = new int[len, n];

            // Filling value for first digit in str
            dp[0, (str[0] - '0') % n]++;

            for (int i = 1; i < len; i++)
            {
                // start a new subsequence with index i
                dp[i, (str[i] - '0') % n]++;

                for (int j = 0; j < n; j++)
                {
                    // exclude i'th character from all the
                    // current subsequences of string [0...i-1]
                    dp[i, j] += dp[i - 1, j];

                    // include i'th character in all the current
                    // subsequences of string [0...i-1]
                    dp[i, (j * 10 + (str[i] - '0')) % n] += dp[i - 1, j];
                }
            }

            return dp[len - 1, 0];
        }









        public static bool IsSubSequence(string str1, string str2) 
        {
            int str1Index = 0;
            int str2Index = 0;

            while(str1Index < str1.Length && str2Index < str2.Length) 
            {
                if(str1[str1Index] == str2[str2Index]) 
                {
                    str1Index++;
                }
                str2Index++;
            }
            return str1Index == str1.Length;

        }

        public static string LongestSubStringWithoutDuplication(string str) 
        {
            Dictionary<char, int> lastSeen = new Dictionary<char, int>();
            int[] longest = { 0, 1 };
            int startIdx = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (lastSeen.ContainsKey(c)) 
                {
                    startIdx = Math.Max(startIdx, lastSeen[c] + 1);
                }
                if(longest[1] - longest[0] < i + 1 - startIdx) 
                {
                    longest = new int[] { startIdx, i + 1 };
                }
                lastSeen[c] = i;
            }
            string result = str.Substring(longest[0], longest[1] - longest[0]);
            return result;
        }

       

        public static int[] ShortestChars(string s, char c) 
        {
            int[] outputArr = new int[s.Length];
            int c_position = -(s.Length);
            var n = s.Length;
            for(int i = 0; i < s.Length; i++) 
            {
                Console.WriteLine(s[i]);
                if(s[i] == c) 
                {
                    c_position = i;
                }
                outputArr[i] = i - c_position;
            }

            Console.WriteLine("second iteration");

            for (int i = n-1; i >= 0; i--) 
            {
                
                Console.WriteLine(s[i]);
                if (s[i] == c) 
                {
                    c_position = i;
                }
                outputArr[i] = Math.Min(outputArr[i], Math.Abs(i - c_position));
            }
            return outputArr;
        }

        public static string LongestSubstring(string str, int k) 
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach(var i in str) 
            {
                if (dict.ContainsKey(i)) 
                {
                    dict[i]++;
                }
                else 
                {
                    dict[i] = 1;
                }              
            }

            string result = "";
            foreach (var x in str)
            {
                if (k <= dict[x])
                {
                    result += x.ToString();
                }
            }

            return result;
        }

        public static int Round(int n)
        {
            // Smaller multiple
            int a = (n / 10) * 10;
           

            // Larger multiple
            int b = a + 10;
            

            // Return of closest of two
            return (n - a > b - n) ? b : a;
        }

        public static bool Checkduck(String num)
        {

            // Ignore leading 0s
            int i = 0, n = num.Length;
            while (i < n && num[i] == '0')
                i++;

            // Check remaining digits
            while (i < n)
            {
                if (num[i] == '0')
                    return true;
                i++;
            }

            return false;
        }

        public static string Initials(string str) 
        {
            var newStr = str.Split(" ");
            var y = "";
            foreach(var i in newStr) 
            {
                y += i[0].ToString().ToUpper() + " ";
            }

            return y.Trim();

        }

        public static int round(int n)
        {
            // Smaller multiple
            int a = (n / 10) * 10;
            Console.WriteLine(a);

            // Larger multiple
            int b = a + 10;
            Console.WriteLine(b);

            // Return of closest of two
            return (n - a > b - n) ? b : a;
        }

        public static bool IsNumber(string s) 
        {
            foreach(char i in s) 
            {
                if (!char.IsDigit(i))
                    return false;
            }
            return true;
        }


        public static string RearrangeCharacters(string str) 
        {
            if (str.Length == 2 || str.Distinct().Count() == 1)
                return "Not possible";
            
            var current = 0;
            var next = current + 1;
            var count = current + 1;
            while(count < str.Length) 
            {
                if(str[current] == str[next] && str[current] != str[count]) 
                {
                    var x = str[count].ToString();
                    str = str.Remove(count, 1);
                    str = str.Substring(0, next) + x + str.Substring(next);
                    current += 2;
                    next = current + 1;
                }
                
                count++;
            }
            return str;
        }

        public static string RemovePunctuations(string str) 
        {
            var newStr = "";
            foreach(char x in str) 
            {
                if(!char.IsPunctuation(x))
                {
                    newStr += x;
                }
            }

            return newStr;
        }
        
        public static string PangrammaticLipogram(string str) 
        {
            bool[] present = new bool[26];
            for(int i = 0; i < str.Length; i++) 
            {
                if(str[i] >= 'a' && str[i] <= 'z') 
                {
                    present[str[i] - 'a'] = true;
                }

                else if(str[i] >='A' && 'a' <= 'z') 
                {
                    present[str[i] - 'A'] = true;
                }
            }

            string res = "";

            for(int i = 0; i < 26; i++) 
            {
                if(present[i] == false) 
                {
                    res+= ((char)i + 'a').ToString();
                }
            }
            return res;
        }

        public static string MissingChars(string str)
        {
            //create a boolean to store the characters
            //present in the string
            bool[] present = new bool[26];
            //traverse the string and mark the characters present
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                   // Console.WriteLine(present[str[i] - 'a']);
                    present[str[i] - 'a'] = true;
                }
                else if (str[i] >= 'A' && str[i] <= 'Z')
                {
                  //  Console.WriteLine(present[str[i] - 'A'] = true);
                    present[str[i] - 'A'] = true;
                }
            }

            //store missing vals in alpha order
            string res = "";
            for (int i = 0; i < 26; i++)
            {
                if (present[i] == false)
                {
                    Console.WriteLine(i + 'a');
                    res += ((char)(i + 'a')).ToString();
                }
            }

            return res;
        }

        public static bool CheckPangram(string str)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var i in str)
            {
                if (char.IsLetter(i) && !set.Contains(i.ToString().ToLower()))
                    set.Add(i.ToString().ToLower());
            }

            return set.Count == 26;
        }

        public static string ReverseWordsInString(string str)
        {
            List<string> list = new List<string>();
            int startOfWord = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    list.Add(str.Substring(startOfWord, i - startOfWord));
                    startOfWord = i;
                }
                else if (startOfWord == ' ')
                {
                    list.Add(" ");
                    startOfWord = i;
                }
            }

            list.Add(str.Substring(startOfWord));
            list.Reverse();
            return String.Join(" ", list);
        }

        public static string FormNumber()
        {
            return $"EXP{DateTime.Now.ToString("yyyyMMdd")}0001";
        }

        public static void Solve(double meal_cost, int tip_percent, int tax_percent)
        {
            decimal meal = Convert.ToDecimal(meal_cost);
            decimal tip = Convert.ToDecimal(tip_percent) / 100 * meal;
            decimal tax = (Convert.ToDecimal(tax_percent) / 100) * meal;
            decimal total_cost = meal + tip + tax;
            Console.WriteLine(Convert.ToInt32(total_cost));

        }



        public static int MaxSumArr(int[] arr, int arrSize)
        {
            // Write your code here
            if (arrSize < 1)
                return -1;

            int currentSum = arr[0];
            int maxSum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (currentSum < 0)
                    currentSum = arr[i];
                else
                    currentSum += arr[i];

                if (maxSum < currentSum)
                    maxSum = currentSum;
            }

            return maxSum;
        }


        public static int[] MaxMin(int[] arr, int size)
        {
            // Write your code here
            int first = 0;
            int last = size - 1;
            int i = 0;
            var newArr = new int[size];
            while (first < last)
            {
                newArr[i] = arr[last];
                newArr[i + 1] = arr[first];
                i = i + 2;
                first++;
                last--;
            }

            newArr[size - 1] = arr[first];
            arr = newArr;
            return arr;

        }
        public static int EvaluateString(string exp)
        {
            if (exp.Length < 1)
            {
                return -1;
            }

            int result = 0;

            if (CheckNumber(exp[0]))
                result = int.Parse(exp[0].ToString());

            for (int i = 1; i < exp.Length; i += 2)
            {
                var isOperator = CheckOperator(exp[i]);
                var isNumber = CheckNumber(exp[i + 1]);
                if (isNumber && isOperator)
                {
                    var x = int.Parse(exp[i + 1].ToString());
                    result = CalculateString(char.ToString(exp[i]), result, x);
                }
            }

            return result;
        }

        static bool CheckNumber(char c)
        {
            return char.IsDigit(c);
        }

        static bool CheckOperator(char c)
        {
            string m = char.ToString(c);
            return (m == "*" || m == "+" || m == "-" || m == "/");

        }

        static int CalculateString(string symbol, int x, int y)
        {
            if (symbol == "*")
            {
                return x * y;
            }

            else if (symbol == "/")
            {
                return x / y;
            }

            else if (symbol == "+")
            {
                return x + y;
            }
            else
            {
                return x - y;
            }

        }


        public static double Evaluate(String expr)
        {
            if (expr.Length == 0)
            {
                return 0.0;
            }
            Stack<double> list = new Stack<double>();

            var arr = expr.Split(" ");

            foreach (var i in arr)
            {
                Console.WriteLine(i);
                if (double.TryParse(i, out double n))
                {
                    list.Push((double.Parse(i)));
                }

                else if (i.ToString() == "/" || i.ToString() == "*" || i.ToString() == "+" || i.ToString() == "-")
                {
                    var second = list.Pop();
                    var first = list.Pop();
                    var result = Calculator(i.ToString(), first, second);
                    list.Push(result);
                }
            }

            return list.Pop();
        }


        public static double Calculator(string symbol, double x, double y)
        {
            if (symbol == "*")
            {
                return x * y;
            }

            else if (symbol == "/")
            {
                return x / y;
            }

            else if (symbol == "+")
            {
                return x + y;
            }
            else
            {
                return x - y;
            }
        }

        public static string CamelCase(string str)
        {
            str = str.ToLower();
            foreach (var i in str)
            {
                if (!char.IsLetter(i))
                {
                    str.Split();
                }


            }

            return str;



        }


        public static int CalPoints(string[] ops)
        {
            var output = new List<int>();
            for (int i = 0; i < ops.Length; i++)
            {
                if (ops[i] == "C")
                {
                    output.Remove(output[output.Count - 1]);
                }
                else if (ops[i] == "D")
                {
                    output.Add(output[output.Count - 1] * 2);
                }
                else if (ops[i] == "+")
                    output.Add(output[output.Count - 1] + output[output.Count - 2]);
                else
                    output.Add(Convert.ToInt32(ops[i].ToString()));
            }
            return output.Sum();
        }

        public static int TwoSumLessThan(int[] arr, int k)
        {
            int c = 0;
            var list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    c = arr[i] + arr[j];
                    if (c <= k)
                    {
                        list.Add(c);
                    }
                }
            }
            list.Sort();
            return list[list.Count - 1];
        }












        public bool IsValid(string exp)
        {
            Stack<char> stack = new Stack<char>();

            if (exp.Length % 2 != 0)
                return false;
            foreach (var item in exp)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);

                }

                else if ((item == ')' && stack.Count != 0 && stack.Peek() == '(') || (item == '}' && stack.Count != 0 && stack.Peek() == '{') || (item == ']' && stack.Count != 0 && stack.Peek() == '['))
                {
                    stack.Pop();

                }
                else
                    return false;
            }

            return stack.Count == 0;
        }

        public static int[] SplitInteger(int x, int n)
        {
            var arr = new int[n];
            if (x < n)
                return arr;
            else if (x % n == 0)
            {
                for (int i = 0; i < n; i++)
                    arr[i] = (x / n);
                //Console.Write((x / n) + " ");
            }
            else
            {
                int diff = n - (x % n);
                int whole = x / n;
                for (int i = 0; i < n; i++)
                {
                    if (i >= diff)
                    {
                        arr[i] = (whole + 1);
                        //Console.Write((pp + 1) + " ");
                    }
                    else
                    {
                        arr[i] = whole;
                        //  Console.Write(pp + " ");
                    }
                }
            }
            return arr;

        }

        public static List<decimal> SplitIntegers(int num, int parts)
        {
            var result = new List<decimal>();
            decimal divisor = Math.Floor((decimal)num / parts);
            var rest = num % parts;

            for (int i = 0; i < parts - rest; i++)
            {
                result.Add(divisor);
            }

            for (var i = 0; i < rest; i++)
            {
                result.Add(divisor + 1);
            }

            return result;
        }




        //public static string[] dirReduc(String[] arr)
        //{
        //    var resultList = new List<string>();
        //    foreach (var item in arr)
        //    {
        //        if (resultList.Count != 0)
        //        {
        //            var last = resultList.Last();
        //            bool a = last == "NORTH" && item == "SOUTH";
        //            bool b = last == "SOUTH" && item == "NORTH";
        //            bool c = last == "EAST" && item == "WEST";
        //            bool d = last == "WEST" && item == "EAST";
        //            if (a || b || c || d)
        //            {
        //                resultList.RemoveAt(resultList.Count - 1);
        //            }
        //            else
        //            {
        //                resultList.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            resultList.Add(item);
        //        }
        //    }
        //    return resultList.ToArray();
        //}



        public static string[] dirReduc(String[] arr)
        {
            var destination = new List<string>();
            var dict = new Dictionary<string, string>(){
                {"NORTH", "SOUTH"},
                {"SOUTH", "NORTH"},
                {"EAST", "WEST"},
                {"WEST", "EAST"}
            };
            foreach (var item in arr)
            {

                if (destination.Count > 0)
                {
                    var last = destination.Last();
                    var a = last == "NORTH" && item == dict["NORTH"];
                    var b = last == "SOUTH" && item == dict["SOUTH"];
                    var c = last == "EAST" && item == dict["EAST"];
                    var d = last == "WEST" && item == dict["WEST"];

                    if (a || b || c || d)
                    {
                        destination.RemoveAt(destination.Count - 1);
                    }
                    else
                    {
                        destination.Add(item);
                    }
                }
                else
                {
                    destination.Add(item);
                }
            }




            return destination.ToArray();
        }

        public static int[] SearchInSortedMatrix(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == target)
                    {
                        return new int[] { i, j };
                    }
                }

            }
            return new int[] { -1, -1 };
        }

        public static int ThreeSumSmaller(int[] nums, int target)
        {
            if (nums.Length == 0)
                return 0;

            Array.Sort(nums);
            int result = 0;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int firstPointer = i + 1;
                int secondPointer = nums.Length - 1;

                while (firstPointer < secondPointer)
                {

                    int currentSum = nums[i] + nums[firstPointer] + nums[secondPointer];
                    if (currentSum < target)
                    {
                        result += (secondPointer) - (firstPointer);
                        firstPointer++;

                    }
                    else
                        secondPointer--;

                }
            }
            return result;
        }



        public static int SumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int firstPointer = i + 1;
                int secondPointer = nums.Length - 1;
                while (firstPointer < secondPointer)
                {
                    int currentSum = nums[i] + nums[firstPointer] + nums[secondPointer];
                    if (currentSum > target)
                    {
                        secondPointer -= 1;
                    }
                    else
                    {
                        firstPointer += 1;
                    }

                    if (Math.Abs(currentSum - target) < Math.Abs(result - target))
                        result = currentSum;
                }
            }

            return result;
        }



        public static int ThreeSumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int firstPointer = i + 1;
                int secondPointer = nums.Length - 1;

                while (firstPointer < secondPointer)
                {
                    int currentSum = nums[i] + nums[firstPointer] + nums[secondPointer];
                    if (currentSum > target)
                    {
                        secondPointer -= 1;
                    }
                    else
                    {
                        firstPointer += 1;
                    }

                    if (Math.Abs(currentSum - target) < Math.Abs(result - target))
                    {
                        result = currentSum;
                    }
                }
            }

            return result;
        }



        public static List<int> SunsetViews2(int[] buildings, string direction)
        {
            List<int> result = new List<int>();
            direction = direction.ToUpper();
            int minLenghtToSeeSun = 0;
            switch (direction)
            {
                case "EAST":
                    for (int i = buildings.Length - 1; i >= 0; i--)
                    {
                        if (buildings[i] > minLenghtToSeeSun)
                        {
                            result.Add(i);
                            minLenghtToSeeSun = buildings[i];
                        }
                    }
                    break;
                case "WEST":
                    for (int i = 0; i < buildings.Length; i++)
                    {
                        if (buildings[i] > minLenghtToSeeSun)
                        {
                            result.Add(i);
                            minLenghtToSeeSun = buildings[i];
                        }
                    }
                    break;
                default:
                    break;
            }
            return result.OrderBy(x => x).ToList();
        }


        public static List<int> SunsetViews(int[] buildings, string direction)
        {
            // Write your code here.
            //3, 5, 4, 4, 3, 1, 3, 2
            var max = -1;
            var result = new List<int>();
            if (direction == "EAST")
            {
                for (int i = buildings.Length - 1; i >= 0; i--)
                {
                    if (buildings[i] > max)
                    {
                        result.Add(i);
                        max = buildings[i];
                    }
                }
                result.Sort();
            }
            else if (direction == "WEST")
            {
                for (int i = 0; i < buildings.Length; i++)
                {
                    if (buildings[i] > max)
                    {
                        result.Add(i);
                        max = buildings[i];
                    }
                }
            }
            return result;
        }


        public static int LaptopRentals(int[][] times)
        {
            if (times[0].Length == 0)
            {
                return 0;
            }
            /* 
             var startTimes = new int[times.Length];
             var endTimes = new int[times.Length];

           //  var startTimes = times.Select(x => x[0]).OrderBy(y=>y).ToArray();
           //  var endTimes = times.Select(x => x[1]).OrderBy(y => y).ToArray();

             for(int i = 0; i < times.Length; i++)
             {
               startTimes[i] = times[i][0];
               endTimes[i] = times[i][1];
             }
             Array.Sort(startTimes);
             Array.Sort(endTimes);
             */
            int[] startTimes = times.Select(time => time[0]).OrderBy(x => x).ToArray();
            int[] endTimes = times.Select(time => time[1]).OrderBy(x => x).ToArray();
            int startIndex = 0;
            int endIndex = 0;
            int laptops = 0;

            while (startIndex < startTimes.Length)
            {
                if (endTimes[endIndex] > startTimes[startIndex])
                {
                    startIndex++;
                    laptops++;
                }

                else if (endTimes[endIndex] <= startTimes[startIndex])
                {
                    startIndex++;
                    endIndex++;
                }
            }
            return laptops;
        }



        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> list = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int low = i + 1;
                    int high = nums.Length - 1;
                    int sum = 0 - nums[i];

                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            list.Add(new List<int>() { nums[i], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1]) low++;
                            while (low < high && nums[high] == nums[high - 1]) high--;
                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] > sum)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }
            }

            return list;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int i = 0;
            foreach (var item in nums)
            {
                int complement = target - item;

                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }
                else
                {
                    dict[item] = i;
                    i++;
                }
            }

            return new int[] { 0, 0 };
        }


        public static void AddStrings(string a, string b)
        {
            var x = new System.Data.DataTable().Compute(a + "+" + b, "");
            Console.WriteLine(x);

        }


        public class MinMaxStack
        {
            List<Dictionary<string, int>> minMaxStack = new List<Dictionary<string, int>>();
            List<int> stack = new List<int>();
            public int Peek()
            {

                // Write your code
                return stack[stack.Count - 1];

            }

            public int Pop()
            {
                minMaxStack.RemoveAt(minMaxStack.Count - 1);
                var val = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return val;
            }


            public void Push(int number)
            {
                // Write your code here.
                Dictionary<string, int> newMinMax = new Dictionary<string, int>();
                newMinMax.Add("min", number);
                newMinMax.Add("max", number);
                if (minMaxStack.Count > 0)
                {
                    Dictionary<string, int> lastMinMax = new Dictionary<string, int>(
                        minMaxStack[minMaxStack.Count - 1]
                        );
                    newMinMax["min"] = Math.Min(lastMinMax["min"], number);
                    newMinMax["max"] = Math.Max(lastMinMax["max"], number);
                }
                minMaxStack.Add(newMinMax);
                stack.Add(number);
            }


            public int GetMin()
            {
                // Write your code here.
                return minMaxStack[minMaxStack.Count - 1]["min"];
            }


            public int GetMax()
            {
                // Write your code here.
                return minMaxStack[minMaxStack.Count - 1]["max"];
            }
        }



        public static string CaesarCypherEncryptor(string str, int key)
        {

            var arr = "abcdefghijklmnopqrstuvwxyz";

            var lastAlpha = str[str.Length - 1];
            var result = lastAlpha.ToString();
            var positionOfLastAlpha = arr.IndexOf(lastAlpha) == arr.Length - 1 ? 0 : arr.IndexOf(lastAlpha) + 1;


            var actualKey = positionOfLastAlpha + key;

            for (int i = positionOfLastAlpha; i < actualKey; i++)
            {
                result += arr[i];
            }

            return result;
        }


        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            // Write your code here.
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            int a = 0;
            int b = 0;
            int smallest = Int32.MaxValue;
            int current = Int32.MaxValue;
            int[] smallestPair = new int[2];
            while (a < arrayOne.Length && b < arrayTwo.Length)
            {
                int firstNum = arrayOne[a];
                int secondNum = arrayTwo[b];

                if (firstNum < secondNum)
                {
                    current = secondNum - firstNum;
                    a++;
                }
                else if (secondNum < firstNum)
                {
                    current = firstNum - secondNum;
                    b++;
                }
                else
                {
                    return new int[] { firstNum, secondNum };
                }
                if (smallest > current)
                {
                    smallest = current;
                    smallestPair = new int[] { firstNum, secondNum };
                }
            }
            return smallestPair;

        }


        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            var match = new List<int[]>();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;
                while (left < right)
                {
                    int currentValue = array[i] + array[left] + array[right];
                    if (currentValue == targetSum)
                    {
                        int[] newMatch = { array[i], array[left], array[right] };
                        match.Add(newMatch);
                        left++;
                        right--;
                    }
                    else if (currentValue > targetSum)
                    {
                        right--;
                    }
                    else if (currentValue < targetSum)
                    {
                        left++;
                    }
                }

            }
            return match;
        }


        public static int MinEatingSpeed(int[] piles, int h)
        {
            //minimum eating speed must be 1
            int start = 1;

            //Max eating speed is the maximum
            //bananas in given piles
            int end = piles.Max();

            while (start < end)
            {
                int mid = start + (end - start) / 2;

                //check if the mid(hours) is valid
                if ((Check(piles, mid, h)) == true)
                {
                    //if valid continue to seacrh
                    //lower speed
                    end = mid;
                }
                else
                {
                    //if invalid, increase the speed
                    start = mid + 1;
                }

            }

            return end;
        }


        public static bool Check(int[] bananas, int mid_val, int h)
        {
            int time = 0;
            for (int i = 0; i < bananas.Length; i++)
            {
                //get the ceil value
                if (bananas[i] % mid_val != 0)
                {
                    //in the case of an odd number
                    time += ((bananas[i] / mid_val) + 1);
                }
                else
                {
                    //in the case of an even number
                    time += (bananas[i] / mid_val);
                }
            }

            //check if the time is less than or equal to the given hour
            if (time <= h)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static int MinEatingSpeeds(int[] piles, int h)
        {
            int[] arr = Enumerable.Range(1, piles.Max()).ToArray();
            int min = 0;
            int max = arr.Length - 1;
            var hoursList = new List<int>();

            //apply binary search
            while (min <= max)
            {
                int mid = (min + max) / 2;
                var currentValue = arr[mid];
                int potentialHours = 0;

                foreach (var p in piles)
                {
                    potentialHours += (int)(Math.Ceiling((double)p / currentValue));
                }


                if (potentialHours > h)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                    hoursList.Add(currentValue);
                }
            }
            return hoursList.Min();
        }





        public static int LastIndexOccuranceRange(List<int> nums, int element)
        {

            int lower = 0;
            int upper = nums.Count - 1;
            int result = -1;

            while (lower <= upper)
            {
                int mid = ((lower + upper) / 2);

                if (element == nums[mid] && nums[mid] != nums[mid - 1])
                {
                    result = mid;
                    return result;
                }

                else if ((element == nums[mid] && nums[mid] == nums[mid - 1]))
                {
                    result = mid;
                    lower = mid + 1;
                }



                // if key is less than the mid element, discard right half
                else if (element < nums[mid])
                {
                    upper = mid - 1;
                }

                // if key is more than the mid element, discard left half
                else
                {
                    lower = mid + 1;
                }
            }
            return result;
        }









        public static int ShiftedBinarySearch(int[] array, int target)
        {
            var list = array.ToList();
            list.Sort();
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int mid = (max + min) / 2;

                if (list[mid] == target)
                {
                    return Array.IndexOf(array, list[mid]);
                }

                else if (list[mid] > target)
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



        public static int[] SortedMatrix(int[,] arr, int element)
        {
            int length = arr.GetLength(0);
            int min = 0;
            int max = arr.GetLength(1) - 1;

            while (min < length && max >= 0)
            {
                if (arr[min, max] > element)
                {
                    max--;
                }
                else if (arr[min, max] < element)
                {
                    min++;
                }
                else
                {
                    return new int[] { min, max };
                }
            }

            return new int[] { -1, -1 };
        }




        public static int[] SearchSortedMatrix(int[,] matrix, int target)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[row, col] > target)
                {
                    col--;
                }
                else if (matrix[row, col] < target)
                {
                    row++;
                }
                else
                {
                    return new int[] { row, col };
                }
            }



            return new int[] { -1, -1 };
        }


        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {
            // Write your code here.
            var rowCount = matrix.GetLength(0);
            var length = matrix.GetLength(1);
            for (int i = 0; i < rowCount; i++)
            {
                int min = 0;
                int max = length - 1;

                while (min <= max)
                {
                    int mid = (max + min) / 2;
                    if (matrix[i, mid] == target)
                    {
                        return new int[] { i, mid };
                    }

                    else if (target > matrix[i, mid])
                    {
                        min = mid + 1;
                    }

                    else
                    {
                        max = mid - 1;
                    }
                }
            }
            return new int[] { -1, -1 };
        }








        public static int[] FindThreeLargestNumbers(int[] array)
        {
            var nums = new int[3];
            var list = array.ToList();
            int position = nums.Length - 1;

            for (int i = 0; i < 3; i++)
            {
                var max = list.Max();
                nums[position] = max;
                var remove = list.IndexOf(max);
                list.RemoveAt(remove);
                position--;
            }

            return nums;
        }




        public static int LastIndexOccurance(List<int> nums, int element)
        {

            int lower = 0;
            int upper = nums.Count - 1;
            int result = -1;

            while (lower <= upper)
            {
                int mid = ((lower + upper) / 2);

                if ((element == nums[mid] && nums[mid] == nums[mid - 1]))
                {
                    result = mid;
                    lower = mid + 1;
                }



                // if key is less than the mid element, discard right half
                else if (element < nums[mid])
                {
                    upper = mid - 1;
                }

                // if key is more than the mid element, discard left half
                else
                {
                    lower = mid + 1;
                }
            }
            return result;
        }

        public static int MyFirstOccurrence(List<int> arr, int n)
        {
            int lower = 0;
            int upper = arr.Count - 1;
            int result = -1;

            while (lower <= upper)
            {
                int mid = (lower + upper) / 2;

                if (arr[mid] == n)
                {
                    result = mid;
                    upper = mid - 1;
                }
                else if (n < arr[mid])
                {
                    upper = mid - 1;
                }
                else
                {
                    lower = mid + 1;
                }
            }
            return result;
        }


        public static int MyBinary(List<int> arr, int n)
        {
            int big = arr.Count - 1;
            int small = 0;
            int mid = 0;
            arr.Sort();
            while (small <= big)
            {
                mid = (small + big) / 2;
                if (arr[mid] == n)
                {
                    return mid;
                }

                else if (n > arr[mid])
                {
                    small = mid + 1;
                }

                else if (n < arr[mid])
                {
                    big = mid - 1;
                }
            }

            return -1;
        }




        public static int Diagonal(List<List<int>> arr)
        {
            int a = 0;
            int b = 0;
            int length = arr[0].Count;

            for (int i = 0; i < length; i++)
            {
                a += arr[i][i];
                b += arr[i][length - i - 1];

            }

            return Math.Abs(a - b);
        }




        public static int DiagonalDifference(List<List<int>> arr)
        {

            var n = arr[0].Count;
            int a = 0;
            int b = 0;
            int count = n;
            for (int i = 0; i < n; i++)
            {
                a += (arr[i][i]);
                b += (arr[i][count - 1]);
                count--;
            }

            return Math.Abs(a - b);

        }

        public static int slotWheels(List<string> history)
        {
            var t = new List<int>();
            var maxVals = new List<int>();
            int finalMax = 0;
            //foreach(var z in history) 
            //{
            //    newHistory.Add(Convert.ToInt32(z));
            //}

            var counter = history[0].Length;
            //var j = 0;

            while (counter > 0)
            {
                for (int i = 0; i < history.Count; i++)
                {
                    for (int j = i; j < history[i].Length; j++)
                    {
                        t.Add((int.Parse((history[i][j]).ToString())));

                    }
                    maxVals.Add(t.Max());
                    t.Clear();
                }
                finalMax += maxVals.Max();

            }
            return default;
        }





        public static int numPlayers(int k, List<int> scores)
        {
            var rank = new List<int>();

            var scoresArray = scores.ToArray();
            Array.Sort(scoresArray);
            Array.Reverse(scoresArray);
            int ranks = 1;
            rank.Add(ranks);

            for (int i = 1; i < scoresArray.Length; i++)
            {
                if (scoresArray[i] == scoresArray[i - 1])
                {
                    rank.Add(ranks);
                }

                else
                {
                    ranks = rank.Count + 1;
                    rank.Add(ranks);
                }

            }

            int qualified = 0;
            foreach (var i in rank)
            {
                if (i <= k)
                {
                    qualified += 1;
                }
            }

            return qualified;
        }

        public static int FirstIndexOf(int[] arr, int k)
        {
            int minNum = 0;
            int maxNum = arr.Length - 1;
            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (k == 0 && arr[0] == k)
                {
                    return 0;
                }
                else if (k == arr[mid])
                {
                    if (k != arr[mid - 1])
                        return -1;
                    while (k == arr[mid - 1])
                    {
                        --mid;
                    }
                    return mid;
                }
                else if (k < arr[mid])
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return -1;
        }






        private static int BiSearch(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key > inputArray[mid])
                {
                    max = mid - 1;
                }

            }
            return default;
        }


        public static int MinimumSwaps(List<int> ratings)
        {
            var ratingsArray = ratings.ToArray();
            int count = 0;
            int i = 0;
            // int j = 1;
            int current = 0;
            int maxRest = 0;
            int length = 0;

            while (length < ratingsArray.Length)
            {
                current = ratingsArray[i];
                maxRest = 0;
                //maxRest = ratings[i + 1];
                for (int j = i + 1; j < ratingsArray.Length; j++)
                {
                    if (ratingsArray[j] > maxRest)
                    {
                        maxRest = ratingsArray[j];

                    }

                }
                Console.WriteLine(maxRest);
                i++;
                if (current < maxRest)
                {
                    int currIndex = Array.IndexOf(ratingsArray, current);
                    int maxIndex = Array.IndexOf(ratingsArray, maxRest);
                    ratingsArray[currIndex] = maxRest;
                    ratingsArray[maxIndex] = current;
                    count += 1;

                }
                length++;

            }
            return count;

        }







        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            var indices = new List<int>();
            int j = 0;
            if (array.Contains(sequence[0]))
            {
                j = array.IndexOf(sequence[0]);
            }
            else
            {
                return false;
            }
            for (int i = 1; i < sequence.Count; i++)
            {
                if (array.Contains(sequence[i]))
                {
                    if (j < array.IndexOf(sequence[i]))
                    {
                        j = array.IndexOf(sequence[i]);
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }



            return true;
        }



        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int i = 0;
            int j = array.Length - 1;
            while (i < j)
            {
                int currentSum = array[i] + array[j];
                if (currentSum == targetSum)
                {
                    return new int[] { array[i], array[j] };
                }
                else if (currentSum < targetSum)
                {
                    i++;
                }
                else if (currentSum > targetSum)
                {
                    j--;
                }
            }


            return new int[0];
        }




        static void Greatest(string x)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            //string word = "Apple";
            x = x.ToLower();
            foreach (var item in x)
            {


                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }
            }
            /* foreach (var item in dict) 
             {
                 Console.WriteLine(item);
             }
            */
            int temp = 0;
            char alpha = 'A';
            foreach (var item in dict.Keys)
            {
                if (temp <= dict[item])
                {
                    temp = dict[item];
                    alpha = item;
                }
            }

            Console.WriteLine($"{alpha}, {temp}");
        }


        public static string[] DirReduc()
        {
            var dict = new Dictionary<string, int>
            {
                { "NORTH", 1 },
                 { "SOUTH", 1 },
                  { "EAST", 2 },
                   { "WEST", 2 }
            };

            String[] plan = { "NORTH", "EAST", "SOUTH", "WEST", "SOUTH" };
            var listPlan = new List<string> { "NORTH", "EAST", "SOUTH", "WEST", "SOUTH" };

            var p = 0;
            var m = 1;
            var length = listPlan[m];

            while (m < listPlan.Count && listPlan.Count != 0)
            {
                var first = listPlan[m];
                var second = listPlan[p];
                if (dict[listPlan[m]] == dict[listPlan[p]])
                {
                    listPlan.Remove(first);

                    listPlan.Remove(second);
                    p = 0;

                    m = 1;
                }
                else
                {

                    m++;
                    p++;

                }

            }


            return listPlan.ToArray();

        }


        public static string Add(string a, string b)
        {
            BigInteger int1 = BigInteger.Parse(a);

            BigInteger int2 = BigInteger.Parse(b);
            return (int1 + int2).ToString();
        }




        public static string GetReadableTime(int seconds)
        {
            if (seconds < 10)
            {
                return $"00:00:0{seconds}";
            }

            string hours = (seconds / 3600).ToString();
            string mins = ((seconds % 3600) / 60).ToString();
            string sec = (seconds % 60).ToString();

            if (int.Parse(hours) == 0 || hours.Length == 1)
            {
                hours = "0" + hours;
            }

            if (int.Parse(mins) == 0 || mins.Length == 1)
            {
                mins = "0" + mins;
            }

            if (int.Parse(sec) == 0 || sec.Length == 1)
            {
                sec = "0" + sec;
            }

            return $"{hours}:{mins}:{sec}";
        }
        public static int CountBits(int n)
        {
            var x = Convert.ToString(n, 2);
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i].ToString() == "1")
                    count += 1;
            }
            return count;
        }
        public static int MagicNumber(int x)
        {
            string z = x.ToString();
            int sum = 0;
            while (z.Length != 1)
            {

                for (int i = 0; i < z.Length; i++)
                {
                    sum += int.Parse((z[i]).ToString());
                }
                z = sum.ToString();
                sum = 0;
            }

            return int.Parse(z);
        }

        public static int SmallestElement(int[] arr)
        {
            List<int> list = arr.ToList();
            int count = 0;
            int max = 0;

            while (count != 2)
            {
                max = list.Max();
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (list[i] < max)
                    {
                        max = list[i];
                        count += 1;
                    }

                }
                list.Remove(max);
            }
            return max;
        }

        public static int CountValues(int[] arr, int[] arr2)
        {
            HashSet<int> sets = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            foreach (var item in arr)
            {
                sets.Add(item);
            }

            foreach (var item in arr2)
            {
                set2.Add(item);
            }

            sets.IntersectWith(set2);


            return sets.Count();


        }

        public static string Print(int n)
        {
            if (n % 2 == 0 || n < 0)
            {
                return null;
            }

            int middle = n / 2;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < n; index++)
            {
                sb.Append(' ', Math.Abs(middle - index));
                sb.Append('*', n - Math.Abs(middle - index) * 2);
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public static int[] Arrays(int[] arr)
        {
            Console.WriteLine("Starting");
            List<int> x = new List<int>();
            int z = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                string y = arr[i].ToString();
                for (int j = 0; j < y.Length; j++)
                {
                    // z += ((char)Convert.ToInt32(y[i])).ToString();
                }
                Console.WriteLine(z);
                x.Add(z);
                z = 0;
            }
            return x.ToArray();

        }
        public static string ReverseFactorial(int num)
        {
            long fact = 1;
            for (var i = 1; i < 100; i++)
            {
                if ((fact *= i) == num)
                    return $"{i}!";
            }

            return "None";

        }

        //public static bool HasUniqueChars(string str)
        //{
        //    //str = str.ToLower();
        //    Console.WriteLine(str);
        //    int temp = 0;
        //    int count = 0;
        //    int strLength = str.Length;

        //    while (temp < (str.Length - 1)) {
        //        for (int i = temp + 1; i < str.Length; i++)
        //        {
        //            if (str[temp] == str[i]) 
        //            {
        //                count += 1;
        //            }
        //            temp++;
        //    }
        //    }

        //    if (count > 0)
        //        return false;


        //    return true;
        //}

        public static double[] Tribonacci(double[] signature, int n)
        {
            //signature = new double[n];
            double[] newArr = new double[n + 1];

            int x = 0;
            int y = 1;
            int z = 2;

            for (int i = 0; i < signature.Length; i++)
            {
                newArr[i] = signature[i];
            }

            while (z < n)
            {
                for (int i = z + 1; i <= n; i++)
                {
                    // Console.WriteLine($"{newArr[x]}, {newArr[y]}, {newArr[z]}");
                    newArr[i] = newArr[x] + newArr[y] + newArr[z];
                    x++;
                    y++;
                    z++;
                }
            }

            return newArr;
        }

        public static bool HasUniqueChars(string str)
        {
            var dict = new Dictionary<char, int>();
            foreach (var item in str)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }

                foreach (var i in dict.Values)
                {
                    if (i > 1)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        //static int Reverse(int x)
        //{
        //    Char[] arr = new char[3];
        //    string num = x.ToString();
        //    arr = num.ToCharArray();
        //    Array.Sort(arr);
        //    string finalValue = "";
        //    for (int i = arr.Length - 1; i >= 0; i--)
        //    {
        //        finalValue += arr[i];
        //    }

        //    int finalNumber = Convert.ToInt32(finalValue);


        //    return finalNumber;
        //}

        //SECOND ALGORITHM

        static void Reverse(int x)
        {
            string num = x.ToString();
            ArrayList arr = new ArrayList();

            for (int i = 0; i < num.Length; i++)
            {
                arr.Add(num[i]);
            }

            //arr.Sort();

            for (int i = 0; i < arr.Count; i++)
            {
                // Console.WriteLine(arr[i]*arr[i]);
            }
        }





        static void PopulateArray(int arrLength)
        {
            int sum = 0;
            arrLength = 10;
            int[] arr = new int[arrLength];

            for (int i = 0; i <= arrLength - 1; i++)
            {
                Console.WriteLine($"Enter the number at index {i}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
            }

            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            for (var i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine($"The sum of the array is {sum}");
        }

        static void DuplicateArrayValues()
        {
            int[] arr = new int[] { 1, 2, 3, 3, 4, 4, 5, 6, 6, 7, 7 };
            int count = 0;
            int start = 0;
            for (int i = start + 1; i < arr.Length; i++)
            {
                if (arr[start] == arr[i])
                {
                    count += 1;
                }
                start++;
            }

            Console.WriteLine(count);
        }

        public static string GreatestString(string x)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            //string word = "Apple";
            x = x.ToLower();

            foreach (var item in x)
            {
                if (!char.IsWhiteSpace(item))
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item]++;
                    }
                    else
                    {
                        dict[item] = 1;
                    }
                }


            }

            int temp = 0;
            char alpha = 'A';
            foreach (var item in dict.Keys)
            {
                if (temp <= dict[item])
                {
                    temp = dict[item];
                    alpha = item;
                }
            }

            return $"{alpha}, {temp}";
        }

        public static int[] Chips(int x)
        {
            List<int> list = new List<int>();
            int num = x;
            while (num > 0)
            {
                if (num % 100 == 0)
                {
                    //num = x / 100;
                    list.Add(100);
                    num = num - 100;
                    continue;
                }

                if (num % 50 == 0)
                {
                    num = num - 50;
                    list.Add(50);
                    continue;
                }

                if (num % 25 == 0)
                {
                    num = num - 25;
                    list.Add(25);
                    continue;
                }

                if (num % 10 == 0)
                {
                    num = num - 10;
                    list.Add(10);
                    continue;
                }
                if (num % 5 == 0)
                {
                    num = num - 5;
                    list.Add(5);
                    continue;
                }
                {
                    list.Add(1);
                    num = num - 1;
                }

            }
            var newArr = new List<int>();

            int max = list[0];
            int count = list.Count;

            while (count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (max < list[i])
                    {
                        max = list[i];
                    }
                }
                count--;
                newArr.Add(max);
                list.Remove(max);
                max = 0;



            }

            return newArr.ToArray();



        }

        public static List<int> MultiplyValues(List<int> values)
        {
            List<int> finalValues = new List<int>();

            for (int i = 0; i < values.Count; i++)

            {
                int product = 1;
                for (int j = 0; j < values.Count; j++)
                {

                    if (i == j)
                    {
                        continue;
                    }
                    product *= values[j];

                }
                finalValues.Add(product);
            }

            return finalValues;
        }

        public static List<int> GetNumChips(int value)
        {
            List<int> chips = new List<int> { 100, 50, 25, 10, 5, 1 };
            List<int> numChips = new List<int>();
            if (value <= 0)
            {
                return numChips;
            }

            foreach (int chip in chips)
            {
                int num = Convert.ToInt32(value / chip);
                value -= chip * num;
                if (num <= 0)
                {
                    continue;
                }
                for (int i = 0; i < num; i++)
                {
                    numChips.Add(chip);
                }
            }
            return numChips;
        }

        public static string DuplicateCharacters(string x)
        {
            int temp = 0;
            string z = "";
            for (int i = temp + 1; i <= x.Length - 1; i++)
            {
                if (x[temp] == x[i])
                {
                    z += x[temp];
                }
                temp++;
            }
            return z;
        }

        public static void Log(int num)
        {
            if (num > 5)
            {
                return;
            }
            Console.WriteLine(num);
            Log(num + 1);
        }

        public static string Numbs(int num)
        {
            if (num <= 0)
            {
                return "The end";
            }
            else
            {
                Console.WriteLine(num);

            }
            return Numbs(num - 1);
        }

        public static int FindIndex(string x, string y)
        {
            if (x.Length != y.Length)
                return -1;
            return (x + x).IndexOf(y);
        }

        public static string Encrypt(string text, int n)
        {
            if (n <= 0 || text == null)
            {
                return text;
            }
            string result = "";

            for (int i = 1; i < text.Length; i += 2)
            {
                result += text[i];
            }
            for (int i = 0; i <= text.Length; i += 2)
            {
                result += text[i];

            }

            return Encrypt(result, n - 1);
        }

        public static string Decrypt(string text, int n)
        {
            if (n <= 0 || text == null)
                return text;

            int shift = text.Length / 2;
            string result = "";

            for (int i = 0; i < shift; i++)
                result += text[i + shift].ToString() + text[i];

            if (text.Length % 2 == 1)
                result += text[text.Length - 1];

            return Decrypt(result, n - 1);

        }

        public static int[] SortArray(int[] x)
        {

            List<int> even = new List<int>();
            List<int> odd = new List<int>();
            List<int> nums = new List<int>();
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                    even.Add(x[i]);
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 != 0)
                    odd.Add(x[i]);
            }
            odd.Sort();
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    nums.Add(even[0]);
                    even.RemoveAt(0);
                }
                else
                {
                    nums.Add(odd[0]);
                    odd.RemoveAt(0);
                }

            }
            return nums.ToArray();




        }

        public static string SortString(string x)
        {
            string y = "";
            string[] arr = x.Split(" ");
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].Contains(i.ToString()))
                    {
                        y += $"{arr[j]} ";
                    }
                }
            }

            return y;
        }

        public static int ArrayPacking(List<int> integers)
        {
            string r = "";
            for (int i = integers.Count - 1; i >= 0; i--)
            {
                string t = "000000000" + Convert.ToString(integers[i], 2);

                r += t.Substring(t.Length - 8);

            }
            return Convert.ToInt32(r, 2);
        }

        //String.Concat(Enumerable.Repeat("Hello", 4));

        public static string MultiplyString(int x)
        {
            int length = (x.ToString()).Length;
            string numString = "";
            if (length < 5)
            {
                string z = String.Concat(Enumerable.Repeat("0", (5 - length)));
                numString = z + x.ToString();
            }

            return numString;
        }

        public static int[] PartsSums(int[] ls)
        {
            int sum = 0;
            List<int> nums = new List<int>();
            for (int i = 0; i < ls.Length; i++)
            {
                for (int j = i; j < ls.Length; j++)
                {
                    sum += ls[j];
                }
                nums.Add(sum);
                sum = 0;
            }
            nums.Add(0);
            return nums.ToArray();
        }

        public static int[] PartsSum(int[] ls)
        {
            int sum = ls.Sum();
            List<int> nums = new List<int>();
            int x = 0;
            nums.Add(sum);
            for (int i = 0; i < ls.Length; i++)
            {
                x = sum - ls[i];
                Console.WriteLine(x);
                nums.Add(x);
                sum = x;
            }

            return nums.ToArray();
        }

        public static string PigIt(string str)
        {
            /*
             *Description:
             *Move the first letter of each word to the end of it, then add "ay" 
             *to the end of the word. Leave punctuation marks untouched.
             *Examples: Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
             *Kata.PigIt("Hello world !");     // elloHay orldway !
             */
            string[] arr = str.Split(" ");
            string x = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                string m = arr[i];
                int length = m.Length;
                if (length > 1)
                {
                    string z = m.Substring(1, (length - 1)) + m[0] + "ay";
                    x += z + " ";
                }
                else
                {
                    x += arr[i];
                }

            }
            str = x.Trim();
            return str;
        }


    }
}
