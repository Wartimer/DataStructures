using System.Net;

namespace DataStructures
{
    public class MyStack<T>
    {
        private SinglyNode<T> _first;
        private SinglyNode<T> _last;
        private int _count;

        public SinglyNode<T> First => _first;
        public SinglyNode<T> Last => _last;
        public int Count => _count;        
        public MyStack()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        public int Push(T data)
        {
            var newNode = new SinglyNode<T>(data);
            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                var temp = _first;
                _first = newNode;
                _first.Next = temp;
            }

            return ++_count;
        }

        public SinglyNode<T> Pop()
        {
            if (_first == null) return null;
            
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