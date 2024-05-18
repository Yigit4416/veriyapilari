using System;
using System.Collections.Generic;

public class Pricing
{
    private Dictionary<string, decimal> pricing;

    public Pricing()
    {
        pricing = new Dictionary<string, decimal>
        {
            { "Mercimek Çorbası (1)", 15.0m },
            { "Tarhana Çorbası (2)", 12.0m },
            { "Kebap (3)", 30.0m },
            { "Köfte (4)", 25.0m },
            { "Ispanak (5)", 20.0m },
            { "Baklava (6)", 18.0m },
            { "Sütlaç (7)", 10.0m }
        };
    }

    public decimal GetPrice(string item)
    {
        if (pricing.ContainsKey(item))
        {
            return pricing[item];
        }
        return 0.0m;
    }
}
