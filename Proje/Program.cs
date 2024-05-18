using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Inventory inventory = new Inventory();
        Pricing pricing = new Pricing();
        Order order = new Order(pricing);

        menu.AddMenuItem(new string[] { "Çorbalar" }, "Mercimek Çorbası (1)");
        menu.AddMenuItem(new string[] { "Çorbalar" }, "Tarhana Çorbası (2)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Et Yemekleri" }, "Kebap (3)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Et Yemekleri" }, "Köfte (4)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Sebze Yemekleri" }, "Ispanak (5)");
        menu.AddMenuItem(new string[] { "Tatlılar" }, "Baklava (6)");
        menu.AddMenuItem(new string[] { "Tatlılar" }, "Sütlaç (7)");

        while (true)
        {
            Console.WriteLine("Menü için (1), sipariş vermek için (2), ödeme yapmak için (3), envanteri görüntülemek için (4), çıkmak için (5)");
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
                            string item = Menu.GetMenuItemByNumber(selection.Trim());
                            if (item != null && inventory.UpdateInventory(item))
                            {
                                order.AddOrder(item);
                                Console.WriteLine($"{item} siparişe eklendi.");
                            }
                            else
                            {
                                Console.WriteLine($"{item} stokta yok veya yanlış bir seçim yaptınız.");
                            }
                        }
                        break;
                    case 3:
                        order.DisplayOrder();
                        order.ClearOrder();
                        Console.WriteLine("Ödeme işlemi tamamlandı.");
                        break;
                    case 4:
                        inventory.DisplayInventory();
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
}
