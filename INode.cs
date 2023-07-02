using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree
{
    public interface INode<T> where T: IComparable<T>
    {
        T Key { get; }
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
    }
}
