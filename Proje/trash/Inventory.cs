using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private Hashtable inventory;

    public Inventory()
    {
        inventory = new Hashtable
        {
           
            { "Mercimek Çorbası (1)", 332},
            { "Yayla Çorbası (2)", 512},
            { "Domates Çorbası (3)", 321}, 
            { "Humus (4)", 125},
            { "Mücver (5)",128},
            { "Patetes Köftesi (6)", 632},
            { "Taze Fasulye (7)", 7},
            { "Şaksuka (8)", 812},
            { "Patates Salatası (9)", 125},
            { "İskender (10)", 230},
            { "Tavuk Sote (11)", 115},
            { "Şiş Çevirme (12)", 222},
            { "Sütlaç (13)", 123},
            { "Supangle (14)", 14},
            { "Baklava (15)", 121},
            { "Su (16)", 32},
            { "Kola (17)", 61},
            { "Çay (18)", 43},
        };
    }

    public bool UpdateInventory(string item)
    {
        int value = (int)inventory[item];
        if (inventory.ContainsKey(item) && value > 0)
        {
            value--;
            inventory[item] = value;
            return true;
        }
        return false;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Envanter Durumu:");
        foreach (DictionaryEntry item in inventory)
        {
            string name = (string)item.Key;
            int quantity = (int)item.Value;
            Console.WriteLine($"{name}: {quantity}");
        }
    }
}
