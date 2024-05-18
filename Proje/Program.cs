class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        menu.AddMenuItem(new string[] { "Çorbalar" }, "Mercimek Çorbası (1)");
        menu.AddMenuItem(new string[] { "Çorbalar" }, "Tarhana Çorbası (2)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Et Yemekleri" }, "Kebap (3)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Et Yemekleri" }, "Köfte (4)");
        menu.AddMenuItem(new string[] { "Ana Yemekler", "Sebze Yemekleri" }, "Ispanak (5)");
        menu.AddMenuItem(new string[] { "Tatlılar" }, "Baklava (6)");
        menu.AddMenuItem(new string[] { "Tatlılar" }, "Sütlaç (7)");

        Queue<string> orderQueue = new Queue<string>();

        while (true)
        {
            Console.WriteLine("Menü için (1), hesabınız için (2), ödeme yapmak için (3), çıkmak için (4)");
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
                            orderQueue.Enqueue(selection.Trim());
                        }
                        Console.WriteLine("Siparişiniz eklendi.");
                        break;
                    case 3:
                        Console.WriteLine("Siparişiniz:");
                        foreach (var item in orderQueue)
                        {
                            Console.WriteLine(item);
                        }
                        orderQueue.Clear();
                        Console.WriteLine("Ödeme işlemi tamamlandı.");
                        break;
                    case 4:
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
