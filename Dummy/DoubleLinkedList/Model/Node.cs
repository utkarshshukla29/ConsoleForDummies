namespace Dummy.DoubleLinkedList.Model
{
    public class Node<T> where T : class
    {
        private T? _item;

        private Node<T>? _start;

        private Node<T>? _end;
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
        public Node<T>? Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        public Node<T>? End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        public Node(T item)
        {
            _item = item;
            _start = null;
            _end = null;
        }

        public Node()
        {
            _item = null;
            _start = null;
            _end = null;
        }

    }
}