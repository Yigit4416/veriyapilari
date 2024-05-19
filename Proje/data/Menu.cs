using structures;
using Newtonsoft.Json;
using App;

namespace structs
{

    public class Menu
    {
        public Category[] categories;

        [JsonIgnore]
        public tree<Category,Food,string> menuTree;

        public void Init()
        {
            menuTree = new tree<Category,Food,string>("Menü");
            // create tree

            foreach (Category category in categories)
            {
                Category newct = new Category(category.name,category.id);
                newct.foods = category.foods;
                //System.Console.WriteLine(category.foods.Length);


                newct.UpdateBranch();

                menuTree.add(newct.branch);
            }
        }

        public void addCategory(string name,int id)
        {
            /*
            Category newct = new Category(category.name);
            newct.foods = category.foods;
            newct.UpdateBranch();

            menuTree.add(newct.branch);
            */

            Category newct = new Category(name, id);
            newct.foods = new Food[0];
            newct.UpdateBranch();

            // update tree

            //newct.branch.chlidren.Print(2);

            //string str = newct.branch.self.ToString();
            //System.Console.WriteLine(str);

            //menuTree.root.chlidren.Print(2);

            menuTree.add(newct.branch);

            //menuTree.root.chlidren.Print(2);


            // update array
            Category[] newCategories = new Category[categories.Length + 1];
            int index = 0;
            foreach (Category category in categories)
            {
                //System.Console.WriteLine("{0}, {1}",index,category.name);
                newCategories[index++] = category;
            }
            newCategories[index] = newct;

            categories = newCategories;

            //System.Console.WriteLine("{0}, {1}", index, newct.name);


        }

        public void removeCategory(int id)
        {
            // update array

            Category[] newCategories = new Category[categories.Length - 1];
            int index = 0;
            foreach (Category category in categories)
            {
                if(index != id)
                    newCategories[index++] = category;
            }

            categories = newCategories;

            // update tree
            object obj = menuTree.root.removeChildren(id);
        }

        public Category getCategory(int id)
        {
            Category val = new Category("",0);

            int index = 0;
            foreach (Category category in categories)
            {
                if (index++ == id)
                    val = category;
            }

            return val;
        }

        public Food removeFood(int categoryId, int id)
        {
            
            Food removed = menuTree.root.getChildren(categoryId).removeChildren(id);

            return removed;
        }

        public Food getFood(int categoryId, int id)
        {
            Category cc = getCategory(categoryId);

            Food get = cc.GetFood(id);

            return get;
        }

        public void Print()
        {
            menuTree.Print();
        }

        public override string ToString()
        {
            return menuTree.ToString();
        }

        public void SaveMenu(string path = Globals.MENU_PATH)
        {
            string data = ToJson();

            try
            {
                File.WriteAllText(path, data);
                Console.WriteLine("Başarıyla kaydedildi.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"HATA: {e.Message}");
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Menu FromPath(string path = Globals.MENU_PATH)
        {

            try
            {
                // Read the entire file contents as a string
                string fileContents = File.ReadAllText(path);

                // Display the file contents
                Console.WriteLine($"Okundu");

                return FromJson(fileContents);
            }
            catch (Exception e)
            {
                Console.WriteLine($"HATA: {e.Message}");
                return null;
            }
        }

        public static Menu FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Menu>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing menu: {ex.Message}");
                return null;
            }
        }
    }

    public class Category
    {
        public int id;
        public string name;
        public Food[] foods;

        [JsonIgnore]
        public treeNode<Category,Food> branch;
        [JsonIgnore]
        public bool lastUpdatedIsBranch = false;

        public Category(string name, int id)
        {
            this.name = name;
            this.id = id;

            lastUpdatedIsBranch = true;
            //UpdateBranch();
        }

        public void AddFood(Food newFood)
        {
            branch.addChildren(newFood);
            UpdateArray();
        }

        public Food RemoveFood(int index)
        {
            Food removed = branch.removeChildren(index);

            //System.Console.WriteLine("TEST");
            branch.Print(2);
            UpdateArray();

            return removed;
        }

        public Food GetFood(int index)
        {
            if (branch == null)
            {
                UpdateBranch();
            }

            //System.Console.WriteLine(index);

            //branch.chlidren.Print(2);

            Food get = branch.getChildren(index);

            //ystem.Console.WriteLine(get.ToString());

            return get;
        }

        public void Update()
        {
            if (!lastUpdatedIsBranch)
            {
                UpdateBranch();
                lastUpdatedIsBranch = true;
            }
            else
            {
                UpdateArray();
                lastUpdatedIsBranch = false;
            }
        }

        /// <summary>
        /// normal değerleri alır ve ağacı günceller
        /// </summary>
        public void UpdateBranch()
        {
            if (branch == null)
            {
                branch = new treeNode<Category, Food>(this);
            }

            branch.self = this;

            branch.chlidren =  new linkedList<Food>();

            foreach (Food food in foods)
            {
                branch.chlidren.add(food);
            }
        }

        public void UpdateArray()
        {
            foods = branch.chlidren.ToArray();
        }

        public override string ToString()
        {
            return name;
        }

    }

    public class Food
    {
        public int id;
        public string name;
        public string description;
        public int price;

        public override string ToString()
        {
            string val = string.Format("[{0}₺] ({3}) {1} : {2}",price, name, description, id);
            return val;
        }
    }
}