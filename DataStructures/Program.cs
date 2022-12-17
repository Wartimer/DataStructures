using System;
using DataStructures.Trees;

namespace DataStructures
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      
      Console.WriteLine("SINGLY LINKED LIST");
      var myList = new MySinglyLinkedList<int>();
      
      myList.Push(1);
      myList.Push(2);
      myList.Push(3);
      myList.Push(4);
      myList.Push(5);
      myList.Push(6);
      myList.Push(7);
      myList.Push(8);
      
      // Console.WriteLine($"Count before unshifting {myList.Count}");
      //
      // Console.WriteLine($"The element is {myList.Get(5).Data}");
      //
      // Console.WriteLine($"The changed element is {myList.Get(2).Data}");
      //
      // Console.WriteLine($"The result of Insertion: {myList.Insert(324, 0).ToString()}");
      //
      // Console.WriteLine($"The inserted element is {myList.Get(0).Data}");
      //
      // Console.WriteLine($"The removed node value is: {myList.RemoveAt(2).Data}");
      //
      // Console.WriteLine($"Count after all operations {myList.Count}");

      Console.WriteLine("Before Reversing");
      foreach (var node in myList)
      {
        Console.WriteLine(node);
      }
      
      myList.ReverseList();
      Console.WriteLine();
      Console.WriteLine("After Reversing");
      foreach (var node in myList)
      {
        Console.WriteLine(node);
      }
      
      Console.WriteLine("DLL");

      var myDll = new DoublyLinkedList<int>();

      myDll.Push(23);
      myDll.Push(43);
      
      foreach (var node in myDll)
      {
        Console.WriteLine(node);
      }
      
      Console.WriteLine($"Popped item is: {myDll.Pop()}");
      Console.WriteLine($"Popped item is: {myDll.Pop()}");

      myDll.Unshift(342);
      myDll.Unshift(34);
      myDll.Unshift(36);
      
      foreach (var node in myDll)
      {
        Console.WriteLine(node);
      }
      
      Console.WriteLine($"DoublyNode Value: {myDll.Get(2).Data}");

      myDll.Set(24, 2);
      Console.WriteLine($"DoublyNode Value changed to: {myDll.Get(2).Data}");

      myDll.Insert(444, 2);
      
      Console.WriteLine($"DoublyNode Value added: {myDll.Get(2).Data}");
      
      Console.WriteLine($"DoublyNode Removed: {myDll.RemoveAt(2)}");

      var myStack = new MyStack<int>();

      myStack.Push(2);
      myStack.Push(3);
      myStack.Push(5);

      var item = myStack.Pop();
      
      Console.WriteLine($"Poped item: {item.Data}");

      var myQueue = new MyQueue<int>();

      myQueue.Enqueue(1);
      myQueue.Enqueue(2);
      myQueue.Enqueue(3);
      Console.WriteLine($"Dequeue: {myQueue.Dequeue().Data}");
      Console.WriteLine($"Dequeue: {myQueue.Dequeue().Data}");
      Console.WriteLine($"Dequeue: {myQueue.Dequeue().Data}");


      var tree = new BinarySearchTree<int>();

      tree.Insert(10);
      tree.Insert(6);
      tree.Insert(3);
      tree.Insert(8);
      tree.Insert(15);
      tree.Insert(20);

      var foundNode = tree.Find(26);
      
      if(foundNode != null)
        Console.WriteLine($"Found: {foundNode.Value}");
      else
      {
        Console.WriteLine("Node was not found");
      }

      foreach (var node in tree.BreadthFirstSearch())
      {
          Console.Write(node.Value +", ");
      }
      
      Console.ReadLine();
    }
  }
}