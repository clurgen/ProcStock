﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace controle
{
    class Requetes
    {
        MySqlConnection cnx;
        public Requetes(string h, string u, string db, string p)
        {
            Connexion cn = new Connexion(h, u, db, p);
            cnx = cn.Cnx;
        }

        //Requete 1
        public string ListeEmployes()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select * from employe";
            cmdSql.CommandType = CommandType.Text;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}, {3}, {4} {5} \n",
                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }

            this.cnx.Close();
            return result;
        }
        //Requete 2
        public string ListeServices()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "service";
            cmdSql.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}, {3}, {4} {5} \n",
                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }

            this.cnx.Close();
            return result;
        }
        //Requete 3
        public string MajSalaire(string nom, double pourcent)
        {
            string result = "mise à jour OK";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "MajSalaire";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("nom", MySqlDbType.String);
            cmdSql.Parameters["nom"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["nom"].Value = nom;
            cmdSql.Parameters.Add("pourcentage", MySqlDbType.Decimal);
            cmdSql.Parameters["pourcentage"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["pourcentage"].Value = pourcent;
            cmdSql.Prepare();
            try
            {
                cmdSql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            cnx.Close();
            return result;
        }
        //Requete 4
        public decimal MasseSalariale(string nomService)
        {
            decimal result = 0;

            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "MasseSalariale";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("nomService", MySqlDbType.String);
            cmdSql.Parameters["nomService"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["nomService"].Value = nomService;
            cmdSql.Parameters.Add("masSalar", MySqlDbType.String);
            cmdSql.Parameters["masSalar"].Direction = ParameterDirection.Output;
            cmdSql.Prepare();
            try
            {
                cmdSql.ExecuteScalar();
            }
            catch (Exception e)
            {
                string test = e.Message;
            }
            cnx.Close();
            result = Convert.ToDecimal(cmdSql.Parameters["masSalar"].Value);

            return result;

        }
        //Requete 5
        public string SuperCadre()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select emp_nom from Cadre where emp_salaire > (select avg(emp_salaire) from Cadre);";
            cmdSql.CommandType = CommandType.Text;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}\n",
                    reader[0]);
            }

            this.cnx.Close();
            return result;
        }
        //Requête 6
        public string createEmp(int id, string nom, string prenom, string sexe, bool cadre, double salaire, int service)
        {
            string result = "Mise à jour OK";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "createEmp";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("id", MySqlDbType.Int32);
            cmdSql.Parameters["id"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["id"].Value = id;
            cmdSql.Parameters.Add("nom", MySqlDbType.String);
            cmdSql.Parameters["nom"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["nom"].Value = nom;
            cmdSql.Parameters.Add("prenom", MySqlDbType.String);
            cmdSql.Parameters["prenom"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["prenom"].Value = prenom;
            cmdSql.Parameters.Add("sexe", MySqlDbType.String);
            cmdSql.Parameters["sexe"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["sexe"].Value = sexe;
            cmdSql.Parameters.Add("cadre", MySqlDbType.Int32);
            cmdSql.Parameters["cadre"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["cadre"].Value = cadre;
            cmdSql.Parameters.Add("salaire", MySqlDbType.Double);
            cmdSql.Parameters["salaire"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["salaire"].Value = salaire;
            cmdSql.Parameters.Add("service", MySqlDbType.String);
            cmdSql.Parameters["service"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["service"].Value = service;
            cmdSql.Prepare();
            try
            {
                cmdSql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            cnx.Close();
            return result;
        }
        //Requete 7 
        public string baclic()
        {
            string result = "";

            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "baclic";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Prepare();
            try
            {
                MySqlDataReader reader = cmdSql.ExecuteReader();
                while (reader.Read())
                {
                    result += String.Format("{0} {1}\n", reader[0], reader[1]);
                }
            }
            catch (Exception e)
            {
                string test = e.Message;
            }
            cnx.Close();
            return result;

        }
        //Requête 8

        public string borne(int borneInf, int borneSup)
        {
            string result = "mise à jour OK";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "borne";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("borneInf", MySqlDbType.Int32);
            cmdSql.Parameters["borneInf"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["borneInf"].Value = borneInf;
            cmdSql.Parameters.Add("borneSup", MySqlDbType.Int32);
            cmdSql.Parameters["borneSup"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["borneSup"].Value = borneSup;
            cmdSql.Prepare();

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0} {1}\n", reader[0], reader[1]);
            }
            cnx.Close();
            return result;
        }

        //Requête 9

        public string updateService(int numero, double pourcentage)
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "updateService";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("numero", MySqlDbType.Int32);
            cmdSql.Parameters["numero"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["numero"].Value = numero;
            cmdSql.Parameters.Add("pourcentage", MySqlDbType.Double);
            cmdSql.Parameters["pourcentage"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["pourcentage"].Value = pourcentage;
            cmdSql.Prepare();
            try
            {
                cmdSql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            cnx.Close();
            return result;
        }

        //Requête 10

        public string diplome()
        {
            string result = "mise à jour OK";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "diplome";
            cmdSql.CommandType = CommandType.StoredProcedure;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0} {1}\n", reader[0], reader[1]);
            }

            cnx.Close();
            return result;
        }
    }
}
