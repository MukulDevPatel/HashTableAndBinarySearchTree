using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree.BinarySearchTree
{
    public class CreateBinarySearchTree
    {
        public static void CreateTree()
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.Add(56);
            binaryTree.Add(30);
            binaryTree.Add(70);
            binaryTree.Add(22);
            binaryTree.Add(40);
            binaryTree.Add(60);
            binaryTree.Add(95);
            binaryTree.Add(11);
            binaryTree.Add(65);
            binaryTree.Add(3);
            binaryTree.Add(16);
            binaryTree.Add(63);
            binaryTree.Add(67);

            Console.WriteLine("Size of the binary tree: " + binaryTree.Size());
            Console.WriteLine("Height of the binary tree: " + binaryTree.Height());

            Console.WriteLine("Binary Tree:");
            binaryTree.DisplayTree();
        }
    }
    public class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Add(int data)
        {
            root = AddRecursive(root, data);
        }

        private Node AddRecursive(Node current, int data)
        {
            if (current == null)
            {
                return new Node(data);
            }

            if (data < current.Data)
            {
                current.Left = AddRecursive(current.Left, data);
            }
            else if (data > current.Data)
            {
                current.Right = AddRecursive(current.Right, data);
            }

            return current;
        }

        public int Size()
        {
            return CountNodes(root);
        }

        private int CountNodes(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            return 1 + CountNodes(current.Left) + CountNodes(current.Right);
        }

        public int Height()
        {
            return CalculateHeight(root);
        }

        private int CalculateHeight(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            int leftHeight = CalculateHeight(current.Left);
            int rightHeight = CalculateHeight(current.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public void DisplayTree()
        {
            DisplayTreeRecursive(root, 0);
        }

        private void DisplayTreeRecursive(Node current, int level)
        {
            if (current == null)
            {
                return;
            }

            DisplayTreeRecursive(current.Right, level + 1);

            Console.WriteLine(new string(' ', level * 4) + current.Data);

            DisplayTreeRecursive(current.Left, level + 1);
        }
    }
}
