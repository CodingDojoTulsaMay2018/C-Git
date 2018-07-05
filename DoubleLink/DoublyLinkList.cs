using System;

namespace DoubleLink
{
    public class DoubleLinkList
    {
        public DllNode head;
        public DllNode prev;
        public DllNode tail;
        public DoubleLinkList()
        {
            head = null;
            prev = null;
            tail = null;
        }
        public void add(int value)
        {
            DllNode newNode = new DllNode(value);
            if(head == null)
            {
                head =newNode;
                tail = newNode;
            }
            else
            {
                DllNode runner = head;
                while(runner.Next != null)
                {
                    runner = runner.Next;
                }
                runner.Next = newNode;
                newNode.Prev = runner;
                tail = newNode;
            }
        }
        public bool remove(int val)
        {
            var runner = head;

            while(runner !=null)
            {
                // System.Console.WriteLine(runner.value);
                if(runner.value == val)
                {
                    runner.Prev.Next = runner.Next;
                    runner.Next.Prev = runner.Prev;
                    return true;
                }              
    
                runner = runner.Next;
            }
            return false;
            
        }
        public void printValues()
        {
           var runner = head;
           while(runner !=null)
           {
               System.Console.WriteLine(runner.value);
               runner =runner.Next;
           }
           
        }

        public void reverse()
        {
            DllNode temp = null;
            var runner = head;

            while(runner != null)
            {
                temp = runner.Prev;
                runner.Prev = runner.Next;
                runner.Next = temp;
                runner = runner.Prev;
            
            }
            if(temp !=null)
            head = temp.Prev;
        }
 
    }
}