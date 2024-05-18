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
            "2" => "Yayla Çorbası (2)", 
            "3" => "Domates Çorbası (3)", 
            "4" => "Humus (4)",
            "5" => "Mücver (5)", 
            "6" => "Patetes Köftesi (6)",
            "7" => "Taze Fasulye (7)",
            "8" => "Şaksuka (8)",
            "9" => "Patates Salatası (9)", 
            "10" => "İskender (10)", 
            "11" => "Tavuk Sote (11)", 
            "12" => "Şiş Çevirme (12)", 
            "13" => "Sütlaç (13)", 
            "14" => "Supangle (14)", 
            "15" => "Baklava (15)", 
            "16" => "Su (16))", 
            "17" => "Kola (17)", 
            "18" => "Çay (18)",
            _ => null,
        };
    }
}
