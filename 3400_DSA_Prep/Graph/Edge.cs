using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep
{
    public class Edge<T>
    {
        public Node<T> From { get; set; }
        public Node<T> To { get; set; }
        public double Weight { get; set; }

        public Edge(Node<T> aNode, Node<T> otherNode, double aWeight = 1)
        {
            if (aNode == null || otherNode == null)
            {
                throw new ArgumentNullException("Edge created with a null node");
            }

            From = aNode;
            To = otherNode;
            Weight = aWeight;
        }

        public void Remove()
        {
            List<Edge<T>> aList = From.OutEdges;
            aList.Remove(this);
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Edge<T> otherEdge = obj as Edge<T>;
            if ((System.Object)otherEdge == null)
            {
                return false;
            }
            else
                return (this.Equals(otherEdge) == true); // Call the other version of Equals
        }

        public bool Equals(Edge<T> otherEdge)
        {
            // If parameter is null return false:
            if ((object)otherEdge == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Weight == otherEdge.Weight && From.Equals(otherEdge.From) == true && To.Equals(otherEdge.To) == true);
        }

        public override int GetHashCode()
        {
            return Weight.GetHashCode() + From.GetHashCode() + To.GetHashCode();
        }
    }
}