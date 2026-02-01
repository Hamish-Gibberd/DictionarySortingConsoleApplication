using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp605_AS1_V2
{
    internal class Program
    {
        // Create Instance
        private static MyDictonary myDictonary = new MyDictonary();

        #region Main
        static void Main(string[] args)
        {
            bool runProgram = true;                                                     // turns on and off program

            while (runProgram == true)                                                  // while true run loop
            {
                Console.Clear();                                                        // clears screen
                Console.WriteLine("\n**** Dictionary and Sorting Program ****\n");
                Console.WriteLine("1. Load File");
                Console.WriteLine("2. Insert Word");
                Console.WriteLine("3. Find Word");
                Console.WriteLine("4. Delete Word");
                Console.WriteLine("5. Print Dictionary");
                Console.WriteLine("6. Convert Dictionary to Array");
                Console.WriteLine("7. Print Array");
                Console.WriteLine("8. Sort Words By Word Length Using Bubble Sort");
                Console.WriteLine("9. Sort Words By Word Length Using Merge Sort");
                Console.WriteLine("10. Exit");
                Console.WriteLine("\nPick a Option: ");

                string choice = Console.ReadLine();                                     // saves users choice
                switch (choice)
                {
                    case "1":                                                           // if user input == 
                        LoadFileOption();                                               // calls 'loadfileoption'
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "2": 
                        InsertDataOP();                                                 // calls insertdataop
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "3":
                        FindOption();                                                   // calls findoption
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "4":
                        DeleteWord();                                                   // calls DeleteWord 
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "5":
                        Console.WriteLine(myDictonary.PrintDictionaryOP());             // calls PrintDictionaryOP with the myDictonary instance
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "6":
                        myDictonary.DictionaryToArrayConvOP();                          // calls DictonaryToArrayConvOP with the myDictionary instance
                        Console.WriteLine("\nThe Dictionary has been converted to a Array.");
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "7":
                        Console.WriteLine("*** Printing Array ***");
                        Console.WriteLine(myDictonary.PrintArray());                    // calls printarray with the myDiconary instance
                        Console.WriteLine("\nPress any key to continue...");
                        break;
                    case "8":
                        Console.WriteLine("\nSorting Words By Word Length Using Bubble Sort...");
                        Console.WriteLine("\nPlease wait a sec...");
                        Stopwatch swBubbleSort = Stopwatch.StartNew();                  // create stopwatch
                        swBubbleSort.Start();                                           // start sw
                        myDictonary.BubbleSortOP();                                     // call dictonary with the myDictonary instance
                        swBubbleSort.Stop();                                            // stops sw
                        TimeSpan timespanswBubbleSort = swBubbleSort.Elapsed;           // creates a timespan varable with the sw data
                        Console.WriteLine("Time Taken: " + timespanswBubbleSort.ToString(@"ss\.fffffff") + "s");    // displays the time in seconds 
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "9":
                        Console.WriteLine("\nSort Words By Word Length Using Merge Sort...");
                        Console.WriteLine("\nPlease wait a sec...");
                        Stopwatch swMergeSort = Stopwatch.StartNew();                   // create sw
                        swMergeSort.Start();                                            // start sw 
                        myDictonary.MergeSort();                                        // calls Merge sort algoritum with the myDictonary instance
                        Console.WriteLine("\nPress any key to continue...");
                        swMergeSort.Stop();                                             // stops sw 
                        TimeSpan timespanMergeSort = swMergeSort.Elapsed;               // creates a timespan varable with the sw data
                        Console.WriteLine("Time Taken: " + timespanMergeSort.ToString(@"ss\.fffffff") + "s");       // displays the time in seconds
                        break;
                    case "10":
                        Console.WriteLine("\nClosing Program... ");
                        runProgram = false;                                             // stops the program
                        return;
                    default:                                                            // if not valid input, error
                        Console.WriteLine("\nInvalid Option...");
                        Console.WriteLine("Please Enter 1-10");                         // 1-10
                        Console.WriteLine("Press any key to continue...");
                        break;
                }
                Console.ReadKey();
            }
        }
        #endregion

        #region LoadFile
        private static void LoadFileOption()
        {
            // Declears varables
            string findUserOption = "";
            bool userOptionTrue = true;
            string folderPath = null;

            while (userOptionTrue)                                          // while true
            {
                Console.Clear();                                            // clears console
                Console.WriteLine("\n**** Find Option ****\n");
                Console.WriteLine("1. Load Ordered Data");
                Console.WriteLine("2. Load Random Data");
                Console.WriteLine("3. Go Back To Main Menu");
                Console.WriteLine("\nPick an Option: ");

                findUserOption = Console.ReadLine();                        // takes user input saves it as a varable

                switch (findUserOption)
                {
                    case "1":
                        Console.Clear();                                    // clears console
                        Console.WriteLine("\nLoading Ordered Data... \n");
                        folderPath = "../../Data/ordered/";                 // declears file path for ordered data
                        LoadDataOP(folderPath);                             // calls the 'LoadDataOP' with the file path
                        return;                                             // breaks look
                    case "2":
                        Console.Clear();                                    // clears console
                        Console.WriteLine("\nLoading Random Data... \n");
                        folderPath = "../../Data/random/";                  // declears file path for random data
                        LoadDataOP(folderPath);                             // calls the 'LoadDataOP' with the file path
                        return;
                    case "3":
                        Console.WriteLine("\nGoing Back to Main Menu");
                        Console.WriteLine("Press any key to continue...");
                        userOptionTrue = false;                             // breaks loop
                        break;
                    default:                                                // makes sure the input is either 1,2 or 3
                        Console.WriteLine("\nInvalid Option...");
                        Console.WriteLine("Please Enter 1, 2 or 3");
                        Console.WriteLine("Press any key to continue...");
                        break;
                }
                Console.ReadKey();                                          // waits for user to enter a key
            }
        }
        
        private static void LoadDataOP(string folderPath)
        {
            try                                                             // try / catch for error checking when loading files
            {
                var files = Directory.GetFiles(folderPath, "*.txt");        // saves all file names within the folder using a directory

                foreach (var file in files)                                 // for each txt file within the folder
                {
                    Console.WriteLine("Processing: " + Path.GetFileName(file)); // display txt file name
                    foreach (var line in File.ReadLines(file))              // for each line of text within the txt folder.
                    {
                        string word = line.Trim();                          // take only the word
                        if (string.IsNullOrEmpty(word) || word.StartsWith("#"))     // if the word has nothing, or starts with a #
                        {
                            continue;                                       // go to next item in loop
                        }

                        if (myDictonary.FindWord(word) == null)             // calls the instance with the findword method, and checks if there the word is already in the dictonary
                        {
                            myDictonary.AddOP(word, word.Length);           // if == no then adds the word and word length to the dictonary
                        }
                    }
                }
                Console.WriteLine("\nData has been entered succcessfully\n");
                Console.WriteLine(files.Length + " Files Processed.\n");    // shows the total number of files processed in the folder
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while loading files:");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Insert
        private static void InsertDataOP()
        {
            string newUserEntry = "";                                       // user input varable
            Console.WriteLine("Please Enter the word you wish to insert: ");
            newUserEntry = Console.ReadLine();                              // takes user entry

            if (myDictonary.FindWord(newUserEntry) == null)                 // calls the findword method with the current instance, and checks if there is the word the user asked inside the dictonary
            {
                myDictonary.AddOP(newUserEntry, newUserEntry.Length);       // calls the AddOP with the current instance, adds the users word and word length to the instance
                Console.WriteLine("Entries: " + newUserEntry + " with the length of: " + newUserEntry.Length + " Have been inserted.");
            }
            else
            {
                Console.WriteLine(newUserEntry + " already exsits.");       // already exsits so nothing is done
            }    
        }
        #endregion

        #region Find
        private static void FindOption()
        {
            string findUserOption = "";                                     // declears varables 
            bool userOptionTrue = true;

            while (userOptionTrue)                                          // if true
            {
                Console.Clear();                                            // clears/resets console.
                Console.WriteLine("\n**** Find Option ****\n");
                Console.WriteLine("1. Find By Word");
                Console.WriteLine("2. Find By Word Length");
                Console.WriteLine("3. Go Back To Main Menu");
                Console.WriteLine("\nPick an Option: ");

                findUserOption = Console.ReadLine();

                switch (findUserOption)
                {
                    case "1":
                        FindbyWordOP();                                     // calls findbywordop method
                        return;
                    case "2":
                        FindByWordLengthOP();                               // calls FindByWordLengthOP method
                        return;
                    case "3":
                        userOptionTrue = false;                             // stops loop
                        Console.WriteLine("\nGoing Back to Main Menu...");
                        break;
                    default:                                                // makes sure only valid inputs are inputed. 1,2,3
                        Console.WriteLine("\nInvalid Option...");
                        Console.WriteLine("Please Enter 1, 2, or 3");
                        Console.WriteLine("Press any key to continue...");
                        break;
                }
            }
        }

        // Find by Word
        private static void FindbyWordOP()
        {
            string userWordFind = "";                                       // declears varable 
            Console.WriteLine("\nEnter a word would you like to find? ");
            userWordFind = Console.ReadLine();                              // takes user input
            Console.WriteLine(myDictonary.FindbyWord(userWordFind));        // calls and displays the FindByWordOP with the users input
        }

        // Find by Word Length
        private static void FindByWordLengthOP()
        {
            string userWordLength = "";                                     // declears varable
            Console.WriteLine("\nEnter a word length would you like to find? ");
            userWordLength = Console.ReadLine();                            // takes user input
            Console.WriteLine(myDictonary.FindByWordLength(int.Parse(userWordLength)));     // calls and displays the FindByWordLength with the users input
        }
        #endregion

        #region Delete
        private static void DeleteWord()
        {
            string newUserDeleteInput = "";                                 // declears varable
            Console.WriteLine("Please Enter the word you wish to Delete: ");
            newUserDeleteInput = Console.ReadLine();                        // takes user input

            myDictonary.DeleteOP(newUserDeleteInput, newUserDeleteInput.Length);    // calls the DeleteOP method with the current instance and the users word, and the word length of the users word.
            Console.WriteLine("Entries: " + newUserDeleteInput + " with the length of: " + newUserDeleteInput.Length + " has been Deleted.");
        }
        #endregion

    }
}
