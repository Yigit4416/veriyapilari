using Proje;
using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Inventory inventory = new Inventory();
        Pricing pricing = new Pricing();
        Order order = new Order(pricing);

        List<Category> categories = new List<Category>();

        Category corbalar = new Category(1,"Çorbalar");
        Category araSicak = new Category(2,"Ara Sıcak");
        Category anaYemek = new Category(3,"Ana Yemek");
        Category araSoguk = new Category(4,"Ara Soğuk");
        Category tatlilar = new Category(5,"Tatlılar");
        Category icecekler = new Category(6,"İçecekler");


        categories.Add(corbalar);
        categories.Add(araSicak);
        categories.Add(araSoguk);
        categories.Add(anaYemek);
        categories.Add(tatlilar);
        categories.Add(icecekler);

        menu.AddMenuItem(new string[] { categories[0].Name }, "Mercimek Çorbası (1)");
        menu.AddMenuItem(new string[] { categories[0].Name }, "Yayla Çorbası (2)");
        menu.AddMenuItem(new string[] { categories[0].Name }, "Domates Çorbası (3)");
        
        menu.AddMenuItem(new string[] { categories[1].Name }, "Humus (4)");
        menu.AddMenuItem(new string[] { categories[1].Name }, "Mücver (5)");
        menu.AddMenuItem(new string[] { categories[1].Name }, "Patetes Köftesi (6)");

        menu.AddMenuItem(new string[] { categories[2].Name }, "Taze Fasulye (7)");
        menu.AddMenuItem(new string[] { categories[2].Name }, "Şakşuka (8)");
        menu.AddMenuItem(new string[] { categories[2].Name }, "Patates Salatası (9)");

        menu.AddMenuItem(new string[] { categories[3].Name }, "İskender (10)");
        menu.AddMenuItem(new string[] { categories[3].Name }, "Şiş Çevirme (11)");
        menu.AddMenuItem(new string[] { categories[3].Name }, "Tavuk Sote (12)");

        menu.AddMenuItem(new string[] { categories[4].Name }, "Sütlaç (13)");
        menu.AddMenuItem(new string[] { categories[4].Name }, "Supangle (14)");
        menu.AddMenuItem(new string[] { categories[4].Name }, "Baklava (15)");

        menu.AddMenuItem(new string[] { categories[5].Name }, "Su (16)");
        menu.AddMenuItem(new string[] { categories[5].Name }, "Kola (17)");
        menu.AddMenuItem(new string[] { categories[5].Name }, "Çay(18)");

        

        while (true)
        {
            Console.WriteLine("Menü (1), Sipariş (2), Ödeme (3), Envanter (4), Çıkış (5), Ürün Ekleme (6)");
            int kullaniciGirdisi = Convert.ToInt32(Console.ReadLine());

            switch (kullaniciGirdisi)
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
                case 6:
                    Console.WriteLine("Eklemek istediğini ürünün kategori");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
    public List<Category> DeclareCategory()
    {
        List<Category> categories = new List<Category>();
        return categories;
    }
}
