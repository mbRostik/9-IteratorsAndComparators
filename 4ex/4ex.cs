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
        for (int i = 0; i < temp.Length; i++)
        {
            if ((int)temp[i] >= 48 && (int)temp[i] <= 57)
            {
                t += temp[i];
                if (i + 1 < temp.Length)
                {
                    if ((int)temp[i + 1] < 48 || (int)temp[i + 1] > 57)
                    {
                        int ci = int.Parse(t);
                        a.Add(ci);
                        t = "";
                    }
                }

            }
        }
    }
    
    class Lake: IEnumerable<int>
    {
        private List<int> all = new List<int>();

        public void Create(List<int> elemnts)
        {
            for (int i = 0; i < elemnts.Count; i++)
            {
                all.Add(elemnts[i]);
            }
        }


        public IEnumerator<int> GetEnumerator()
        {
            int i = 0;
            int s = 2;
            for (int j = 0; true; j+=s)
            {
                if (i == 0 && all.Count==j)
                {
                    i = 9;
                    j--;
                    s *= -1;
                }

                else if (i == 0 && all.Count-1 == j)
                {
                    i = 9;
                    int d = j;
                    j--;
                    s *= -1;
                    yield return all[d];
                }
                if (j < 0)
                {
                    break;
                }
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
        Lake all = new Lake();
        string sm = Console.ReadLine();

        List<int> list = new List<int>();
        FindDigit(ref list, ref sm);
        all.Create(list);

        foreach (var el in all)
        {
            Console.Write(el + " ");
        }
        Console.WriteLine();
    }
}
