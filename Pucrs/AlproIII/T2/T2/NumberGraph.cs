using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    public class NumberGraph
    {
        private List<NumberNode> nodes;

        public NumberGraph()
        {
            this.nodes = new List<NumberNode>();
        }

        public void Insert(BasedNumber number)
        {
            var newNode = new NumberNode(number);
            nodes.Add(newNode);

            foreach (var num in nodes)
            {
                if (RuleVerifier.IsInRule(num.Number, newNode.Number))
                {
                    if (num.Number >= newNode.Number)
                    {
                        newNode.LinkedNumbers.Add(num);
                    }
                    else
                    {
                        num.LinkedNumbers.Add(newNode);
                    }
                }
            }
        }

        public IEnumerable<BasedNumber> GetBiggestPath()
        {
            var biggestPath = new List<BasedNumber>();

            foreach (var node in nodes)
            {
                var nodePath = this.GetBiggestPath(node);
                if (nodePath.Count() > biggestPath.Count)
                    biggestPath = nodePath.ToList();
            }

            return biggestPath;
        }

        private IEnumerable<BasedNumber> GetBiggestPath(NumberNode node)
        {
            var path = new List<BasedNumber>() 
            {
                node.Number
            };

            var pathSteps = 0;
            var biggestPath = new List<BasedNumber>();

            foreach (var linkedNode in node.LinkedNumbers)
            {
                var linkedPath = this.GetBiggestPath(linkedNode);
                if (linkedPath.Count() > pathSteps)
                {
                    biggestPath = linkedPath.ToList();
                    pathSteps = biggestPath.Count;
                }
            }

            if (biggestPath.Any())
                path.AddRange(biggestPath);

            return path;
        }

        public void Destroy()
        {
            this.nodes = new List<NumberNode>();
        }
    }
}
