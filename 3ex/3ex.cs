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

    static void FindDigit(ref List<int> a, ref string temp) 
    {
        temp += " ";
        string t = "";
        for(int i = 0; i < temp.Length; i++)
        {
            if((int)temp[i]>=48 && (int)temp[i]<=57)
            {
                t += temp[i];
                if (i+1 < temp.Length)
                {
                    if ((int)temp[i+1] < 48 || (int)temp[i+1] > 57)
                    {
                        int ci = int.Parse(t);
                        a.Add(ci);
                        t = "";
                    }
                }
                
            }
        }
    }
    class Stack<T> : IEnumerable<T>
    {
        private List<T> all=new List<T>();

        public void Push(List<T> elemnts)
        {
            for(int i=0; i<elemnts.Count; i++)
            {
                all.Add(elemnts[i]);
            }
        }

        public void Pop()
        {
            all.Remove(all[all.Count-1]);
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int j = all.Count - 1; j >= 0; j--)
            {
                yield return all[j];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    static void Main()
    {

        Stack<int> all = new Stack<int>();
        string a = "";
        while (true)
        {
            a = Console.ReadLine();
            if (a == "END")
            {
                break;
            }
            
            string temp="";
            FindWord(ref a, ref temp);
            if (temp == "Push")
            {
                List<int> list = new List<int>();
                FindDigit(ref list, ref a);
                all.Push(list);
                
            }
            else if (temp == "Pop")
            {
                all.Pop();
                foreach(var el in all)
                {
                    Console.Write(el+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
