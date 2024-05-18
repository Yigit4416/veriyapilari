using structs;
using structures;
using CLI;

namespace structs
{
    public class Order
    {

        public Food[] foods;

        public int price;
        public string str;

        public Order(Food[] foods)
        {
            this.foods = foods;

            Update();
        }

        public void Update()
        {
            string val ="";
            int pr = 0;

            int len = foods.Length;
            int ctr = 0;
            foreach (Food food in foods)
            {
                pr += food.price;
                val += food.name;
                if (++ctr != len)
                    val += ", ";
            }

            str = val;
            price = pr;
        }

        public override string ToString()
        {
            return string.Format("[{0}₺] {1}", price, str);
        }
    }

    public class OrderQueue
    {
        AQueue<Order> queue;

        public Menu menu;

        public OrderQueue(Menu menu)
        {
            queue = new AQueue<Order>();
            this.menu = menu;
        }

        public void AddOrder(string orderString)
        {

            // "1,1 1,2 2,3 ..."
            string[] orders = orderString.Split(' ');
            int pairCount = orders.Length;

            //"1,1" , "1,2" , "2,3"

            Food[] pairs = new Food[pairCount]; 
            for (int i = 0; i < pairCount; i++)
            {
                string[] t = orders[i].Split(',');
                //System.Console.WriteLine(orders[i]);
                int a = Convert.ToInt32(t[0]) - 1;
                int b = Convert.ToInt32(t[1]) - 1;
                //System.Console.WriteLine("{0}, {1}",a,b);
                pairs[i] = menu.getFood(a,b);
            }

            Order newOrder = new Order(pairs);

            queue.Enqueue(newOrder);
        }

        public void OrderComplete()
        {
            Order complete = queue.Dequeue();

            Console.WriteLine("Complete: {0}", complete.ToString());
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return queue.ToString();
        }
    }
}