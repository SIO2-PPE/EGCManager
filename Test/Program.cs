﻿using System;
using System.Collections.Generic;
using Model.Business;
using Model.Data;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime deb = new DateTime(2020,12,7);
            DateTime fin = new DateTime(2020, 12, 19);
            var randPeriode = RandomizerFactory.GetRandomizer(new FieldOptionsDateTime { From = deb, To = fin, IncludeTime = false});
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(randPeriode.Generate());
            }
        }

        static void HydratePartie(DateTime debut, DateTime fin)
        {
            Dbal dbal = new Dbal("ppe3_mmd");
            DaoSalle daoSalle = new DaoSalle(dbal);
            DaoHoraire daoHoraire = new DaoHoraire(dbal);
            DaoJoueur daoJoueur = new DaoJoueur(dbal);
            
            var randJoueur = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            //var randNb = RandomizerFactory.GetRandomizer();
            var randPeriode = RandomizerFactory.GetRandomizer(new FieldOptionsDateTime());
            
            foreach (Salle salle in daoSalle.GetAll())
            {
                foreach (Horaire horaire in daoHoraire.GetHorairesForSite(salle.Site))
                {
                    
                }
            }
        }
    }
}