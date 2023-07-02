using HashTableAndBinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree
{
    public class BinarySearchTreeAddNum<T> where T : IComparable<T>
    {
        private INode<T> root;

        public BinarySearchTreeAddNum()
        {
            root = null;
        }

        public void Add(T key)
        {
            root = AddRecursive(root, key);
        }

        private INode<T> AddRecursive(INode<T> current, T key)
        {
            if (current == null)
                return new MyBinaryNode<T>(key);

            int compareResult = key.CompareTo(current.Key);

            if (compareResult < 0)
                current.Left = AddRecursive(current.Left, key);
            else if (compareResult > 0)
                current.Right = AddRecursive(current.Right, key);

            return current;
        }
        public void DisplayRecursive(INode<T> current)
        {
            if (current == null) return;
            DisplayRecursive(current.Left);
            Console.Write(current.Key + " ");
            DisplayRecursive(current.Right);
        }
        public void Display()
        {
            DisplayRecursive(root);
        }
    }

    public class AddNumUsingBST
    {
        public static void AddNumber()
        {
            BinarySearchTreeAddNum<int> bst = new BinarySearchTreeAddNum<int>();
            bst.Add(56);
            bst.Add(30);
            bst.Add(70);

            bst.Display();
        }
    }
}