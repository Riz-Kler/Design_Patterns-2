using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{ 

    namespace Coding.Exercise
    {
        public class Node<T>
        {
            public T Value;
            public Node<T> Left, Right;
            public Node<T> Parent;

            public Node(T value)
            {
                Value = value;
            }

            public Node(T value, Node<T> left, Node<T> right)
            {
                Value = value;
                Left = left;
                Right = right;

                left.Parent = right.Parent = this;
            }

            public IEnumerable<T> GetPreOrder()
            {// inner method
                IEnumerable<Node<T>> Traverse(Node<T> currentNode)
                {
                    yield return currentNode;                                  //  1st           1
                                                                               //               / \
                    if (currentNode.Left != null)                             //               /   \
                    {                                                           //            /     \
                        foreach (var left in Traverse(currentNode.Left))      //             /       \    
                            yield return left;                                     //    2nd    2         \               
                    }                                                            //                    \
                                                                                 //                     \
                    if (currentNode.Right != null)                               //                      \
                    {                                                            //                       \
                        foreach (var right in Traverse(currentNode.Right))      //                         \    
                            yield return right;                                     //    3rd               3               
                    }
                }
                foreach (var node in Traverse(Parent))
                    yield return node.Value;
            }
        }
    }

}
