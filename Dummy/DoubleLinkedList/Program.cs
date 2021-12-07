namespace Dummy.DoubleLinkedList
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (x?.Id == y?.Id)
                return 0;
            else if (x?.Id > y?.Id)
                return 1;
            else
                return -1;
        }
    }
    public class Person : IDisposable
    {

        public int Id { get; set; }

        public Person()
        {
            Id = 0;
        }       

        public Person(int id)
        {
            Id = id;
        }


        public override string ToString()
        {
            return $"{Id}";
        }

        public void Dispose()
        {
            GC.Collect();
        }


    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomList<Person> list = new CustomList<Person>(new Person(1));
            list.AddNode(new Person(6));
            list.AddNode(new Person(7));
            list.AddAtStart(new Person(8));
            list.AddAtStart(new Person(18));
            list.AddAtStart(new Person(28));
            System.Console.WriteLine($"Current Count : {list.Count}");
            list.Display();
            list.DisplayFromEnd();
            list.RemoveNode();
            System.Console.WriteLine($"Current Count : {list.Count}");
            list.Display();
            list.DisplayFromEnd();
            list.RemoveNodeFromStart();            
            System.Console.WriteLine($"Current Count : {list.Count}");
            list.Display();
            list.DisplayFromEnd();
            list.RemoveSpecificNode(new Person(8), new PersonComparer().Compare);
            list.Display();
            list.RemoveSpecificNode(new Person(18), new PersonComparer().Compare);
            list.Display();
            list.RemoveSpecificNode(new Person(6), new PersonComparer().Compare);
            list.Display();
        }
    }
}
