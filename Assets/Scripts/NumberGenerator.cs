using System;
using System.Collections.Generic;

public static class NumberGenerator
{
    private static Random rand = new Random();

    /// <summary>
    /// Generates and returns an integer array filled with random numbers between 1 and 9.
    /// The sum of the numbers in the array is guaranteed to be a multiple of 10.
    /// </summary>
    /// <param name="total">The total number of numbers in the returned array.</param>
    /// <param name="difficulty">
    /// A difficulty level that affects the game's balance.
    /// Higher values increase the probability of lower numbers appearing.
    /// Must be between 2 and 10, but values of 7 or higher may impact performance.
    /// </param>
    /// <returns>An integer array</returns>
    public static int[] GenerateRandomNumbers(int total, int difficulty)
    {
        int[] result = new int[total];
        int idx = 0;
        List<int> counts = new List<int>();
        for (int i = 2; i <= difficulty; i++)
        {
            counts.Add(i);
        }
        
        while (total > 0)
        {
            int ran = rand.Next(0, counts.Count);
            int count = Math.Min(counts[ran], total);
            total -= count;

            List<int> list = new List<int>();
            while (list.Count < count - 1)
            {
                int num = rand.Next(1, 10);
                if (list.Contains(num) == false)
                    list.Add(num);
            }
            list.Add(0);
            list.Add(10);
            list.Sort();

            for (int i = 1; i < list.Count; i++)
            {
                result[idx++] = list[i] - list[i - 1];
            }
        }

        return result;
    }
}
