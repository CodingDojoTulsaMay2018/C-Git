using System;

namespace DoubleLink
{
    public class DllNode
    {
        public int value;
        public DllNode Next;
        public DllNode Prev;
        public DllNode(int value)
        {
            this.value = value;
            Next = null;
        }
    }
}