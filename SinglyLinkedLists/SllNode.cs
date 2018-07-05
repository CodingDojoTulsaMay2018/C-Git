using System;

namespace SinglyLinkedLists
{
    public class SllNode
    {
        public int value;
        public SllNode next;
        public SllNode(int value)
        {
            this.value = value;
            next = null;
        }
    }
}