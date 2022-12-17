using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class MySinglyLinkedList<T> : IEnumerable<T> where T : IComparable
    {
        SinglyNode<T> _head; 
        SinglyNode<T> _tail; 
        int _count;

        public int Count { get { return _count; } }
        public bool IsEmpty { get { return _count == 0; } }
        
        public MySinglyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        
        public MySinglyLinkedList<T> Push(T data)
        {
            SinglyNode<T> singlyNode = new SinglyNode<T>(data);
 
            if (_head == null)
                _head = singlyNode;
            else
                _tail.Next = singlyNode;
            _tail = singlyNode;
 
            _count++;
            return this;
        }
        
        public bool Remove(T data)
        {
            SinglyNode<T> current = _head;
            SinglyNode<T> previous = null;
 
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
 
                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            _tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        _head = _head.Next;
 
                        // если после удаления список пуст, сбрасываем tail
                        if (_head == null)
                            _tail = null;
                    }
                    _count--;
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public SinglyNode<T> RemoveAt(int index)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == _count - 1)
            {
                return Pop();
            }
            if (index == 0)
            {
                return Shift();
            }

            var prevNode = Get(index - 1);
            var remevedNode = prevNode.Next;
            prevNode.Next = remevedNode.Next;
            _count--;
            return remevedNode;
        }
        
        public SinglyNode<T> Pop()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Collection is empty");
            }
            
            var current = _head;
            var newTail = current;

            while (current.Next != null)
            {
                newTail = current;
                current = current.Next;
            }

            _tail = newTail;
            _tail.Next = null;
            _count--;
            
            if (_count == 0)
            {
                _head = null;
                _tail = null;
            }
            
            return current;
        }

        public SinglyNode<T> Shift()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Collection is empty");
            }

            var currentHead = _head;
            _head = currentHead.Next;
            _count--;
            if (_count == 0)
            {
                _tail = null;
            }
            return currentHead;
        }

        public MySinglyLinkedList<T> UnShift(T data)
        {
            var newNode = new SinglyNode<T>(data);
            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
                
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }

            _count++;
            return this;
        }

        public SinglyNode<T> Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                return null;
            }
            if (_head == null)
            {
                throw new NullReferenceException("Collection is empty");
            }
            
            var current = _head;
            var counter = 0;
            
            while (counter != index)
            {
                current = current.Next;
                counter++;
            }

            return current;
        }

        public MySinglyLinkedList<T> ReverseList()
        {
            var node = _head;
            _head = _tail;
            _tail = node;
            SinglyNode<T> next;
            SinglyNode<T> prev = null;
            for (int i = 0; i < _count ; i++)
            {
                next = node.Next;
                node.Next = prev;
                prev = node;
                node = next;
            }

            return this;
        }
        
        public bool Insert(T data, int index)
        {
            if (index < 0 || index > _count)
            {
                return false;
            }
            if(index == _count) return Push(data) != null;
            if (index == 0) return UnShift(data) != null;

            var newNode = new SinglyNode<T>(data);
            var prevNode = Get(index - 1);
            
            var tempNode = prevNode.Next;
            prevNode.Next = newNode;
            newNode.Next = tempNode;
            
            _count++;
            return true;
        }        
        
        public bool Set(T data, int index)
        {
            var node = Get(index);
            if (node == null) return false;
            node.Data = data;
            return true;
        }
        
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
       
        public bool Contains(T data)
        {
            SinglyNode<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
       
        public void AppendFirst(T data)
        {
            SinglyNode<T> singlyNode = new SinglyNode<T>(data);
            singlyNode.Next = _head;
            _head = singlyNode;
            if (_count == 0)
                _tail = _head;
            _count++;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SinglyNode<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}