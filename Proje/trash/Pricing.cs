using System;
using System.Collections;
using System.Collections.Generic;

public class Pricing
{
    private Hashtable pricing;

    public Pricing()
    {
        pricing = new Hashtable()
        {
            { "Mercimek Çorbası (1)", 30.0m },
            { "Yayla Çorbası (2)", 40.0m },
            { "Domates Çorbası (3)", 40.0m }, 
            { "Humus (4)", 45.0m },
            { "Mücver (5)", 50.0m },
            { "Patetes Köftesi (6)", 50.0m },
            { "Taze Fasulye (7)", 40.0m },
            { "Şaksuka (8)", 55.0m },
            { "Patates Salatası (9)", 35.0m },
            { "İskender (10)", 250.0m },
            { "Tavuk Sote (11)", 180.0m },
            { "Şiş Çevirme (12)", 320.0m },
            { "Sütlaç (13)", 80.0m },
            { "Supangle (14)", 90.0m},
            { "Baklava (15)", 120.0m },
            { "Su (16))", 10.0m },
            { "Kola (17)", 40.0m },
            { "Çay (18)", 20.0m },
        };
    }

    public decimal GetPrice(string item)
    {
        if (pricing.ContainsKey(item))
        {
            decimal val = (decimal)pricing[item];
            return val;
        }
        return 0.0m;
    }
}
