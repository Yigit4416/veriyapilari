using System;
using System.Collections.Generic;

public class Order
{
    private Queue<string> orderQueue;
    private Dictionary<string, int> orderSummary;
    private Pricing pricing;

    public Order(Pricing pricing)
    {
        this.pricing = pricing;
        orderQueue = new Queue<string>();
        orderSummary = new Dictionary<string, int>();
    }

    public void AddOrder(string item)
    {
        orderQueue.Enqueue(item);
        if (orderSummary.ContainsKey(item))
        {
            orderSummary[item]++;
        }
        else
        {
            orderSummary[item] = 1;
        }
    }

    public void DisplayOrder()
    {
        decimal totalPrice = 0.0m;
        Console.WriteLine("Siparişiniz:");
        foreach (var kvp in orderSummary)
        {
            decimal itemTotal = kvp.Value * pricing.GetPrice(kvp.Key);
            Console.WriteLine($"{kvp.Value} x {kvp.Key} = {itemTotal} TL");
            totalPrice += itemTotal;
        }
        Console.WriteLine($"Toplam Tutar: {totalPrice} TL");
    }

    public void ClearOrder()
    {
        orderQueue.Clear();
        orderSummary.Clear();
    }
}
