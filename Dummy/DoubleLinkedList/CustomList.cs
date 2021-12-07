using Dummy.DoubleLinkedList.Model;
using System;

namespace Dummy.DoubleLinkedList
{
    public class CustomList<T> where T : class, IDisposable
    {
        int _count;
        Node<T>? startNode = null;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        private void CreateNewNode(T item)
        {
            Node<T> temp = new Node<T>(item);
            startNode = temp;
        }

        public CustomList(T item)
        {
            CreateNewNode(item);
            _count = 1;
        }

        public void AddNode(T item)
        {
            if (startNode == null)
            {
                CreateNewNode(item);
                _count++;
                return;
            }
            Node<T>? temp = startNode;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            Node<T> newNode = new Node<T>(item);
            temp.Next = newNode;
            newNode.Prev = temp;
            _count++;
        }

        public void AddAtStart(T item)
        {
            if (startNode == null)
            {
                CreateNewNode(item);
            }
            else
            {
                Node<T> temp = new Node<T>(item);
                temp.Next = startNode;
                startNode.Prev = temp;
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
            else if (startNode.Next == null)
            {
                itemDeleted = startNode.Item;
                startNode = null;
            }
            else
            {
                Node<T>? temp = startNode;
                while (temp.Next?.Next != null)
                {
                    temp = temp.Next;
                }
                itemDeleted = temp?.Next?.Item;
                temp.Next = null;
            }
            _count--;
            return itemDeleted;
        }

        public T? RemoveSpecificNode(T item, Func<T?, T?, int> comparer)
        {
            T? itemDeleted = null;
            if (startNode == null)
            {
                throw new Exception("Cannot remove from an empty list");
            }
            if (startNode.Next == null && comparer(startNode.Item, item) == 0)
            {
                itemDeleted = startNode.Item;
                startNode = null;
            }
            else
            {
                Node<T>? temp = startNode;
                bool flag = false;
                while (temp.Next != null)
                {
                    if (comparer(temp.Item, item) == 0)
                    {
                        flag = true;
                        break;
                    }
                    temp = temp.Next;
                }

                if (flag)
                {
                    itemDeleted = temp.Item;
                    if (temp.Prev != null && temp.Next != null)
                    {
                        temp.Next.Prev = temp.Prev;
                        temp.Prev.Next = temp.Next;
                    }
                    else if(temp.Prev == null && temp.Next!=null)
                    {
                        temp.Next.Prev = null;
                        startNode = temp.Next;
                    }
                    else if(temp.Prev != null && temp.Next==null)
                    {
                        temp.Prev.Next = null;
                    }
                }
                else
                {
                    if(comparer(temp.Item, item) == 0)
                    {
                        itemDeleted = temp.Item;
                        temp.Prev.Next = null;
                    }
                }

                /*Node<T>? temp = startNode;
                startNode = temp.Next;
                startNode.Prev = null;
                itemDeleted = temp.Item;
                temp = null;*/
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
            if (startNode.Next == null)
            {
                itemDeleted = startNode.Item;
                startNode = null;
            }
            else
            {
                Node<T>? temp = startNode;
                startNode = temp.Next;
                startNode.Prev = null;
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

            while (temp?.Next != null)
            {
                System.Console.Write($"{temp.Item?.ToString()} ==> ");
                temp = temp.Next;
            }
            System.Console.WriteLine(temp?.Item?.ToString());
            System.Console.WriteLine();
        }

        public void DisplayFromEnd()
        {

            if (startNode == null)
            {
                System.Console.WriteLine("List is emptys");
            }
            Node<T>? temp = startNode;
            while (temp?.Next != null)
            {
                temp = temp.Next;
            }

            while (temp?.Prev != null)
            {
                System.Console.Write($"{temp.Item?.ToString()} ==> ");
                temp = temp.Prev;
            }
            System.Console.WriteLine(temp?.Item?.ToString());
            System.Console.WriteLine();
        }

        public void BubbleSort(Func<T?, T?, int> comparer)
        {
            if (startNode == null || startNode.Next == null)
            {
                return;
            }

            Node<T> temp = startNode;

            while (temp?.Next?.Next != null)
            {
                for (Node<T> i = temp.Next; i.Next != null; i = i.Next)
                {
                    if (comparer(temp.Item, i.Item) == 1)
                    {
                        T? swapper = temp.Item;
                        temp.Item = i.Item;
                        i.Item = swapper;
                    }
                }
                temp = temp.Next;
            }
        }

        public void Dispose()
        {
            startNode = null;
        }
    }
}