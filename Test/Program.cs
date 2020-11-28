using System;
using System.Collections.Generic;
//using Model.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dbal dbal = new Dbal("egc_db");
            // DaoClient daoClient = new DaoClient(dbal);
            // DaoFacture daoFacture = new DaoFacture(dbal);

            bool _auto_increment = true;
            if (Console.ReadLine() != "id"
                && _auto_increment)
            {
                Console.WriteLine("ba oui");
            }
            else
            {
                Console.WriteLine("ba non");
            }
        }
    }
}
