using System;
using System.Collections;
using System.Collections.Generic;

public class Order
{
    private Queue<string> orderQueue;
    private Hashtable orderSummary;
    private Pricing pricing;

    public Order(Pricing pricing)
    {
        this.pricing = pricing;
        orderQueue = new Queue<string>();
        orderSummary = new Hashtable();
    }

    public void AddOrder(string item)
    {
        orderQueue.Enqueue(item);

        if (orderSummary.ContainsKey(item))
        {
            int value = (int)orderSummary[item];
            orderSummary[item] = value + 1;
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

        foreach (DictionaryEntry kvp in orderSummary)
        {
            string item = (string)kvp.Key;
            int quantity = (int)kvp.Value;
            decimal itemTotal = quantity * pricing.GetPrice(item);
            Console.WriteLine($"{quantity} x {item} = {itemTotal} TL");
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
