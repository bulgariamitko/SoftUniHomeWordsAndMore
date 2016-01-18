using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestNon
{
    class SeqList
    {
        static int equalsFirstIndex;
        static int increasingFirstIndex;

        static void Main()
        {
            string input = Console.ReadLine();
            input = input.Trim();
            int[] arr = input.Split(' ').Select(s => int.Parse(s)).ToArray();
            List<int> increasingSeq = getBestSequence(arr, false); //e.g:  1 2 3 4
            List<int> equalSeq = getBestSequence(arr, true); //e.g:  1 1 1 1

            if (increasingSeq.Count < equalSeq.Count ||
                increasingSeq.Count == equalSeq.Count && increasingFirstIndex > equalsFirstIndex)
            {
                increasingSeq = new List<int>(equalSeq);
            }

            foreach (var item in increasingSeq)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //finds longest non-decreasing subsequence
        static List<int> getBestSequence(int[] arr, bool equal)
        {
            List<int>[] lens = new List<int>[arr.Length];
            int maxIndex = 0;

            for (int currIndex = 0; currIndex < arr.Length; currIndex++)
            {
                bool expression;
                lens[currIndex] = new List<int>();
                lens[currIndex].Add(arr[currIndex]);
                for (int prevIndex = 0; prevIndex < currIndex; prevIndex++)
                {
                    expression = arr[prevIndex] < arr[currIndex];
                    if (equal)
                    {
                        expression = arr[prevIndex] == arr[currIndex];
                    }

                    if (expression &&
                        lens[currIndex].Count <= lens[prevIndex].Count)
                    {
                        lens[currIndex] = new List<int>(lens[prevIndex]);
                        lens[currIndex].Add(arr[currIndex]);

                        if (lens[currIndex].Count > lens[maxIndex].Count)
                        {
                            maxIndex = currIndex;
                        }
                    }
                }
            }
            if (equal == false)
            {
                increasingFirstIndex = maxIndex;
            }
            else
            {
                equalsFirstIndex = maxIndex;
            }
            return lens[maxIndex];
        }
    }
}