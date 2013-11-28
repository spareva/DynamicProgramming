using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int CAPACITY = 10;

    static List<Product> products = new List<Product>();
    static int[,] keep;
    static int[,] curValues;

    static void FindOptimalSolution()
    {
        if (CAPACITY == 0)
        {
            Console.WriteLine("0 -> No capacity");
            return;
        }

        if (products.Count == 0)
        {
            Console.WriteLine("0 -> No products");
            return;
        }

        FillArrays();
    }

    static void FillArrays()
    {        
        for (int productN = 0; productN < curValues.GetLength(0); productN++)
        {
            for (int curCapacity = 1; curCapacity < curValues.GetLength(1); curCapacity++)
            {
                if (productN == 0)
                {
                    curValues[productN, curCapacity] = 0;
                    keep[productN, curCapacity] = 0;
                }
                else
                {
                    Product curProduct = products[productN];
                    if (curProduct.Weight <= curCapacity)
                    {
                        int firstValue = curValues[productN - 1, curCapacity];
                        int secondValue = curProduct.Cost;
                        int weightRemaining = curCapacity - curProduct.Weight;
                        if (weightRemaining > 0)
                        {
                            secondValue += curValues[productN - 1, weightRemaining];
                        }

                        if (firstValue > secondValue)
                        {
                            curValues[productN, curCapacity] = firstValue;
                            keep[productN, curCapacity] = 0;
                        }
                        else
                        {
                            curValues[productN, curCapacity] = secondValue;
                            keep[productN, curCapacity] = 1;
                        }
                    }
                    else
                    {
                        curValues[productN, curCapacity] = 0;
                        keep[productN, curCapacity] = 0;
                    }
                }
            }
        }
    }

    static List<Product> DetermineOptimal()
    {
        List<Product> result = new List<Product>();
        int curProduct = products.Count - 1;
        int maxWeight = CAPACITY;

        while (curProduct > 0)
        {
            if (keep[curProduct, maxWeight] == 1)
            {
                result.Add(products[curProduct]);
                maxWeight -= products[curProduct].Weight;
                curProduct--;
            }
            else
            {
                curProduct--;
            }
        }

        return result;
    }

    static void Print(List<Product> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item.ToString());
        }
    }

    static void Main()
    {       
        products.Add(null);
        products.Add(new Product("beer", 3, 2));
        products.Add(new Product("vodka", 8, 12));
        products.Add(new Product("cheese", 4, 5));
        products.Add(new Product("nuts", 1, 4));
        products.Add(new Product("ham", 2, 3));
        products.Add(new Product("whiskey", 8, 13));

        curValues = new int[products.Count, CAPACITY + 1];
        keep = new int[products.Count, CAPACITY + 1];

        FindOptimalSolution();
        Print(DetermineOptimal());
    }
}
