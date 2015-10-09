using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Tree
    {
        private Node rootNode;

        public Tree(int rootValue)
        {
            rootNode = new Node(rootValue);
            this.rootNode = rootNode;
        }

        public Node InsertNode(int nodeValue, int fatherValue)
        {
            var father = this.GetNode(fatherValue);
            if (father != null)
            {
                var newNode = new Node(nodeValue);
                father.ChildNodes.Add(newNode);
                return newNode;
            }
            return null;
        }

        public Node GetNode(int value)
        {
            return this.FindNode(rootNode, value);
        }

        private Node FindNode(Node node, int value)
        {
            if (node.Value == value)
                return node;
            foreach (var child in node.ChildNodes)
            {
                var _node = this.FindNode(child, value);
                if (_node != null)
                    return _node;
            }
            return null;
        }

        public void Print()
        {
            this.PrintNode(rootNode);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private void PrintNode(Node node)
        {
            Console.Write(node.Value + " -> ");
            if (node.ChildNodes.Count > 0)
            {
                foreach (var childNode in node.ChildNodes)
                {
                    Console.Write(childNode.Value + " ");
                }
                Console.WriteLine();
                foreach (var childNode in node.ChildNodes)
                {
                    this.PrintNode(childNode);
                }
            }
            else
            {
                Console.WriteLine("null");
            }
        }

        public void GetFather()
        {
            Console.WriteLine("Type the value that you want the father:");
            var value = int.Parse(Console.ReadLine());

            if (rootNode.Value == value)
            {
                Console.WriteLine("Node is root");
            }
            else 
            {
                this.GetFather(rootNode, value, null);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private void GetFather(Node node, int value, Node father)
        {
            if (node.Value == value)
            {
                Console.WriteLine(string.Format("Father is: {0}", father.Value));
            }
            else
            {
                foreach (var child in node.ChildNodes)
                {
                    this.GetFather(child, value, node);
                }
            }
        }

        public void PrintMaxNodeValue()
        {
            var maxValue = this.GetMaxValue(rootNode);
            Console.WriteLine(string.Format("Max value: {0}", maxValue));

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public int GetMaxValue(Node node)
        {
            if (node.ChildNodes.Count == 0)
                return node.Value;
            var maxPath = 0;
            foreach (var child in node.ChildNodes)
            {
                var childValue = this.GetMaxValue(child);
                if (maxPath < childValue)
                    maxPath = childValue;
            }
            return maxPath;
        }

        public void GetMaxPath()
        {
            var node = this.GetMaxPathValue(rootNode);
            Console.Write(string.Format("{0} <- ", node.Value));
        }
        
        public Node GetMaxPathValue(Node node)
        {
            if (node.ChildNodes.Count == 0)
                return node;
            else
            {
                int maxPath = 0;
                var current = new Node(0);
                foreach (var child in node.ChildNodes)
                {
                    var nodeTemp = this.GetMaxPathValue(child);
                    if (maxPath < nodeTemp.Value)
                    {
                        current = nodeTemp;
                        maxPath = nodeTemp.Value;
                    }
                }
                Console.Write(string.Format("{0} <- ", current.Value));
                return current;
            }
        }
    }
}
