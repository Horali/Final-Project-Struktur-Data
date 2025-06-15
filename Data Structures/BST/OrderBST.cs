using System;
using FinalProject.Models;

namespace FinalProject.DataStructures.BST
{
    public class OrderBST
    {
        private BSTNode root;

        public void Insert(Order order)
        {
            root = InsertRecursive(root, order);
        }

        private BSTNode InsertRecursive(BSTNode node, Order order)
        {
            if (node == null)
                return new BSTNode(order);

            int cmp = string.Compare(order.CustomerName, node.Data.CustomerName, StringComparison.OrdinalIgnoreCase);
            if (cmp < 0)
                node.Left = InsertRecursive(node.Left, order);
            else if (cmp > 0)
                node.Right = InsertRecursive(node.Right, order);
            // Ignore duplicates by name

            return node;
        }

        public Order Search(string name)
        {
            return SearchRecursive(root, name);
        }

        private Order SearchRecursive(BSTNode node, string name)
        {
            if (node == null)
                return null;

            int cmp = string.Compare(name, node.Data.CustomerName, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0)
                return node.Data;
            else if (cmp < 0)
                return SearchRecursive(node.Left, name);
            else
                return SearchRecursive(node.Right, name);
        }

        public void PrintInOrder()
        {
            if (root == null)
            {
                Console.WriteLine("No orders in BST.");
                return;
            }

            PrintRecursive(root);
        }

        private void PrintRecursive(BSTNode node)
        {
            if (node == null) return;

            PrintRecursive(node.Left);
            var o = node.Data;
            Console.WriteLine($"#{o.OrderNumber} - {o.CustomerName}: {o.OrderDetails}");
            PrintRecursive(node.Right);
        }

        public void Delete(string name)
        {
            root = DeleteRecursive(root, name);
        }

        private BSTNode DeleteRecursive(BSTNode node, string name)
        {
            if (node == null) return null;

            int cmp = string.Compare(name, node.Data.CustomerName, StringComparison.OrdinalIgnoreCase);
            if (cmp < 0)
                node.Left = DeleteRecursive(node.Left, name);
            else if (cmp > 0)
                node.Right = DeleteRecursive(node.Right, name);
            else
            {
                // Found the node
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Node with two children
                var minLargerNode = FindMin(node.Right);
                node.Data = minLargerNode.Data;
                node.Right = DeleteRecursive(node.Right, minLargerNode.Data.CustomerName);
            }

            return node;
        }

        private BSTNode FindMin(BSTNode node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

    }
}
