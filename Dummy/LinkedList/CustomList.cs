using Dummy.LinkedList.Model;
using System;

namespace Dummy.LinkedList
{
    public class CustomList<T> where T : class, IDisposable
    {
        int _count;
        Node<T>? start = null;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public CustomList(T item)
        {
            start = new Node<T>(item);
            _count = 1;
        }

        public void AddNode(T item)
        {
            if (start == null)
            {
                start = new Node<T>(item);
                _count++;
                return;
            }
            Node<T>? temp = start;
            while (temp.node != null)
            {
                temp = temp.node;
            }
            temp.node = new Node<T>(item);
            _count++;
        }

        public void AddAtStart(T item)
        {
            if (start == null)
            {
                start = new Node<T>(item);
            }
            else
            {
                Node<T> temp = new Node<T>(item);
                temp.node = start;
                start = temp;
            }
            _count++;
        }

        public T? RemoveNode()
        {
            T? itemDeleted = null;
            if (start == null)
            {
                throw new Exception("Cannot remove from an empty list");
            }
            else if (start.node == null)
            {
                itemDeleted = start.Item;
                start = null;
            }
            else
            {
                Node<T>? temp = start;
                while (temp.node?.node != null)
                {
                    temp = temp.node;
                }
                itemDeleted = temp?.node?.Item;
                temp.node = null;
            }
            _count--;
            return itemDeleted;
        }

        public T? RemoveNodeFromStart()
        {
            T? itemDeleted = null;
            if (start == null)
            {
                throw new Exception("Cannot remove from an empty list");
            }
            if (start.node == null)
            {
                itemDeleted = start.Item;
                start = null;
            }
            else
            {
                Node<T>? temp = start;
                start = start.node;
                itemDeleted = temp.Item;
                temp = null;
            }
            _count--;
            return itemDeleted;
        }

        public void Display()
        {
            if (start == null)
            {
                System.Console.WriteLine("No item in list");
            }
            Node<T>? temp = start;

            while (temp?.node != null)
            {
                System.Console.WriteLine($"{temp.Item?.ToString()} ==> ");
                temp = temp.node;
            }
            System.Console.WriteLine(temp?.Item?.ToString());
            System.Console.WriteLine();
        }

        public void BubbleSort(Func<T?, T?, int> comparer)
        {
            if (start == null || start.node == null)
            {
                return;
            }

            Node<T> temp = start;

            while (temp?.node?.node != null)
            {
                for (Node<T> i = temp.node; i.node != null; i = i.node)
                {
                    if (comparer(temp.Item, i.Item) == 1)
                    {
                        T? swapper = temp.Item;
                        temp.Item = i.Item;
                        i.Item = swapper;
                    }
                }
                temp = temp.node;
            }
        }

        public void Dispose()
        {
            start = null;
        }
    }
}