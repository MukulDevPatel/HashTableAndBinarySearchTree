using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree
{
    public class MyHashTable<TKey, TValue>
    {
        private LinkedList<MyMapNode<TKey, TValue>>[] buckets;

        public MyHashTable(int size)
        {
            buckets = new LinkedList<MyMapNode<TKey, TValue>>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new LinkedList<MyMapNode<TKey, TValue>>();
            }
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            int index = Math.Abs(hashCode % buckets.Length);
            return index;
        }

        public TValue Get(TKey key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
            }

            throw new KeyNotFoundException("Key not found in the hash table.");
        }

        public int GetSize()
        {
            int size = 0;
            foreach (var bucket in buckets)
            {
                size += bucket.Count;
            }
            return size;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value; // Update the value if the key already exists
                    return;
                }
            }

            var newNode = new MyMapNode<TKey, TValue>(key, value);
            bucket.AddLast(newNode);
        }

        public void Remove(TKey key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    bucket.Remove(node);
                    return;
                }
            }

            throw new KeyNotFoundException("Key not found in the hash table.");
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }
    }

    public class RemoveAvoidableWord
    {
        public static void AvoidableWord()
        {
            // Create the hash table
            MyHashTable<string, string> hashTable = new MyHashTable<string, string>(10);

            // Add key-value pairs
            hashTable.Add("1", "One");
            hashTable.Add("2", "Two");
            hashTable.Add("3", "Three");
            hashTable.Add("4", "Four");
            hashTable.Add("5", "Five");

            // Get the value for a key
            string value = hashTable.Get("2");
            Console.WriteLine("Value for key '2': " + value);

            // Remove the key-value pair
            hashTable.Remove("1");

            // Check if the hash table is empty
            bool isEmpty = hashTable.IsEmpty();
            Console.WriteLine("Is the hash table empty? " + isEmpty);

            // Print the size of the hash table
            int size = hashTable.GetSize();
            Console.WriteLine("Size of the hash table: " + size);

            // Remove the word "avoidable" from the phrase
            string phrase = "Paranoids are not paranoid because they are paranoid but " +
                "because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] words = phrase.Split(' ');

            LinkedList<string> linkedList = new LinkedList<string>(words);
            LinkedListNode<string> currentNode = linkedList.First;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals("avoidable"))
                {
                    var nextNode = currentNode.Next;
                    linkedList.Remove(currentNode);
                    currentNode = nextNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }

            string updatedPhrase = string.Join(" ", linkedList);
            Console.WriteLine("Updated phrase: " + updatedPhrase);
        }
    }
}
