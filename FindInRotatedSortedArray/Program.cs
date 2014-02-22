using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a sorted array of n integers that has been rotated an unknown number of times, 
// write code to find an element in the array. You may assume that the array was
// originally sorted in the increasing order. The array may contain repeated numbers
namespace FindInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testcase1 = { 4, 5, 6, 7, 1, 2, 3 };

            Console.WriteLine("Output for test case 1 is {0}", Find(testcase1, 1));
            Console.WriteLine("Output for test case 2 is {0}", Find(testcase1, 6));
            Console.WriteLine("Output for test case 3 is {0}", Find(testcase1, 2));

            int[] testcase2 = {50, 5, 20, 30, 40};

            Console.WriteLine("Output for test case 4 is {0}", Find(testcase2, 30));
            Console.WriteLine("Output for test case 5 is {0}", Find(testcase2, 5));

            int[] testcase3 = { 2, 2, 2, 3, 4, 2 };

            Console.WriteLine("Output for test case 6 is {0}", Find(testcase3, 4));
        }

        // Returns index of the element if found
        // Returns -1 if not found
        static int Find(int[] arr, int elem)
        {
            return Find(arr, 0, arr.Length - 1, elem);
        }

        static int Find(int[] arr, int start, int end, int elem)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            int midValue = arr[mid];

            if (arr[mid] == elem)
            {
                return mid;
            }

            // Check if left is ordered
            if (arr[start] < arr[mid])
            {
                // if elem is in range, do binSearch on left
                if ((arr[start] <= elem) && (elem < arr[mid]))
                {
                    return Find(arr, start, mid - 1, elem);
                }
                // else do binSearch in right
                else
                {
                    return Find(arr, mid + 1, end, elem);
                }
            }
            else if (arr[mid] < arr[end])
            {
                if ((arr[mid] <= elem) && (elem <= arr[end]))
                {
                    return Find(arr, mid + 1, end, elem);
                }
                else
                {
                    return Find(arr, start, mid - 1, elem);
                }
            }
            // if there are repeats, check both sides
            else
            {
                int leftResult = Find(arr, start, mid - 1, elem);

                if (leftResult != -1)
                {
                    return leftResult;
                }

                return Find(arr, mid + 1, end, elem);
            }
        }
    }
}
