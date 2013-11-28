using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Product
{
    public string Name { get; protected set; }
    private int weight;
    private int cost;

    public int Weight
    {
        get {return this.weight;}
        set {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid weight");
            }
            else
            {
                this.weight = value;
            }
        }
    }
    public int Cost
    {
       get { return this.cost;}
       set {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid cost");
            }
            else
            {
                this.cost = value;
            }
       }
    }

    public Product(string name, int weight, int cost)
    {
        this.Name = name;
        this.Weight = weight;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return ("Product: " + this.Name);
    }
}
