using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp605_AS1_V2
{
    internal class MyDictonary
    {
        // Create Dictionary
        Dictionary<string, Node> DictionaryDS { get; set; }

        // Array
        private static int ARRAY_SIZE = 100;                        // Sets the defualt sive of the array.
        private int ASize { get; set; }                             // Variable that contains the current size of the array.
       
        // Create Array
        private Node[] ArrayNodes;                                  // Creates a array of nodes.

        // Constructor
        public MyDictonary()
        {
            DictionaryDS = new Dictionary<string, Node>();          // Ini Dictionary

            ArrayNodes = new Node[ARRAY_SIZE];                      // Ini's the array into the Data structure.
            ASize = 0;                                              // Assigns Asize the value of 0.
        }

        // Methods
        #region PrintArray
        public string PrintArray()
        {
            StringBuilder sb = new StringBuilder();                 // Creates a stringbuilder instance called 'sb'

            if (ArrayNodes == null)                                 // if array is empty then return null
            {
                return null;
            }
            else
            {
                for (int i = 0; i < ArrayNodes.Length; i++)         // For each node in the array
                {
                    sb.Append("[" + i + "] -> ");                   // Add [ i ] -> to the string builder
                    if (ArrayNodes[i] == null)                      // if current array node is empty
                    {
                        sb.Append("empty\n");                       // add empty to string builder
                    }
                    else                                            // else
                    {
                        sb.Append(ArrayNodes[i].ToString() + "\n"); // add the current word to string builder
                    }
                }
                sb.Append("\nNumber of Words: " + ArrayNodes.Length);   // Print total amount of words in the array
                return sb.ToString();                               // return the stringbuild with ToString call to display the stringbuild with specific string outputs
            }
        }
        #endregion

        #region BubbleSortOP
        public string BubbleSortOP()
        {
            Node[] input = ArrayNodes;                              // creates a temp array
            StringBuilder sb = new StringBuilder();                 // creates a stringbuild 'sb'

            var itemMoved = false;                                  // creates itemmoved varable
            do                                                      // while itemMoved varable is true loop
            {
                itemMoved = false;                                  // sets false
                for (int i = 0; i < ASize - 1; i++)                 // ASize == size of the array, loop for the size of the array.
                {
                    if (input[i].Word.Length > input[i + 1].Word.Length)    // if temp arrays word length is under the next
                    {
                        Node lowerValue = input[i + 1];             // takes loer value and compareds it to current + 1
                        input[i + 1] = input[i];                    // takes the input 1 avobe the current and changes that to the current
                        input[i] = lowerValue;                      // takes the current and changes that to the lowerValue
                        itemMoved = true;                           // itemMoved == true
                    }
                }
            } while (itemMoved);                                    // if still true, then keep looping

            sb.AppendLine(ToPrintSort(input));                      // adds the current data to the stringbuild, then sends them to the ToPrintSort method, so it can be printed
            return sb.ToString();                                   // returns the stringbuild with the ToString call, to print the sorted array with the tostring formatting 
        }
        #endregion

        #region PrintDictonaryOP
        public string PrintDictionaryOP()
        {
            StringBuilder sb = new StringBuilder();                 // creates a stringbuilder
            sb.AppendLine("*** Printing Dictionary Entries ***");   // adds string to the stringbuilder
            
            foreach (KeyValuePair<string, Node> item in DictionaryDS)   // for each item in the dictonary
            {
                sb.AppendLine("Word: " + item.Value.Word + ", Length: " + item.Value.ALength);  // add word and word length to the stringbuilder
            }

            sb.Append("\nNumber of Words: " + DictionaryDS.Count());    // adds the total number of words in the dictonary to the end of the stringbuilder.
            return sb.ToString();                                   // returns and prints the stringbuilder.
        }
        #endregion

        #region AddOP
        private void Insert(string word, Node nodeEntry)            // when called, takes a word and a nodeEntry
        {
            DictionaryDS.Add(word, nodeEntry);                      // adds word to the dictonary
        }
        public void AddOP(string word, int Alength)                 // when called, takes a word and word length
        {
            Node nodeEntry = new Node(word, Alength);               // takes the nodeEntry and adds a new node with the called word and word length
            Insert(word, nodeEntry);                                // calls the insert method with the current word and node
        }
        #endregion

        #region FindOP
        public Node FindWord(string word)                           // takes a word when called
        {
            Node nodeEntry = null;                                  // temp node

            if (DictionaryDS.ContainsKey(word))                     // if dictonary contains the current word
            {
                nodeEntry = DictionaryDS[word];                     // add the dictionary entry that contains the word to the node
            }
            return nodeEntry;                                       // return node
        }
        public string FindbyWord(string word)
        {
            string s = null;

            Node nodeEntry = FindWord(word);

            if (nodeEntry != null)
            {
                s = "\nMatch for " + word + " found, with the word length of " + nodeEntry.ALength.ToString();
            }
            else
            {
                s = "\n" + word + " Not Found.";
            }
            return s;
        }

        // Find by Word Length
        private Node FindLength(int value)
        {
            Node nodeEntry = null;
            foreach (KeyValuePair<string, Node> item in DictionaryDS)
            {
                if (item.Value.ALength == value)
                {
                    nodeEntry = item.Value;
                    break;
                }
            }
            return nodeEntry;
        }
        public string FindByWordLength(int value)
        {
            string s = null;

            Node nodeEntry = FindLength(value);
            if (nodeEntry != null)
            {
                s = "\nMatch Found for the word length of " + value + "\n" + nodeEntry.ToString();
            }
            else
            {
                s = "\nA Word with the length of " + value + " was not found.";
            }
            return s;
        }
        #endregion

        #region DeleteOP
        private void Delete(string word, Node nodeEntry)            // called with a word and a node
        {
            DictionaryDS.Remove(word);                              // removes word from dictonary
        }
        public void DeleteOP(string word, int Alength)              // called with a word and word length
        {
            Node nodeEntry = new Node(word, Alength);               // node = word + word length 
            Delete(word, nodeEntry);                                // call delete method with the word and node 
        }
        #endregion

        #region DictionaryToArrayConvOP
        public void DictionaryToArrayConvOP()
        {
            ArrayNodes = DictionaryDS.Values.ToArray();             // copys all the dictionary values over to the array
            ASize = ArrayNodes.Length;                              // changes the array to the size of the dictionary

        }
        #endregion

        #region PrintSortOP
        private string ToPrintSort(Node[] input)                    // called with a node
        {
            StringBuilder stringBuilder = new StringBuilder();      // creates stringbuilder

            if (input == null)                                      // input == null
            {
                return null;                                        // return null
            }

            for (int i = 0; i < input.Length; i++)                  // for each iten in the 'input' node
            {
                stringBuilder.Append("[" + i + "] -> ");            // add to string builer

                if (input[i] == null)                               // if input in array is null, then
                {
                    stringBuilder.Append("empty\n");                // add empty to string builder.
                }
                else
                {
                    stringBuilder.Append(input[i].ToString() + "\n");   // else add current item
                }
            }
            stringBuilder.Append("\nNumber of words: " + ASize.ToString()); // add total number of words to the end of the stringbuilder.

            return stringBuilder.ToString();                        // return string builder with the call ToString for the formatting 
        }
        #endregion

        #region MergeSortOP
        private Node[] Merge(Node[] input, int left, int mid, int right)    // called with node entries
        {
            int n1 = mid - left + 1;                                // creates n1 varables
            int n2 = right - mid;                                   // creates n2

            Node[] LeftArray = new Node[n1];                        // creates a left and right array
            Node[] RightArray = new Node[n2];

            for (int i = 0; i < n1; i++)                            // for each value in n1
            {
                LeftArray[i] = input[left + i];                     // change current in left to, input
            }

            for (int i = 0; i < n2; i++)                            // for each value in n2
            {
                RightArray[i] = input[mid + i + 1];                 // change current value right to, mid + current + 1
            }

            int x = 0, y = 0, z = left;                             // creates x, y, and z varables.

            while (x < n1 && y < n2)                                // loops while x is smaller then n1, and y is smaller then n2
            {
                if (LeftArray[x].Word.Length < RightArray[y].Word.Length)       // if curremt value in left array is smaller then current in right
                {
                    input[z] = LeftArray[x];                        // change input current = left array
                    x++;                                            // add 1 to x
                }
                else
                {
                    input[z] = RightArray[y];                       // change input z to rightarray y
                    y++;                                            // y +1
                }
                z++;                                                // z +1 
            }

            while (x < n1)                                          // while x is smaller then n1
            {
                input[z] = LeftArray[x];                            // change input z into leftarray x 
                x++;                                                // x +1
                z++;                                                // z +1
            }

            while (y < n2)                                          // while y is smaller then n2
            {
                input[z] = RightArray[y];                           // change input z into rightarray y
                y++;                                                // y+ 1
                z++;                                                // z +1
            }
            return input;                                           // return input

        }

        private Node[] MergeSortOp(Node[] input, int left, int right)
        {
            int mid;                                                // create int mid

            if (left < right)                                       // if left is smaller then right
            {
                mid = (left + right) / 2;                           // change mid into left + right / 2

                MergeSortOp(input, left, mid);                      // call mergesortop with input, left and mid
                MergeSortOp(input, mid + 1, right);                 // call mergesortop with input, mid + 1 and right

                input = Merge(input, left, mid, right);             // call merge with input, left, right, mid, and store it as input.
            }
            return input;                                           // return input.
        }

        public string MergeSort()
        {
            StringBuilder sb = new StringBuilder();                 // create a stringbuilder
            Node[] input = ArrayNodes;                              // create a node array called input, with the values of arraynodes

            input = MergeSortOp(input, 0, ASize - 1);               // calls mergesortop with input node array, 0, and ASize -1, then store it as input
            sb.Append(ToPrintSort(input));                          // calls toPrintSort with the input array, and adds it to the stringbuilder
            return sb.ToString();                                   // calls the ToString method for formatting, and retuns the stringbuilder
        }
        #endregion
    }
}
