using System;
using System.Collections.Generic;

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
