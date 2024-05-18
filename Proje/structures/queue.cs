using System.Text;
using System;

namespace structures
{
    
        public class queueNode<T>
        {
            public T veri;
            public queueNode<T> ileri;

            public queueNode(T veri)
            {
                this.veri = veri;
                ileri = null;
            }

            public override string ToString()
            {
                return veri.ToString();
            }
        }

        public class AQueue<T>
        {
            public queueNode<T> bas;
            public queueNode<T> son;

            public AQueue()
            {
                bas = null;
                son = null;
            }
            public bool IsEmpty()
            {
                if(bas == null)
                    return true;
                else
                    return false;
            }

            public void Enqueue(T veri)
            {
                queueNode<T> node = new queueNode<T>(veri);

                if(!IsEmpty())
                    son.ileri = node;
                else
                    bas = node;
                son = node;
            }

            public T Dequeue()
            {
                queueNode<T> temp;
                temp = bas;

                if(!IsEmpty())
                {
                    bas = bas.ileri;
                    if(bas == null)
                        son = null;
                }
                return temp.veri;
            }


            public override string ToString()
            {
                System.Console.WriteLine("asdasdasd");

                StringBuilder sb = new StringBuilder();
                queueNode<T> temp = bas;
                int index = 1;
                while (temp != null)
                {
                    sb.AppendLine($"[{index}] {temp.veri.ToString()}");
                    temp = temp.ileri;
                    index++;
                }

                sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
        }
}