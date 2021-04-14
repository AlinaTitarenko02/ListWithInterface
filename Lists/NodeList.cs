using System;

namespace List
{
    public class DblNode
    {
        public int Value { get; set; }
        public DblNode Previous { get; set; }
        public DblNode Next { get; set; }

        public DblNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
