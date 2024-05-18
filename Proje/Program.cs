class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Dictionary<string, int> inventory = new Dictionary<string, int>();
        Dictionary<string, decimal> pricing = new Dictionary<string, decimal>();

        menu.AddMenuItem(new string[] { "Çorbalar" }, "Mercimek Çorbası (1)");
        menu.AddMenuItem(new string[] { "Çorbalar" }, "Tarhana Çorbası (2)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Et Yemekleri" }, "Kebap (3)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Et Yemekleri" }, "Köfte (4)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Sebze Yemekleri" }, "Ispanak (5)");
        menu.AddMenuItem(new string[] { "Tatlılar" }, "Baklava (6)");
        menu.AddMenuItem(new string[] { "Tatlılar" }, "Sütlaç (7)");

        // Envanter
        inventory["Mercimek Çorbası (1)"] = 10;
        inventory["Tarhana Çorbası (2)"] = 5;
        inventory["Kebap (3)"] = 7;
        inventory["Köfte (4)"] = 8;
        inventory["Ispanak (5)"] = 3;
        inventory["Baklava (6)"] = 12;
        inventory["Sütlaç (7)"] = 6;

        // Fiyatlar
        pricing["Mercimek Çorbası (1)"] = 15.0m;
        pricing["Tarhana Çorbası (2)"] = 12.0m;
        pricing["Kebap (3)"] = 30.0m;
        pricing["Köfte (4)"] = 25.0m;
        pricing["Ispanak (5)"] = 20.0m;
        pricing["Baklava (6)"] = 18.0m;
        pricing["Sütlaç (7)"] = 10.0m;

        Dictionary<string, int> orderDictionary = new Dictionary<string, int>();
        decimal totalPrice = 0.0m;

        while (true)
        {
            Console.WriteLine("Menü için (1), seçim yapmak için (2), ödeme yapmak için (3), envanteri görüntülemek için (4), çıkmak için (5)");
            string kullaniciGirdisi = Console.ReadLine();

            if (Int32.TryParse(kullaniciGirdisi, out int secim))
            {
                switch (secim)
                {
                    case 1:
                        menu.DisplayMenu();
                        break;
                    case 2:
                        Console.WriteLine("Siparişinizi girin (numaralarla, virgülle ayrılmış):");
                        string[] selections = Console.ReadLine().Split(',');

                        foreach (var selection in selections)
                        {
                            string item = GetMenuItemByNumber(selection.Trim());
                            if (item != null && inventory.ContainsKey(item) && inventory[item] > 0)
                            {
                                if (orderDictionary.ContainsKey(item))
                                {
                                    orderDictionary[item]++;
                                }
                                else
                                {
                                    orderDictionary[item] = 1;
                                }
                                inventory[item]--;
                                totalPrice += pricing[item];
                                Console.WriteLine($"{item} siparişe eklendi. Kalan envanter: {inventory[item]}, Fiyat: {pricing[item]} TL");
                            }
                            else
                            {
                                Console.WriteLine($"{item} stokta yok veya yanlış bir seçim yaptınız.");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Siparişiniz:");
                        foreach (var kvp in orderDictionary)
                        {
                            Console.WriteLine($"{kvp.Value} x {kvp.Key} = {kvp.Value * pricing[kvp.Key]} TL");
                        }
                        Console.WriteLine($"Toplam Tutar: {totalPrice} TL");
                        orderDictionary.Clear();
                        totalPrice = 0.0m;
                        Console.WriteLine("Ödeme işlemi tamamlandı.");
                        break;
                    case 4:
                        DisplayInventory(inventory);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş.");
            }
        }
    }

    static string GetMenuItemByNumber(string number)
    {
        // Menu traversal to find item by number (not implemented here).
        // This is a placeholder for actual logic to map number to menu item.
        return number switch
        {
            "1" => "Mercimek Çorbası (1)",
            "2" => "Tarhana Çorbası (2)",
            "3" => "Kebap (3)",
            "4" => "Köfte (4)",
            "5" => "Ispanak (5)",
            "6" => "Baklava (6)",
            "7" => "Sütlaç (7)",
            _ => null,
        };
    }

    static void DisplayInventory(Dictionary<string, int> inventory)
    {
        Console.WriteLine("Envanter Durumu:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
