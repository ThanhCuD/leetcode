using System;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            NewLinkedList myLinkedList = new NewLinkedList();
            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtTail(2);
            myLinkedList.AddAtTail(3);
            myLinkedList.AddAtTail(4);
            myLinkedList.AddAtTail(5);
            while(true)
            {
                Console.WriteLine("Enter what u wannt!");
                Console.WriteLine("1: print");
                Console.WriteLine("2: Add head");
                Console.WriteLine("3: Add Tail");
                Console.WriteLine("4: Add At index");
                Console.WriteLine("5: Delete At index");
                Console.WriteLine("6: Clear screen");
                Console.WriteLine("7: Exit");
                var ss = int.TryParse(Console.ReadLine(),out int key);
                if (key == 1)
                {
                    myLinkedList.Print();
                }
                else if (key == 3)
                {
                    Console.Write("Data : ");
                    var rs = int.TryParse(Console.ReadLine(), out int data);
                    myLinkedList.AddAtTail(data);
                }
                else if (key == 4)
                {
                    Console.Write("Data : ");
                    var rs = int.TryParse(Console.ReadLine(), out int data);
                    Console.Write("Index : ");
                    rs = int.TryParse(Console.ReadLine(), out int index);
                    myLinkedList.AddAtIndex(index,data);
                }
                else if (key == 5)
                {
                    Console.Write("Index : ");
                    var rs = int.TryParse(Console.ReadLine(), out int index);
                    myLinkedList.DeleteAtIndex(index);
                }
                else if (key == 2)
                {
                    Console.Write("Data : ");
                    var rs = int.TryParse(Console.ReadLine(), out int data);
                    myLinkedList.AddAtHead(data);
                }
                else  if (key == 6)
                {
                    Console.Clear();
                }
                else 
                {
                    break;
                }
            }
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

    class NewLinkedList
    {
        public Node Head { get; set; }
        public int Count { get; set; }

        public void AddAtHead(int value)
        {
            var temp = new Node(value);
            temp.Next = Head;
            Head = temp;
            Count++;
        }
        public void AddAtTail(int value)
        {
           
            var temp = new Node(value);
            if(Head == null)
            {
                Head = temp;
                return;
            }
            var lastNode = GetLastNode();
            lastNode.Next = temp;
            Count++;
        }
        public void AddAtIndex(int index, int value)
        {
            if (index < 0 || index > Count) return;
            if (index == 0)
            {
                AddAtHead(value);
                return;
            }
            if(index == Count)
            {
                AddAtTail(value);
                return;
            }
            var temp = Head;
            var i = 0;
            while(i < index - 1)
            {
                temp = temp.Next;
                i++;
            }
            var node = new Node(value);
            node.Next = temp.Next.Next;
            temp.Next = node;
        }
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index > Count) return;
            var i = 0;
            var temp = Head;
            while(i < index - 1)
            {
                temp = temp.Next;
            }
            temp.Next = temp.Next.Next;
            Count--;
        }
        public int Get(int index)
        {
            var i = 0;
            var temp = Head;
            while (i < index)
            {
                temp = temp.Next;
            }
            return temp.Value;
        }
        public void Print()
        {
            var temp = Head;
            while (temp.Next !=null)
            {
                Console.Write(temp.Value + "; ");
                temp = temp.Next;
            }
            Console.WriteLine(temp.Value + "; ");
            Console.WriteLine("Count: " + Count);
        }
        private Node GetLastNode()
        {
            var temp = Head;
            while(temp.Next !=null)
            {
                temp = temp.Next;
            }
            return temp;
        }
    }
}
