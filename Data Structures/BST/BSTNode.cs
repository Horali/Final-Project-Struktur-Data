using FinalProject.Models;

namespace FinalProject.DataStructures.BST
{
    public class BSTNode
    {
        public Order Data { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }

        public BSTNode(Order data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
