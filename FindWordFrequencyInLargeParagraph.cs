using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinarySearchTree.HashTableProblems
{
    /*public class FindWordFrequencyInLargeParagraph
    {
    }*/

    public class MyMapNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    class MyHashMap<TKey, TValue>
    {
        private LinkedList<MyMapNode<TKey, TValue>>[] buckets;
        private int size;

        public MyHashMap(int capacity)
        {
            buckets = new LinkedList<MyMapNode<TKey, TValue>>[capacity];
            size = 0;
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % buckets.Length;
            return Math.Abs(index);
        }

        public TValue Get(TKey key)
        {
            int index = GetBucketIndex(key);
            LinkedList<MyMapNode<TKey, TValue>> bucket = buckets[index];

            if (bucket != null)
            {
                foreach (var node in bucket)
                {
                    if (node.Key.Equals(key))
                        return node.Value;
                }
            }

            return default(TValue);
        }

        public int GetSize()
        {
            return size;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            LinkedList<MyMapNode<TKey, TValue>> bucket = GetOrCreateBucket(index);

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value;
                    return;
                }
            }

            MyMapNode<TKey, TValue> newNode = new MyMapNode<TKey, TValue>
            {
                Key = key,
                Value = value
            };

            bucket.AddLast(newNode);
            size++;
        }

        public void Remove(TKey key)
        {
            int index = GetBucketIndex(key);
            LinkedList<MyMapNode<TKey, TValue>> bucket = buckets[index];

            if (bucket != null)
            {
                LinkedListNode<MyMapNode<TKey, TValue>> currentNode = bucket.First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        bucket.Remove(currentNode);
                        size--;
                        break;
                    }

                    currentNode = currentNode.Next;
                }
            }
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private LinkedList<MyMapNode<TKey, TValue>> GetOrCreateBucket(int index)
        {
            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<MyMapNode<TKey, TValue>>();
            }

            return buckets[index];
        }
    }

    public class FindWordFrequencyInLargeParagraph
    {
        public static void CountWordsFromTheSentence()
        {
            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] words = paragraph.Split(' ');

            MyHashMap<string, int> wordFrequencyMap = new MyHashMap<string, int>(words.Length);

            foreach (string word in words)
            {
                int frequency = wordFrequencyMap.Get(word);
                wordFrequencyMap.Add(word, frequency + 1);
            }

            Console.WriteLine("Word Frequency:");

            foreach (string word in words)
            {
                Console.WriteLine($"{word}: {wordFrequencyMap.Get(word)}");
            }
        }
    }
}
