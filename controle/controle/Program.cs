﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace controle
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            string host;
            string user;
            string bdd;
            string pwd;
            MySqlCommand Cmd;
            MySqlConnection Cnx;

            Requetes rq;

            /*paramètres de connexion
            Console.WriteLine("Donner le nom du serveur");
            host = Console.ReadLine();
            Console.WriteLine("Donner le nom de la base de données");
            bdd = Console.ReadLine();
            Console.WriteLine("Donner le nom de l'utilisateur");
            user= Console.ReadLine();
            Console.WriteLine("Donner le mot de passe");
            pwd = Console.ReadLine(); */

            host = "localhost";
            bdd = "gesper";
            user = "root";
            pwd = "siojjr";


            // connexion

            rq = new Requetes(host, user, bdd, pwd);

            do
            {
                do
                {
                    Console.WriteLine("1 - liste complète des employés (utiliser une requête)");
                    Console.WriteLine("2 - liste complète des services (utiliser la table, sans écrire de requête)");
                    Console.WriteLine("3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée)");
                    Console.WriteLine("4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)");
                    Console.WriteLine("5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)");
                    Console.WriteLine("6 - Création d'un nouvel employé");
                    Console.WriteLine("7 - liste des employés qui ont le Bac et une Licence");
                    Console.WriteLine("8 - liste des employés qui ont un salire compris entre une borne inferieure et superieure)");
                    Console.WriteLine("9 - Mise a jour du budget d'un service administratif");
                    Console.WriteLine("10 - liste des employés  qui ont plus de diplome que la moyenne des des diplomes possédée par chaque employés");
                    Console.WriteLine("11 - fin du traitement");


                    choix = Int32.Parse(Console.ReadLine());

                } while (choix < 0 || choix > 12);

                switch (choix)
                {
                    #region 1 - liste complète des employés (utiliser une requête)")
                    case 1:
                        Console.WriteLine("\n1 - liste complète des employés (utiliser une requête)");

                        Console.WriteLine(rq.ListeEmployes());


                        break;
                    #endregion
                    #region 2 - liste complète des services (utiliser la table, sans écrire de requête)")
                    case 2:
                        Console.WriteLine("\n1 - liste complète des services (utiliser la table, sans écrire de requête)");
                        Console.WriteLine(rq.ListeServices());

                        break;
                    #endregion
                   

                    #region 3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée majSalaire)
                    case 3:
                        Console.WriteLine("\n3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée majSalaire)");
                        Console.WriteLine(rq.MajSalaire("Dupont", 0.2));
                        break;
                    #endregion


                    #region 4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)
                    case 4:
                        Console.WriteLine("\n4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)");
                        
                        Console.WriteLine(rq.MasseSalariale("Atelier A"));




                        break;
                    #endregion
                    #region 5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 5:
                        Console.WriteLine("\n5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)");
                        Console.WriteLine(rq.SuperCadre());



                        break;
                    #endregion
                    #region 6 - Création d'un nouvel employé
                    case 6:
                        Console.WriteLine("\n6 - Création d'un nouvel employé");
                        Console.WriteLine(rq.createEmp(17, "urgen", "clement", "M", true, 3400, 1));
                        break;
                    #endregion

                    #region 7 - Lise des employés qui ont le bac et une licence
                    case 7:
                        Console.WriteLine("\n7 - liste des employés qui ont le Bac et une Licence");
                        Console.WriteLine(rq.baclic());



                        break;
                    #endregion

                    #region 8 - liste des employés aynt un salaire compris entre une borne inferieure et superieure
                    case 8:
                        Console.WriteLine("\n8 - liste des employés qui ont un salire compris entre une borne inferieure et superieure)");
                        Console.WriteLine(rq.borne(1500,4000));
                        break;
                    #endregion

                    #region 9 - Mise à jour du buget d'un service administratif
                    case 9:
                        Console.WriteLine("\n9 - Mise a jour du budget d'un service administratif");
                        Console.WriteLine(rq.updateService(3,0.2));

                        break;
                    #endregion

                    #region 10 - liste des employés  qui ont plus de diplome que la moyenne des des diplomes possédée par chaque employés
                    case 10:
                        Console.WriteLine("\n10 - liste des employés  qui ont plus de diplome que la moyenne des des diplomes possédée par chaque employés");
                        Console.WriteLine(rq.diplome());

                        break;
                    #endregion

                    #region 11 - Fin de traitement
                    case 11:
                        Console.WriteLine("\n11 - Fin de traitement");

                        break;
                        #endregion
                }
            }
            while (choix != 6);

            Console.ReadLine();
        }
    }
}
