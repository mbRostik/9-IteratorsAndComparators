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

    class Person : IComparer<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string temp)
        {
            string temp2;

            temp2 = "";
            FindWord(ref temp, ref temp2);
            Name = temp2;

            temp2 = "";
            FindWord(ref temp, ref temp2);
            Age = int.Parse(temp2);



        }

        public int Compare(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }

        public int Compare2(Person x, Person y)
        {
            return x.Age - y.Age;
        }

        public void SortName(ref List<Person> all)
        {
            for (int i = 0; i < all.Count - 1; i++)
            {
                for (int j = i + 1; j < all.Count; j++)
                {
                    if (all[i].Name.Length < all[j].Name.Length)
                    {

                    }
                    else if (all[i].Name.Length > all[j].Name.Length)
                    {
                        Person temp = all[i];
                        all[i] = all[j];
                        all[j] = temp;
                    }
                    else if (Compare(all[i], all[j]) > 0)
                    {
                        Person temp = all[i];
                        all[i] = all[j];
                        all[j] = temp;
                    }
                }
            }

            foreach(Person x in all)
            {
                Console.WriteLine(x.Name + " "+x.Age);
            }
            Console.WriteLine();
        }

        public void SortAge(ref List<Person> all)
        {
            for (int i = 0; i < all.Count - 1; i++)
            {
                for (int j = i + 1; j < all.Count; j++)
                {
                    if (all[i].Age > all[j].Age)
                    {
                        Person temp = all[i];
                        all[i] = all[j];
                        all[j] = temp;
                    }
                }
            }
            foreach (Person x in all)
            {
                Console.WriteLine(x.Name + " " + x.Age);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        List<Person> all = new List<Person>();
        while (true)
        {
            string a = Console.ReadLine();
            if (a == "END")
                break;

            all.Add(new Person(a));
        }

        all[0].SortName(ref all);
        Console.WriteLine();
        all[0].SortAge(ref all);
    }
}
