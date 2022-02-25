using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTask
{
    internal class Node
    {
        /*public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }*/
        public string data;
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(string data)
        {
            this.data = data;
        }
    }
}
