using Microsoft.VisualC.StlClr.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_BST
{
    class MyBinaryNode<V>
    {
        public V value;
        public MyBinaryNode<V> left;
        public MyBinaryNode<V> right;

        public MyBinaryNode(V value)
        {
            this.value = value;
        }
    }

    class BST<V> where V : IComparable
    {
        MyBinaryNode<V> head;

        public BST()
        {
            head = null;
        }


        void Add(V value, MyBinaryNode<V> node)
        {
            if (head == null)
            {
                head = new MyBinaryNode<V>(value);
            }
            else if (node.value.CompareTo(value) > 0)
            {
                if (node.left == null)
                    node.left = new MyBinaryNode<V>(value);
                else
                    Add(value, node.left);
            }
            else if (node.value.CompareTo(value) < 0)
            {
                if (node.right == null)
                    node.right = new MyBinaryNode<V>(value);
                else
                    Add(value, node.right);
            }
        }

        void Traverse(MyBinaryNode<V> node)
        {

            if (node.left != null)
                Traverse(node.left);

            Console.WriteLine(node.value);

            if (node.right != null)
                Traverse(node.right);

        }

        public void Print()
        {
            Traverse(head);
        }

        public void Insert(V value)
        {
            Add(value, head);
        }

        void Find(V value, MyBinaryNode<V> node)
        {
            if (value.Equals(node.value))
            {
                Console.WriteLine("Element found");
                return;
            }
            else if (value.CompareTo(node.value) < 0 && node.left != null)
                Find(value, node.left);
            else if (value.CompareTo(node.value) > 0 && node.right != null)
                Find(value, node.right);
            else
            {
                Console.WriteLine("Element Not Found");
            }
        }

        public void Search(V value)
        {
            Find(value, head);
        }
    }
}
