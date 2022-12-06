using System;
using System.Collections;
using System.Collections.Generic;
internal class Program
{
    static void FindWord(ref string v, ref string temp)
    {
        string b = "";
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == ' ')
            {
                v = v.Remove(i, 1);
                break;
            }
            else
            {
                b += v[i];
                v = v.Remove(i, 1);
                i--;
            }
        }
        temp = b;
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string temp)
        {
            string temp2 = "";

            FindWord(ref temp, ref temp2);
            Town = temp2;

            temp2 = "";
            FindWord(ref temp, ref temp2);
            Age = int.Parse(temp2);

            temp2 = "";
            FindWord(ref temp, ref temp2);
            Name = temp2;
            
        }
    }

    class People : IComparable<Person>
    {

        List<Person> list=new List<Person>();

        public int Count { get => list.Count; }
        public void Create(string a)
        {
            list.Add(new Person(a));
        }

        public int CompareTo(Person obj)
        {
            Person a = obj as Person;
            int kol = 0;
            foreach (Person b in list)
            {
                if (b.Name == a.Name && b.Age == a.Age && b.Town == a.Town)
                {
                    kol++;
                }
            }
            return kol;
        }

        public void Compare(int i)
        {
            i--;

            if (CompareTo(list[i]) <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(CompareTo(list[i]) + " " + (list.Count - CompareTo(list[i])) + " " + list.Count);
            }
        }
    }

    static void Main()
    {
        People all = new People();

        while (true)
        {
            string a = Console.ReadLine();

            if (a == "END")
                break;

            all.Create(a);
        }

        int i = int.Parse(Console.ReadLine());

        all.Compare(i);
    }
}
