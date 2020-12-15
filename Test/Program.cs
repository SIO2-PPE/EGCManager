using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Model.Business;
using Model.Data;

//using Model.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Dbal dbal = new Dbal("ppe3_mmd");
            dbal.DBinit();
            dbal.DBhydrate();
        }
    }
}
