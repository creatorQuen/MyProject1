using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class DoLiNode
    {
        public int Value { get; set; }
        public DoLiNode Next { get; set; }
        public DoLiNode Previous {get; set;}

        public DoLiNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
