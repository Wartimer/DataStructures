using System;

namespace DataStructures
{
    public class SinglyNode<T>
    {
        public SinglyNode(T data)
        {
            Data = data;
            Next = null;
        }
        
        public T Data { get; set; }
        public SinglyNode<T> Next { get; set; }
        
    }
}