using System;

namespace SinglyLinkedLists
{
    public class SinglyLinkedLists
    {
        public SllNode head;
        public SinglyLinkedLists()
        {
            head = null;
        }
        public void add(int value)
        {
            SllNode newNode = new SllNode(value);
            if(head == null)
            {
                head =newNode;
            }
            else
            {
                SllNode runner = head;
                while(runner.next != null)
                {
                    runner = runner.next;
                }
                runner.next = newNode;
            }
        }

        public void printValues()
        {
           var runner = head;
           while(runner !=null)
           {
               System.Console.WriteLine(runner.value);
               runner =runner.next;
           }
           
        }

        public void removeEnd()
        {
            var runner = head;
            while(runner.next != null)
            {
                if(runner.next.next == null)
                {
                    runner.next = null;
                    break;
                }
                runner = runner.next;
            }
        }

        public void find(int val)
        {
            var runner = head;
            while(runner !=null)
            {
                
            }
        }

    }
}