using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T> _head; 
        DoublyNode<T> _tail; 
        int _count;

        public DoublyNode<T> Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();
            
            var mid = _count / 2;
            DoublyNode<T> current;
            int counter;
            
            if (index <= mid)
            {
                current = _head;
                counter = 0;
                while (counter != index)
                {
                    current = current.Next;
                    counter++;
                }
            }
            else
            {
                current = _tail;
                counter = _count-1;
                while (counter != index)
                {
                    current = current.Previous;
                    counter--;
                }
            }
            return current;
        }

        public bool Set(T data, int index)
        {
            var node = Get(index);
            if (node == null) return false;
            node.Data = data;
            return true;
        }


        public DoublyLinkedList<T> Push(T data)
        {
            var newNode = new DoublyNode<T>(data);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }
            _count++;
            return this;
        }

        public T Pop()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            var removedTail = _tail;
            
            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail = removedTail.Previous;
                _tail.Next = null;
                removedTail.Previous = null;
            }
            _count--;
            return removedTail.Data;
        }
        
        public bool Insert(T data, int index)
        {
            if (index < 0 || index > _count) return false;
            if (index == 0)
            {
                Unshift(data);
                return true;
            }
            if (index == _count)
            {
                Push(data);
                return true;
            }

            var node = Get(index - 1);
            var newNode = new DoublyNode<T>(data);
            
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            node.Next = newNode;
            newNode.Previous = node;
            _count++;
            return true;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0)
            {
                return Shift();
            }
            if (index == _count-1)
            {
                return Pop();
            }
            var nodeToRemove = Get(index);
            var nodeAfter = nodeToRemove.Next;
            var nodeBefore = nodeToRemove.Previous;
            nodeBefore.Next = nodeAfter;
            nodeAfter.Previous = nodeBefore;
            nodeToRemove.Previous = null;
            nodeToRemove.Next = null;
            _count--;
            return nodeToRemove.Data;
        }
        
        public T Shift()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Collection is empty");
            }

            var removedHead = _head;
            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = removedHead.Next;
                _head.Previous = null;
                removedHead.Next = null;
            }
            _count--;
            return removedHead.Data;
        }

        public DoublyLinkedList<T> Unshift(T data)
        {
            var newNode = new DoublyNode<T>(data);

            if (_count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _head.Previous = newNode;
                newNode.Next = _head;
                _head = newNode;
            }

            _count++;
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
 
        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = _tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}