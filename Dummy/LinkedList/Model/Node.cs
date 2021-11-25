namespace Dummy.LinkedList.Model
{
    public class Node<T> where T : class
    {
        private T? _item;
        public T? Item
        {
            get
            {
                return _item;
            }  
            set{
                _item = value;
            }         
        }
        public Node<T>? node;

        public Node(T item)
        {
            _item = item;
            node = null;
        }

        public Node()
        {
            _item = null;
            node = null;
        }

    }
}