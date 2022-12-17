using System;

namespace DataStructures
{
    public class MyQueue<T> where T : IComparable
    {
        private SinglyNode<T> _first;
        private SinglyNode<T> _last;
        private int _count;

        public SinglyNode<T> First => _first;
        public SinglyNode<T> Last => _last;
        public int Count => _count;
        
        public MyQueue()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        public int Enqueue(T data)
        {
            var newNode = new SinglyNode<T>(data);
            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                _last = newNode;
            }

            return ++_count;
        }
        
        public SinglyNode<T> Dequeue()
        {
            if(_first == null) return null;
            var temp = _first;
            if (_first == _last)
            {
                _last = null;
            }

            _first = _first.Next;
            _count--;
            return temp;
        }
    }
}