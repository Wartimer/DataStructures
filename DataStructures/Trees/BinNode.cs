using System;
using System.Dynamic;

namespace DataStructures.Trees
{
    public class BinNode<T> where T : IComparable
    {
        private T _value;
        private BinNode<T> _left;
        private BinNode<T> _right;

        public T Value
        {
            get => _value;
            set => _value = value;
        }
        public BinNode<T> Left
        {
            get => _left;
            set => _left = value;
        }

        public BinNode<T> Right
        {
            get => _right;
            set => _right = value;
        }

        public BinNode(T value)
        {
            _value = value;
            _left = null;
            _right = null;
        }
    }
}