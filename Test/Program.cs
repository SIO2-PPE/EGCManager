using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("date", DateTime.Now);
            if (values["date"] is string)
            {
                Console.WriteLine("c'est un string");
            }
            else if (values["date"] is DateTime)
            {
                Console.WriteLine(values["date"].ToString("yyyy-M-d"));
            }
            else
            {
                Console.WriteLine("ba non");
            }
            
        }
    }
}
