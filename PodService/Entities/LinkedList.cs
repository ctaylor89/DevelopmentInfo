using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.Entities
{
    public class LinkedList
    {
        private Node head;

        public void PrintAllNodes()
        {
            Node cur = head;

            while (cur.Next != null)
            {
                Console.WriteLine(cur.Data);
                cur = cur.Next;
            }
        }
        
        public void Add(object data)
        {
            Node toAdd = new Node();
            toAdd.Data = data;
            Node current = head;
            current.Next = toAdd;
        }
    };

    public class Node
    {
        public Node Next { get; set; }
        public Object Data { get; set; }
    };

    

}
