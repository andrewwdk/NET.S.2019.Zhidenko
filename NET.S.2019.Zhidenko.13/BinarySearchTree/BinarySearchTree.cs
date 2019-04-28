using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T>
    {
        private Node<T> rootNode;

        private IComparer<T> comparer;

        public BinarySearchTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            comparer = Comparer<T>.Default;

            foreach (T element in array)
            {
                Insert(element);
            }
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException();
        }

        public BinarySearchTree(IComparer<T> comparer, T[] array)
        {
            this.comparer = comparer ?? throw new ArgumentNullException();

            if (array == null)
            {
                throw new ArgumentNullException();
            }

            foreach (T element in array)
            {
                Insert(element);
            }
        }

        /// <summary> Insert element into binary tree.</summary>
        /// <param name="value"> Element to insert. </param>
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (rootNode == null)
            {
                rootNode = new Node<T>(value);
            }
            else
            {
                Insert(rootNode, value);
            }
        }

        /// <summary> Find element in binary tree.</summary>
        /// <param name="value"> Element to find. </param>
        /// <returns> Search result. </returns>
        public bool Find(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (rootNode == null)
            {
                return false;
            }
            else
            {
                return Find(rootNode, value);
            }
        }

        /// <summary> Preorder traversing of binary tree.</summary>
        /// <returns> Elements by preorder traversing. </returns>
        public IEnumerable<T> PreorderTraversing()
        {
            return PreorderTraversing(rootNode);
        }

        /// <summary> Inorder traversing of binary tree.</summary>
        /// <returns> Elements by inorder traversing. </returns>
        public IEnumerable<T> InorderTraversing()
        {
            return InorderTraversing(rootNode);
        }

        /// <summary> Postorder traversing of binary tree.</summary>
        /// <returns> Elements by postorder traversing. </returns>
        public IEnumerable<T> PostorderTraversing()
        {
            return PostorderTraversing(rootNode);
        }

        /// <summary> Preorder traversing of binary tree.</summary>
        /// <param name="node"> Current node. </param>
        /// <returns> Elements by preorder traversing. </returns>
        private IEnumerable<T> PreorderTraversing(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            else
            {
                yield return node.Value;

                foreach (T element in PreorderTraversing(node.LeftNode))
                {
                    yield return element;
                }

                foreach (T element in PreorderTraversing(node.RightNode))
                {
                    yield return element;
                }
            }
        }

        /// <summary> Inorder traversing of binary tree.</summary>
        /// <param name="node"> Current node. </param>
        /// <returns> Elements by inorder traversing. </returns>
        private IEnumerable<T> InorderTraversing(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            else
            {
                foreach (T element in InorderTraversing(node.LeftNode))
                {
                    yield return element;
                }

                yield return node.Value;

                foreach (T element in InorderTraversing(node.RightNode))
                {
                    yield return element;
                }
            }
        }

        /// <summary> Postorder traversing of binary tree.</summary>
        /// <param name="node"> Current node. </param>
        /// <returns> Elements by postorder traversing. </returns>
        private IEnumerable<T> PostorderTraversing(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            else
            {
                foreach (T element in PostorderTraversing(node.LeftNode))
                {
                    yield return element;
                }

                foreach (T element in PostorderTraversing(node.RightNode))
                {
                    yield return element;
                }

                yield return node.Value;
            }
        }

        /// <summary> Insert element into binary tree.</summary>
        /// <param name="value"> Element to insert. </param>
        /// <param name="node"> Current node. </param>
        private void Insert(Node<T> node, T value)
        {
            if (comparer.Compare(node.Value, value) == 0)
            {
                node.Value = value;
            }
            else
            {
                if (comparer.Compare(value, node.Value) < 0)
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new Node<T>(value);
                    }
                    else
                    {
                        Insert(node.LeftNode, value);
                    }
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        node.RightNode = new Node<T>(value);
                    }
                    else
                    {
                        Insert(node.RightNode, value);
                    }
                }
            }
        }

        /// <summary> Find element in binary tree.</summary>
        /// <param name="value"> Element to find. </param>
        /// <param name="node"> Current node. </param>
        /// <returns> Search result. </returns>
        private bool Find(Node<T> node, T value)
        {
            if (comparer.Compare(node.Value, value) == 0)
            {
                return true;
            }
            else
            {
                if (comparer.Compare(value, node.Value) < 0)
                {
                    if (node.LeftNode == null)
                    {
                        return false;
                    }
                    else
                    {
                        return Find(node.LeftNode, value);
                    }
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        return false;
                    }
                    else
                    {
                        return Find(node.RightNode, value);
                    }
                }
            }
        }
    }
}
