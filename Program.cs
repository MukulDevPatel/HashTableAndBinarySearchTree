using HashTableAndBinarySearchTree.HashTableProblems;
using HashTableAndBinarySearchTree.BinarySearchTree;

namespace HashTableAndBinarySearchTree
{
    class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Welcome to Hash Table and Binary Search Tree");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nSelect an option from below in the list");
                Console.WriteLine("1. Find frequency of Words\n2. Find Frequency Form large Paragraph\n3. Remove Avoidable Word");
                Console.WriteLine("BST Options\n4. Add Number using BST\n5. Create a Bibnary tree\n6. Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        FindFrequencyOfWord.FindFrequency();
                        break;
                    case 2:
                        FindWordFrequencyInLargeParagraph.CountWordsFromTheSentence();
                        break;
                    case 3:
                        RemoveAvoidableWord.AvoidableWord();
                        break;
                    case 4:
                        AddNumUsingBST.AddNumber();
                        break;
                    case 5:
                        CreateBinarySearchTree.CreateTree();
                        break;
                    case 6:
                        flag = false;
                        break;
                }
            }
        }
    }
}
