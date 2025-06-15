using System;
using FinalProject.DataStructures.Queue;
using FinalProject.DataStructures.BST;
using FinalProject.Models;


namespace FinalProject.Services
{
    public class OrderService
    {
        private readonly OrderQueue queue;
        private readonly OrderBST bst;

        public OrderService()
        {
            queue = new OrderQueue();
            bst = new OrderBST();
        }

        public void PlaceOrder()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Enter order details: ");
            string details = Console.ReadLine();

            // Queue handles order number
            var order = queue.EnqueueAndReturn(name, details);
            bst.Insert(order);
        }


        public void ServeNextOrder()
        {
            var served = queue.Dequeue();
            if (served != null)
            {
                bst.Delete(served.CustomerName);
            }
        }


        public void PeekNextOrder()
        {
            var next = queue.Peek();
            if (next != null)
                Console.WriteLine($"Next: #{next.OrderNumber} - {next.CustomerName}: {next.OrderDetails}");
        }

        public void ViewWaitingOrders()
        {
            queue.PrintAll();
        }

        public void CountPendingOrders()
        {
            int count = queue.Count();
            Console.WriteLine($"Pending orders: {count}");
        }

        public void ViewSortedOrders()
        {
            bst.PrintInOrder();
        }

        public void SearchOrderByName()
        {
            Console.Write("Enter customer name to search: ");
            string name = Console.ReadLine();

            var found = bst.Search(name);
            if (found != null)
                Console.WriteLine($"Found: #{found.OrderNumber} - {found.CustomerName}: {found.OrderDetails}");
            else
                Console.WriteLine("Customer not found.");
        }
    }
}
