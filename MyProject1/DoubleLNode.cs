using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class DoubleLNode
    {
        public int Value { get; set; }
        public DoubleLNode Next { get; set; }
        public DoubleLNode Previous {get; set;}

        public DoubleLNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public override string ToString()
        {
            DoubleLNode current = this;
            string s = current.Value + "";
            return s;
        }
    }
}
