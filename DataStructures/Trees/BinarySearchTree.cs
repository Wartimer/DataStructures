using System;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private BinNode<T> _root;

        public BinNode<T> Root
        {
            get => _root; 
            set => _root = value;
        }

        public BinarySearchTree()
        {
            _root = null;
        }

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new BinNode<T>(value);;
            }
            else
            {
                var current = _root;
                while (true)
                {
                    if (value.CompareTo(current.Value) == 0)
                    {
                        return;
                    }
                    
                    if (value.CompareTo(current.Value) < 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new BinNode<T>(value);
                            return;
                        }

                        current = current.Left;

                    }
                    else if(value.CompareTo(current.Value) > 0)
                    {
                        if (current.Right == null)
                        {
                            current.Right = new BinNode<T>(value);
                            return;
                        }

                        current = current.Right;
                    }
                }
            }
            
        }

        public BinNode<T> Find(T value)
        {
            if (_root == null) return null;
            var current = _root;
            var found = false;
            while (current != null && !found)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else if (value.CompareTo(current.Value) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    found = true;
                }
            }
            if (!found) return null;
            return current;
        }
        
        public bool Contains(T value)
        {
            if (_root == null) return false;
            
            var current = _root;
            var found = false;
            while (current != null && !found)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else if (value.CompareTo(current.Value) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public List<BinNode<T>> BreadthFirstSearch()
        {
            var node = _root;
            var data = new List<BinNode<T>>();
            var queue = new Queue<BinNode<T>>();
           
            queue.Enqueue(node);
            
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                data.Add(node);
                if(node.Left != null) queue.Enqueue(node.Left);
                if(node.Right != null) queue.Enqueue(node.Right);
            }

            return data;
        }

        public List<BinNode<T>> DepthFirstSearchPreOrder()
        {
            var data = new List<BinNode<T>>();
            var current = _root;

            void Traverse(BinNode<T> node)
            {
                data.Add(node);
                if(node.Left != null) Traverse(node.Left);
                if(node.Right != null) Traverse(node.Right);
            }

            Traverse(current);
            return data;
        }

    }
}