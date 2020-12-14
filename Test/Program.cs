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
            //dbal.DBinit();
            //dbal.DBhydrate();
            DaoHoraire daoH = new DaoHoraire(dbal);
            Salle s = new Salle();
            s.Id = 1;
            Site site = new Site();
            site.Id = 1;
            foreach (Partie partie in daoH.GetPlanning(DateTime.Now,s , site))
            {
                Console.WriteLine(partie.Id);
            }
        }
    }
}
