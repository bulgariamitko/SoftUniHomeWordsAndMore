using System;
class LongestArea
{
    static void Main()
    {
        uint n;
        string lastString = "", longestSeqString = "";
        uint longestSequence = 1, currentSequence = 0;
        CheckInput(out n);
        string[] strings = new string[n];
        for (uint i = 0; i < n; i++)
        {
            strings[i] = Console.ReadLine();
            if (lastString == strings[i])
            {
                currentSequence++;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    longestSeqString = strings[i];
                }
            }
            else
            {
                currentSequence = 1;
            }
            lastString = strings[i];
        }

        Console.WriteLine(longestSequence);

        if (longestSequence == 1)
        {
            Console.WriteLine(strings[0]);
        }
        else
        {
            for (int i = 1; i <= longestSequence; i++)
            {
                Console.WriteLine(longestSeqString);
            }
        }
    }
    static void CheckInput(out uint number)
    {
        while (!uint.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input, try again!");
        }
    }
}