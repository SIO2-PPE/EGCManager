using System;
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
            DateTime deb = new DateTime(2020, 12, 18);
            DateTime fin = new DateTime(2020, 12, 19);

            Hydrate(deb,fin);
        }

        static void Hydrate(DateTime debut, DateTime fin)
        {
            Dbal dbal = new Dbal("ppe3_mmd");
            dbal.DBinit();
            dbal.DBhydrate();
            DaoClient daoClient = new DaoClient(dbal);
            DaoSalle daoSalle = new DaoSalle(dbal);
            DaoHoraire daoHoraire = new DaoHoraire(dbal);
            DaoJoueur daoJoueur = new DaoJoueur(dbal);
            DaoPartie daoPartie = new DaoPartie(dbal);
            DaoObstacle daoObstacle = new DaoObstacle(dbal);

            var randNb = new Random();
            var randFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var randLastName = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            var randNaissance = RandomizerFactory.GetRandomizer(new FieldOptionsDateTime
                {From = new DateTime(1970, 1, 1), To = DateTime.Today.AddYears(-18), IncludeTime = false});

            for (int i = 0; i < 100; i++)
            {
                string nom = randFirstName.Generate();
                daoClient.NouveauClient(new Client(randLastName.Generate(), nom, randNaissance.Generate().Value,
                    nom + "@gmail.com", "0600000000", "une adresse", 100));
            }

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
            Console.ResetColor();

            int a = debut.Day;
            for (DateTime j = debut; j < fin; j = j.AddDays(1))
            {
                foreach (Salle salle in daoSalle.GetAll())
                {
                    foreach (Horaire horaire in daoHoraire.GetHorairesForSite(salle.Site))
                    {
                        if (randNb.Next(4) != 0) // 75 %
                        {
                            Partie partie = new Partie(salle,horaire,j);
                            int nbJoueur = randNb.Next(2, 8);
                            for (int i = 0; i < nbJoueur; i++)
                            {
                                string name = randFirstName.Generate();
                                Joueur joueur = new Joueur(name, name + "@gmail.com");
                                daoJoueur.AddJoueur(ref joueur);
                                partie.LstJoueur.Add(joueur);
                            }
                            // int nbObstacle = randNb.Next(6, 13);
                            // for (int i = 0; i < nbObstacle; i++)
                            // {
                            //     
                            // }
                            partie.LstObstacle = daoObstacle.GetAllObstacle(); // temporaire (rajouter des obstacle dans la bdd
                            daoPartie.NouvellePartie(partie);
                        }
                    }
                }

                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                                                                                ");
                Console.ResetColor();
            }
        }
    }
}