using System;
using System.Collections.Generic;
using Model.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Dbal dbal = new Dbal("egc_db");
            DaoClient daoClient = new DaoClient(dbal);
        }
    }
}
