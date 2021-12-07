namespace Dummy.DoubleLinkedList.Model
{
    public class Node<T> where T : class
    {
        private T? _item;

        private Node<T>? _next;

        private Node<T>? _prev;
        public T? Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }
        public Node<T>? Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }

        public Node<T>? Prev
        {
            get
            {
                return _prev;
            }
            set
            {
                _prev = value;
            }
        }

        public Node(T item)
        {
            _item = item;
            _next = null;
            _prev = null;
        }

        public Node()
        {
            _item = null;
            _next = null;
            _prev = null;
        }

    }
}