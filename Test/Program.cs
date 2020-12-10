using System;
using System.Collections.Generic;
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
            DaoSite daoSite = new DaoSite(dbal);
            //DaoSalle daoSalle = new DaoSalle(dbal);

            //dbal.Select("Site");

            /*foreach (Site site in daoSite.GetAllSite())
            {
                Console.WriteLine(site.Ville);
            }*/
            
        }
    }
}
