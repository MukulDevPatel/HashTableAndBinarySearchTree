using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree
{
    public class MyBinaryNode<T> : INode<T> where T : IComparable<T>
    {
        public T Key { get; private set; }
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }

        public MyBinaryNode(T key)
        {
            Key = key;
            Left = null;
            Right = null;
        }
    }
}
