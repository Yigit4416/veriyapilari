using System;
using System.Collections.Generic;

public class Inventory
{
    private Dictionary<string, int> inventory;

    public Inventory()
    {
        inventory = new Dictionary<string, int>
        {
            { "Mercimek Çorbası (1)", 10 },
            { "Tarhana Çorbası (2)", 5 },
            { "Kebap (3)", 7 },
            { "Köfte (4)", 8 },
            { "Ispanak (5)", 3 },
            { "Baklava (6)", 12 },
            { "Sütlaç (7)", 6 }
        };
    }

    public bool UpdateInventory(string item)
    {
        if (inventory.ContainsKey(item) && inventory[item] > 0)
        {
            inventory[item]--;
            return true;
        }
        return false;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Envanter Durumu:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
