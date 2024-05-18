// TreeNode Sınıfı
public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; private set; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }

    public void Traverse(int depth = 0)
    {
        Console.WriteLine(new string(' ', depth * 2) + Value);
        foreach (var child in Children)
        {
            child.Traverse(depth + 1);
        }
    }
}

// Yemek Menüsü Sınıfı
public class Menu
{
    private TreeNode<string> root;

    public Menu()
    {
        root = new TreeNode<string>("Menu");
    }

    public void AddMenuItem(string[] path, string item)
    {
        TreeNode<string> currentNode = root;

        foreach (var part in path)
        {
            TreeNode<string> nextNode = currentNode.Children.Find(n => n.Value == part);
            if (nextNode == null)
            {
                nextNode = new TreeNode<string>(part);
                currentNode.AddChild(nextNode);
            }
            currentNode = nextNode;
        }

        currentNode.AddChild(new TreeNode<string>(item));
    }

    public void DisplayMenu()
    {
        root.Traverse();
    }
}