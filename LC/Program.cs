using System;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtTail(2);
            myLinkedList.AddAtTail(3);
            myLinkedList.AddAtTail(4);
            myLinkedList.AddAtTail(5);
           
            myLinkedList.DeleteAtIndex(2);    
        }
    }
    class MyLinkedList
    {
        public MyLinkedList()
        {
            Count = 0;
        }
        public Node Head { get; set; }
        public int Count { get; set; }
        public void AddAtHead(int val)
        {
            var node = new Node(val);
            node.Next = Head;
            Head = node;
            Count++;
        }
        public void AddAtTail(int val)
        {
            var node = new Node(val);
            if (Head == null)
            {
                Head = node;
                return;
            }
            var lsNote = GetLastNode();
            lsNote.Next = node;
            Count++;
        }
        public void AddAtIndex(int index, int val)
        {
            if(index == 0)
            {
                AddAtHead(val);
            }
            else if(index == Count)
            {
                AddAtTail(val);
            }
            else
            {
                var i = 0;
                var current = Head;
                /// 2
                while (i < index  -1)
                {
                    current = current.Next;
                    i++;
                }
                var node = new Node(val);
                var next = current.Next;
                var pre = current;
                pre.Next = node;
                node.Next = next;
                Count++;
            }
        }
        public void DeleteAtIndex(int index)
        {
            if(index == 0)
            {
                Head = Head.Next;
                Count--;
                return;
            }
            
            var i = 0;
            var current = Head;
            /// 2
            while (i < index -1)
            {
                current = current.Next;
                i++;
            }
            var next = current.Next.Next;
            current.Next = next;
            Count--;
        }
        public int Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                return -1;
            }
            var i = 0;
            var current = Head;
            /// 2
            while (i < index)
            {
                current = current.Next;
                i++;
            }
            return current.Value;
        }
        Node GetLastNode()
        {
            Node temp = Head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int val)
        {
            Value = val;
            Next = null;
        }
    }
}
