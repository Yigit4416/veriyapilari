using System.Text;
using System;

namespace structures
{
    public class treeNode<T,V>
    {
        public T self;
        public linkedList<V> chlidren;

        public treeNode(T value)
        {
            self = value;
            chlidren = new linkedList<V>();
        }

        public void addChildren(V newV)
        {
            chlidren.add(newV);
        }
        
        public V removeChildren(int index)
        {
            V removed = chlidren.remove(index);

            return removed;
        }

        public V getChildren(int index)
        {
            //System.Console.WriteLine(index);
            V get = chlidren.get(index);

            return get;
        }
        
        public void Print(int space)
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(self.ToString());

            sb.AppendLine("  " + chlidren.ToString().Replace(Environment.NewLine, Environment.NewLine + "  "));

            sb.Remove(sb.Length-1,1);

            return sb.ToString();
        }
    }

    // creates a tree that
    // roots children is T
    // T's children is V
    public class tree<T,V,R>
    {
        public treeNode<R , treeNode<T,V>> root;

        public tree(R name)
        {
            root = new treeNode<R, treeNode<T, V>>(name);
        }

        public void add(treeNode<T,V> newT)
        {
            root.addChildren( newT );
        }

        // removes by index
        public treeNode<T, V> remove(int index)
        {
            treeNode<T, V> removed = root.removeChildren(index);

            return removed;
        }

        // get by index

        public treeNode<T, V> get(int index)
        {
            treeNode<T, V> get = root.removeChildren(index);

            return get;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }
}