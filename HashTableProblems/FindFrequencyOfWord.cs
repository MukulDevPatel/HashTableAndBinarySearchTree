using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree
{
    public class MyMapNode<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public MyMapNode(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }

    // Hash map class implemented using a linked list
    public class MyHashMap<K, V>
    {
        private LinkedList<MyMapNode<K, V>>[] map;
        private int size;

        public MyHashMap(int initialCapacity)
        {
            size = 0;
            map = new LinkedList<MyMapNode<K, V>>[initialCapacity];
        }

        private int GetHash(K key)
        {
            return Math.Abs(key.GetHashCode()) % map.Length;
        }

        public V Get(K key)
        {
            int index = GetHash(key);
            LinkedList<MyMapNode<K, V>> linkedList = map[index];

            if (linkedList != null)
            {
                foreach (MyMapNode<K, V> node in linkedList)
                {
                    if (node.Key.Equals(key))
                        return node.Value;
                }
            }

            return default(V); // Key not found
        }

        public int GetSize()
        {
            return size;
        }

        public void Add(K key, V value)
        {
            int index = GetHash(key);
            LinkedList<MyMapNode<K, V>> linkedList = map[index];

            if (linkedList == null)
            {
                linkedList = new LinkedList<MyMapNode<K, V>>();
                map[index] = linkedList;
            }

            foreach (MyMapNode<K, V> node in linkedList)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value; // Key already exists, update the value
                    return;
                }
            }

            linkedList.AddLast(new MyMapNode<K, V>(key, value));
            size++;
        }

        public void Remove(K key)
        {
            int index = GetHash(key);
            LinkedList<MyMapNode<K, V>> linkedList = map[index];

            if (linkedList != null)
            {
                foreach (MyMapNode<K, V> node in linkedList)
                {
                    if (node.Key.Equals(key))
                    {
                        linkedList.Remove(node);
                        size--;
                        return;
                    }
                }
            }
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
    }

    public class FindFrequencyOfWord
    {
        public static void FindFrequency()
        {
            string sentence = "To be or not to be";
            string[] words = sentence.Split(' ');

            MyHashMap<string, int> hashMap = new MyHashMap<string, int>(10);

            foreach (string word in words)
            {
                string lowercaseWord = word.ToLower();

                int frequency = hashMap.Get(lowercaseWord);
                hashMap.Add(lowercaseWord, frequency + 1);
            }

            foreach (string word in words)
            {
                string lowercaseWord = word.ToLower();

                int frequency = hashMap.Get(lowercaseWord);
                Console.WriteLine($"{lowercaseWord}:- {frequency}");
            }
        }
    }
}
