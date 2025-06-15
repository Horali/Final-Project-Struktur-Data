using System;
using FinalProject.Models;

namespace FinalProject.DataStructures.Queue
{
    public class OrderQueue
    {
        private OrderNode head;
        private OrderNode tail;
        private int nextOrderNumber = 1;

        public void Enqueue(string name, string details)
        {
            var newOrder = new Order
            {
                CustomerName = name,
                OrderDetails = details,
                OrderNumber = nextOrderNumber++
            };

            OrderNode newNode = new OrderNode(newOrder);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Console.WriteLine($"Order #{newOrder.OrderNumber} for {newOrder.CustomerName} added!");
        }

        public Order EnqueueAndReturn(string name, string details)
        {
            var newOrder = new Order
            {
                CustomerName = name,
                OrderDetails = details,
                OrderNumber = nextOrderNumber++
            };

            OrderNode newNode = new OrderNode(newOrder);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Console.WriteLine($"Order #{newOrder.OrderNumber} for {newOrder.CustomerName} added!");
            return newOrder;
        }


        public Order Dequeue()
        {
            if (head == null)
            {
                Console.WriteLine("No orders to serve.");
                return null;
            }

            OrderNode served = head;
            head = head.Next;

            // If it was the last node
            if (head == null)
                tail = null;

            Console.WriteLine($"Order #{served.Data.OrderNumber} served!");
            return served.Data;
        }

        public Order Peek()
        {
            if (head == null)
            {
                Console.WriteLine("Queue is empty.");
                return null;
            }

            return head.Data;
        }

        public void PrintAll()
        {
            if (head == null)
            {
                Console.WriteLine("No pending orders.");
                return;
            }

            OrderNode current = head;
            while (current != null)
            {
                var o = current.Data;
                Console.WriteLine($"#{o.OrderNumber} - {o.CustomerName}: {o.OrderDetails}");
                current = current.Next;
            }
        }

        public int Count()
        {
            int count = 0;
            OrderNode current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
