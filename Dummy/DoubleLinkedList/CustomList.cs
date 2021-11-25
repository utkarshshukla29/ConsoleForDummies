using Dummy.DoubleLinkedList.Model;
using System;

namespace Dummy.DoubleLinkedList
{
    public class CustomList<T> where T : class, IDisposable
    {
        int _count;
        Node<T>? startNode = null;
        Node<T>? endNode = null;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public CustomList(T item)
        {
            Node<T> temp = new Node<T>(item);
            _count = 1;
            startNode = temp;
            endNode = temp;
        }

        public void AddNode(T item)
        {
            if (startNode == null)
            {
                startNode = new Node<T>(item);
                endNode = startNode;
                _count++;
                return;
            }
            Node<T>? temp = startNode;
            while (temp.Start != null)
            {
                temp = temp.Start;
            }
            temp.Start = new Node<T>(item);
            temp.Start.End = temp;
            endNode = temp.Start;
            endNode.Start = temp;
            _count++;
        }

        public void AddAtStart(T item)
        {
            if (startNode == null)
            {
                startNode = new Node<T>(item);
            }
            else
            {
                Node<T> temp = new Node<T>(item);
                temp.Start = startNode;
                startNode = temp;
            }
            _count++;
        }

        public T? RemoveNode()
        {
            T? itemDeleted = null;
            if (startNode == null)
            {
                throw new Exception("Cannot remove from an empty list");
            }
            else if (startNode.Start == null)
            {
                itemDeleted = startNode.Item;
                startNode = null;
            }
            else
            {
                Node<T>? temp = startNode;
                while (temp.Start?.Start != null)
                {
                    temp = temp.Start;
                }
                itemDeleted = temp?.Start?.Item;
                temp.Start = null;
            }
            _count--;
            return itemDeleted;
        }

        public T? RemoveNodeFromStart()
        {
            T? itemDeleted = null;
            if (startNode == null)
            {
                throw new Exception("Cannot remove from an empty list");
            }
            if (startNode.Start == null)
            {
                itemDeleted = startNode.Item;
                startNode = null;
            }
            else
            {
                Node<T>? temp = startNode;
                startNode = startNode.Start;
                itemDeleted = temp.Item;
                temp = null;
            }
            _count--;
            return itemDeleted;
        }

        public void Display()
        {
            if (startNode == null)
            {
                System.Console.WriteLine("No item in list");
            }
            Node<T>? temp = startNode;

            while (temp?.Start != null)
            {
                System.Console.WriteLine($"{temp.Item?.ToString()} ==> ");
                temp = temp.Start;
            }
            System.Console.WriteLine(temp?.Item?.ToString());
            System.Console.WriteLine();
        }

        // public void BubbleSort(Func<T?, T?, int> comparer)
        // {
        //     if (startNode == null || startNode.Start == null)
        //     {
        //         return;
        //     }

        //     Node<T> temp = startNode;

        //     while (temp?.Start?.Start != null)
        //     {
        //         for (Node<T> i = temp.Start; i.Start != null; i = i.Start)
        //         {
        //             if (comparer(temp.Item, i.Item) == 1)
        //             {
        //                 T? swapper = temp.Item;
        //                 temp.Item = i.Item;
        //                 i.Item = swapper;
        //             }
        //         }
        //         temp = temp.Start;
        //     }
        // }

        public void Dispose()
        {
            startNode = null;
        }
    }
}