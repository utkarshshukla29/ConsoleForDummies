// See https://aka.ms/new-console-template for more information
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
       // public string Name { get; set; }

        public int Id { get; set; }

        public Person()
        {
        //    Name = string.Empty;
            Id = 0;
        }

        // public Person(string name, int id)
        // {
        //     Name = name;
        //     Id = id;
        // }

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
            list.Display();
        }
    }
}
