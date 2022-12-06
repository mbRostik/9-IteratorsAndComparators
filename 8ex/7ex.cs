using System;
using System.Collections.Generic;
internal class Program
{

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override bool Equals(object obj)
        {
            Console.WriteLine("1");
            User a = new User();
            obj = obj is User;
            
            return this.Equals(obj as User);
        }

        public override int GetHashCode()
        {
            Console.WriteLine("2");
            return HashCode.Combine(this.Name, this.Age);
        }
        private bool Equels(User that)
        {
            Console.WriteLine("3");
            if (that == null)
            {
                return false;
            }

            return Equals(this.Name, that.Name) && this.Age == that.Age;
        }
    }
    static void Main()
    {
        HashSet<User> all = new HashSet<User>();

        all.Add(new User { Name = "Alex" });
        all.Add(new User { Name = "John" });
        all.Add(new User { Name = "Alex" });


        bool exists = all.Contains(new User { Name = "Rost" });
        
    }
}
