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
            DaoHoraire daoH = new DaoHoraire(dbal);

            foreach (Horaire horaire in daoH.GetAllHoraires())
            {
                Console.WriteLine(horaire.Heure);
            }
            
        }
    }
}
