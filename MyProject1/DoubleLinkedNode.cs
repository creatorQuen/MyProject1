using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class DoubleLinkedNode
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous {get; set;}

        public DoubleLinkedNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
