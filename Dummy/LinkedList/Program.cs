// See https://aka.ms/new-console-template for more information
namespace Dummy.LinkedList
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
        public string Name { get; set; }

        public int Id { get; set; }

        public Person()
        {
            Name = string.Empty;
            Id = 0;
        }

        public Person(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return $"Name : {Name} with Id {Id}";
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
            CustomList<Person> list = new CustomList<Person>(new Person("qwerty", 1));
            list.AddNode(new Person("sdsd", 8));
            list.AddNode(new Person("Aditi", 3));
            list.AddNode(new Person("Jayati", 14));
            list.AddNode(new Person("Aysuh", 5));
            list.AddNode(new Person("Utkarsh", 6));
            list.Display();
            System.Console.WriteLine($"Current Count : {list.Count}");
            System.Console.WriteLine($"Item deleted {list.RemoveNode()}");
            System.Console.WriteLine($"Item deleted {list.RemoveNode()}");
            System.Console.WriteLine($"Current Count : {list.Count}");
            list.Display();
            System.Console.WriteLine($"Item deleted {list.RemoveNodeFromStart()}");
            list.AddAtStart(new Person("Savita", 6));
            list.Display();
            System.Console.WriteLine($"Current Count : {list.Count}");
            list.BubbleSort(new PersonComparer().Compare);
            list.Display();
        }
    }
}
