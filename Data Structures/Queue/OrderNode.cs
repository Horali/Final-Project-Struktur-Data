using FinalProject.Models;

namespace FinalProject.DataStructures.Queue
{
    public class OrderNode
    {
        public Order Data { get; set; }
        public OrderNode Next { get; set; }

        public OrderNode(Order data)
        {
            Data = data;
            Next = null;
        }
    }
}
