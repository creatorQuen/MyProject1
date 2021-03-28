using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            Node current = this;
            string s = current.Value + "";
            return s;
        }
    }
}
