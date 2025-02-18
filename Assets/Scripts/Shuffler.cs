using System;

public static class Shuffler
{
    private static Random rand = new Random();

    public static void Shuffle(int[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
