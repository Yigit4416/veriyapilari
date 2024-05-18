using System;
using System.Collections.Generic;

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

    public static string GetMenuItemByNumber(string number)
    {
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
}
