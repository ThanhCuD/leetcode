using System;
using System.Collections.Generic;
using System.Text;

namespace LC
{
    public class MyL
    {
        public Nodee Head { get; set; }
        public int Count { get; set; }
        public int Get(int index)
        {
            if (index < 0 || index > Count - 1) return -1;
            var temp = Head;
            int i = 0;
            while (i < index)
            {
                i++;
                temp = temp.Next;
            }
            return temp.Value;
        }
        public void AddAtHead(int val)
        {
            var temp = new Nodee(val);
            if (Head == null)
            {
                Head = temp;
            }
            else
            {
                temp.Next = Head;
                Head = temp;
            }
            Count++;
        }
        public void AddAtTail(int val)
        {
            if (Count == 0)
            {
                AddAtHead(val);
            }
            else
            {
                var lstNode = GetLastNodee();
                var temp = new Nodee(val);
                lstNode.Next = temp;
                Count++;
            }
        }
        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > Count) return;
            if (index == 0)
            {
                AddAtHead(val);
                return;
            }
            if (index == Count)
            {
                AddAtTail(val);
                return;
            }
            var nNode = new Nodee(val);
            var temp = Head;
            var i = 0;
            while (i < index - 1)
            {
                i++;
                temp = temp.Next;
            }
            nNode.Next = temp.Next;
            temp.Next = nNode;
            Count++;
        }
        public void Print()
        {
            var temp = Head;
            while (temp.Next != null)
            {
                Console.Write(temp.Value + "; ");
                temp = temp.Next;
            }
            Console.WriteLine(temp.Value + "; ");
            Console.WriteLine("Count: " + Count);
        }
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= Count) return;
            if (index == 0)
            {
                Head = Head.Next;
                Count--;
                return;
            }
            var i = 0;
            var temp = Head;
            while (i < index - 1)
            {
                i++;
                temp = temp.Next;
            }
            temp.Next = temp.Next.Next;
            Count--;
        }
        private Nodee GetLastNodee()
        {
            if (Head == null) return null;
            var temp = Head;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }
    }
    public class Nodee
    {
        public int Value { get; set; }
        public Nodee Next { get; set; }
        public Nodee(int value)
        {
            Value = value;
        }
    }
}
