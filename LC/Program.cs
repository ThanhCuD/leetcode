using System;
using System.Collections.Generic;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list = new ListNode(1);
            new Solution().RemoveNthFromEnd(list, 1);
            MyL myLinkedList = new MyL();
            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtTail(3);
            myLinkedList.AddAtIndex(1, 2);
            myLinkedList.Get(1);
            myLinkedList.DeleteAtIndex(1);
            myLinkedList.Get(1);
            while (true)
            {
                Console.WriteLine("Enter what u wannt!");
                Console.WriteLine("1: print");
                Console.WriteLine("2: Add head");
                Console.WriteLine("3: Add Tail");
                Console.WriteLine("4: Add At index");
                Console.WriteLine("5: Delete At index");
                Console.WriteLine("6: Clear screen");
                Console.WriteLine("7: Exit");
                var ss = int.TryParse(Console.ReadLine(), out int key);
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
                    myLinkedList.AddAtIndex(index, data);
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
                else if (key == 6)
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
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var listA = new List<ListNode>();
            var listB = new List<ListNode>();
            var tempA = headA;
            var tempB = headB;
            while (tempA!=null)
            {
                listA.Insert(0,tempA);
                tempA = tempA.next;
            }
            while (tempB != null)
            {
                listB.Insert(0,tempB);
                tempB = tempB.next;
            }
            if (listA.Count == 0 || listB.Count == 0) return null;
            var i = 0;
            while (i < listA.Count && i < listB.Count && listA[i] ==listB[i])
            {
                i++;
            }
            if (i == 0) return null;
            return listA[i - 1];
        }
        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            var pA = headA;
            var pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }
            return pA;
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var cur = head;
            var list = new List<ListNode>();
            while (cur != null)
            {
                list.Add(cur);
                cur = cur.next;
            }
            if (n < 0 || list.Count < n) return head;
            if(list.Count - n - 1 < 0)
            {
                head = head.next;
                return head;
            }
            var temp = list[list.Count - n-1];
            temp.next = temp.next.next;
            return head;
        }
        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            var pa = head;
            while (true)
            {
                var temp = pa;
                for (int i = 0; i <= n ; i++)
                {
                    if (temp == null)
                    {
                        head = head.next; return head;
                    }
                    temp = temp.next;
                }
                if(temp == null)
                {
                    pa.next = pa.next.next;
                    return head;
                }
                pa = pa.next;
            }
        }
    }
}
