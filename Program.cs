using HashTableAndBinarySearchTree.HashTableProblems;

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
                Console.WriteLine("Select an option from below in the list");
                Console.WriteLine("1. Find frequency of Words\n2. Find Frequency Form large Paragraph\n3. Remove Avoidable Word\n4. Exit");
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
                        flag = false;
                        break;
                }
            }
        }
    }
}
