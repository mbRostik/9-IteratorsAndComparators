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

    class ListyIterator<T>
    {
        private List<T> all = new List<T>();
        int index = 0;

        public void Create(List<T> a)
        {
            for (int i = 0; i != a.Count; i++)
            {

                all.Add(a[i]);
            }
        }


        public bool Move()
        {
            if (index < all.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            Console.WriteLine(all[index]);
        }

        public bool HasNext()
        {
            if (index+1 < all.Count - 1)
            {
                return true;
            }
            return false;
        }
    }
    static void Main()
    {
        ListyIterator<string> all = new ListyIterator<string>();
        while (true)
        {
            string t = Console.ReadLine();
            string temp = "";
            FindWord(ref t, ref temp);
            if (temp == "Create")
            {

                if (t == "" || t == " ")
                {
                    Console.WriteLine("Invalid!");
                    break;
                }
                all = new ListyIterator<string>();
                List<string> a = new List<string>();
                while (true)
                {
                    if (t == "" || t == " ")
                    {
                        break;
                    }
                    FindWord(ref t, ref temp);
                    a.Add(temp);
                }

                all.Create(a);
            }

            else if (temp == "Print")
            {
                if (all==null)
                {
                    Console.WriteLine("Invalid!");
                    break;
                }
                all.Print();
            }
            else if (temp == "HasNext")
            {
                Console.WriteLine(all.HasNext());
            }
            else if (temp == "Move")
            {
                Console.WriteLine(all.Move());
            }
            else if (temp == "END")
            {
                break;
            }
        }

    }
}
