using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int[] sequence = { 2, 4, 3, 5, 1, 7, 6, 9, 8 };
    static int[] currentLength;
    static int[] predecessors;

    static void CalculateLength()
    {
        currentLength[0] = 1;
        predecessors[0] = -1;
        int bestLength = 0;
        int bestEndIndex = 0;

        for (int i = 1; i < sequence.Length; i++)
        {
            currentLength[i] = 1;
            predecessors[i] = -1;

            for (int j = i-1; j >= 0; j--)
            {
                if (currentLength[j] + 1 > currentLength[i] && sequence[j] < sequence[i])
                {
                    currentLength[i] = currentLength[j] + 1;
                    predecessors[i] = j;
                }
            }

            if (currentLength[i] > bestLength)
            {
                bestLength = currentLength[i];
                bestEndIndex = i;
            }
        }
        PrintMaxLength(bestLength, bestEndIndex);
    }

    static void PrintMaxLength(int length, int end)
    {
        string result = "";
        
        for (int i = 0; i < length; i++)
        {
            result += sequence[end];
            end = predecessors[end];
        }

        for (int i = result.Length - 1; i >= 0; i--)
        {
            Console.Write(result[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        currentLength = new int[sequence.Length];
        predecessors = new int[sequence.Length];

        CalculateLength();
    }
}
