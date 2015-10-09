using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node
    {
        public int Value { get; set; }
        public List<Node> ChildNodes { get; set; }

        public Node(int value)
        {
            this.Value = value;
            this.ChildNodes = new List<Node>();
        }
    }
}
