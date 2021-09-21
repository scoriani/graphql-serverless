namespace intro
{
    public class Query
    {
        public Person GetPerson() => new Person("Luke Skywalker", 22);
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }
}
