using System;

class Person
{
    private string name;
    private DateTime birthYear;

    public string Name => name;
    public DateTime BirthYear => birthYear;

    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    public void Input()
    {
        Console.Write("Введіть ім'я: ");
        name = Console.ReadLine();

        Console.Write("Введіть рік народження (рррр): ");
        int year = Convert.ToInt32(Console.ReadLine());
        birthYear = new DateTime(year, 1, 1);
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Ім'я: {name}, Рік народження: {birthYear.Year}, Вік: {Age()}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person p1, Person p2)
    {
        return p1?.name == p2?.name;
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Person person)
            return this == person;
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode() ^ birthYear.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[6];
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"\nВведення даних для особи {i + 1}:");
            people[i] = new Person();
            people[i].Input();
        }

        Console.WriteLine("\nІнформація про осіб:");
        foreach (Person person in people)
        {
            Console.WriteLine($"Ім'я: {person.Name}, Вік: {person.Age()}");
        }

        Console.WriteLine("\nОсоби з віком менше 16 років змінюють ім'я на 'Very Young':");
        foreach (Person person in people)
        {
            if (person.Age() < 16)
                person.ChangeName("Very Young");
        }

        Console.WriteLine("\nОновлена інформація про всіх осіб:");
        foreach (Person person in people)
        {
            person.Output();
        }

        Console.WriteLine("\nОсоби з однаковими іменами:");
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    people[i].Output();
                    people[j].Output();
                }
            }
        }
    }
}
