using System;

/// <summary>
/// Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
/// cost (replace a letter) = 1
/// cost (delete a letter) = 0.9
/// cost (insert a letter) = 0.8
/// Example: x = "developer", y = "enveloped" -> cost = 2.7
/// delete ‘d’:  "developer" -> "eveloper", cost = 0.9
/// insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
/// replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1
///
/// Link with explanation: http://www.let.rug.nl/kleiweg/lev/
/// </summary>
public class MinimumEditDistance
{
    const decimal DELCOST = 0.9M;
    const decimal INSCOST = 0.8M;
    const decimal REPLACECOST = 1M;

    static decimal[,] costsTable;

        
    public static decimal Compute(string str1, string str2)
    {
        int str1len = str1.Length;
        int str2len = str2.Length;
        costsTable = new decimal[str1len + 1, str2len + 1];

        // Step 1: Fill cost of deletions
        for (int row = 0; row <= str1len; row++)
        {
            costsTable[row, 0] = row * DELCOST;
        }

        // Step 2: Fill cost of insertions
        for (int col = 0; col <= str2len; col++)
        {
            costsTable[0, col] = col * INSCOST;
        }

        for (int row = 1; row <= str1len; row++)
        {
            // Step 4
            for (int col = 1; col <= str2len; col++)
            {                
                decimal cost = (str2[col - 1] == str1[row - 1]) ? 0 : REPLACECOST;

                decimal delete = costsTable[row - 1, col] + DELCOST;
                decimal replace = costsTable[row - 1, col - 1] + cost;
                decimal insert = costsTable[row, col - 1] + INSCOST;

                costsTable[row, col] = Math.Min(
                    Math.Min(delete, insert),
                    replace);
            }
        }

        // Step 7: Take and return the result (most down-right cell)
        return costsTable[str1len, str2len];
    }

    public static void Main()
    {
        var result1 = Compute("developer", "enveloped");
        Console.WriteLine("Words: developer -> enveloped");
        Console.WriteLine("Distance = {0}", result1);
        Console.WriteLine();
    }
}

