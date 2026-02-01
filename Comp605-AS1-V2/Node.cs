using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp605_AS1_V2
{
    internal class Node
    {
        // Property
        public string Word { get; set; }
        public int ALength { get; set; }

        // Constructors
        public Node()
        {   // Datastructure Initialisation
            this.Word = "";
            this.ALength = 0;
        }

        public Node(string word, int length)
        {
            Word = word;
            ALength = length;
        }

        public override string ToString()
        {
            return "Word: " + Word + ", Length " + ALength.ToString();
        }

    }
}
