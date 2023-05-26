using Connecte;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcervatoirC.Modele;
using ConcervatoirC.Vue;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySqlX.XDevAPI.Common;
using static Mysqlx.Notice.Warning.Types;

namespace ConcervatoirC.DAL
{
    public class PersonneDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoireefrei";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        public static Prof findProfById(int idProf)
        {
            Prof p = null;

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("SELECT IDPROF, ID, nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID WHERE IDPROF = " + idProf);

                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    int idprof = (int)reader.GetValue(1);
                    string nom = (string)reader.GetValue(2);
                    string prenom = (string)reader.GetValue(3);
                    int tel = (int)reader.GetValue(4);
                    string mail = (string)reader.GetValue(5);
                    string adresse = (string)reader.GetValue(6);
                    string instrument = (string)reader.GetValue(7);
                    double salaire = (double)reader.GetValue(8);

                    p = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);
                    reader.Close();

                    maConnexionSql.closeConnection();

                    return p;
                }
                return p;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw (e);
            }
        }


        public static List<Prof> getAllProf()
        {
            List<Prof> lesPers = new List<Prof>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT IDPROF, ID, nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID");//SELECT nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID
                MySqlDataReader reader = Ocom.ExecuteReader();

                Prof p;

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    int idprof = (int)reader.GetValue(1);
                    string nom = (string)reader.GetValue(2);
                    string prenom = (string)reader.GetValue(3);
                    int tel = (int)reader.GetValue(4);
                    string mail = (string)reader.GetValue(5);
                    string adresse = (string)reader.GetValue(6);
                    string instrument = (string)reader.GetValue(7);
                    double salaire = (double)reader.GetValue(8);


                    //Instanciation d'un personne
                    p = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);

                    lesPers.Add(p);

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (lesPers);
            }

            catch (Exception emp)
            {

                throw (emp);

            }


        }

        public static bool connect(string login, string password)
        {
            bool connect = false;
            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                string queryString = "SELECT COUNT(*) FROM admin WHERE login = @login AND mdp = @mdp";
                Ocom = maConnexionSql.reqExec(queryString);
                Ocom.Parameters.AddWithValue("@login", login);
                Ocom.Parameters.AddWithValue("@mdp", password);
                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();


                while (reader.Read())
                {
                    if ((Int64)reader.GetValue(0) == 1)
                    {
                        connect = true;



                    }

                }

                reader.Close();
                maConnexionSql.closeConnection();

                return (connect);

            }
            catch (Exception emp)
            {

                throw (emp);

            }

        }

        // séances
        public static List<Seances> getAllSeance(int idProf)
        {
            List<Seances> lesSeances = new List<Seances>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT * FROM seance Where IDPROF= " + idProf);//SELECT nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID
                MySqlDataReader reader = Ocom.ExecuteReader();

                Seances s;

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);

                    int numseance = (int)reader.GetValue(1);
                    string tranche = (string)reader.GetValue(2);
                    string jour = (string)reader.GetValue(3);
                    int niveau = (int)reader.GetValue(4);
                    int capacite = (int)reader.GetValue(5);


                    //Instanciation d'un personne
                    s = new Seances(id, numseance, tranche, jour, niveau, capacite);


                    lesSeances.Add(s);

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (lesSeances);
            }

            catch (Exception emp)
            {

                throw (emp);

            }

        }

        public static List<Eleve> getAllEleve(int numSeance)
        {
            List<Eleve> lesEleves = new List<Eleve>();

            Console.WriteLine(numSeance);

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT eleve.IDELEVE, nom, prenom, tel, mail, adresse, bourse FROM eleve JOIN inscription ON eleve.IDELEVE = inscription.IDELEVE JOIN personne ON eleve.IDELEVE = personne.ID WHERE inscription.NUMSEANCE= " + numSeance);//SELECT nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID
                MySqlDataReader reader = Ocom.ExecuteReader();

                Eleve e;

                while (reader.Read())
                {

                    int ideleve = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    int tel = (int)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    int bourse = (int)reader.GetValue(6);

                    e = new Eleve(ideleve, nom, prenom, tel, mail, adresse, bourse);
                    lesEleves.Add(e);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                return (lesEleves);
            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }

        public static List<Eleve> getAllEleves()
        {
            List<Eleve> lesEleves = new List<Eleve>();


            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT eleve.IDELEVE, nom, prenom, tel, mail, adresse, bourse FROM eleve JOIN personne ON eleve.IDELEVE = personne.ID"); //SELECT nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID
                MySqlDataReader reader = Ocom.ExecuteReader();

                Eleve e;

                while (reader.Read())
                {

                    int ideleve = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    int tel = (int)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    int bourse = (int)reader.GetValue(6);

                    e = new Eleve(ideleve, nom, prenom, tel, mail, adresse, bourse);
                    lesEleves.Add(e);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                return (lesEleves);
            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }
        public static List<Instrument> getAllInstrument()
        {
            List<Instrument> lesInstruments = new List<Instrument>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT * FROM instrument");
                MySqlDataReader reader = Ocom.ExecuteReader();

                Instrument i;

                while (reader.Read())
                {
                    string libelle = (string)reader.GetValue(0);

                    i = new Instrument(libelle);
                    lesInstruments.Add(i);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                return (lesInstruments);
            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }

        public static void ajoutProf(int id, string nom, string prenom, int tel, string mail, string adresse, string instrument, double salaire)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("INSERT INTO personne (ID, nom, prenom, tel, mail, adresse) VALUES (@ID, @nom, @prenom, @tel, @mail, @adresse)");
                Ocom.Parameters.AddWithValue("@ID", id);
                Ocom.Parameters.AddWithValue("@nom", nom);
                Ocom.Parameters.AddWithValue("@prenom", prenom);
                Ocom.Parameters.AddWithValue("@tel", tel);
                Ocom.Parameters.AddWithValue("@mail", mail);
                Ocom.Parameters.AddWithValue("@adresse", adresse);
                Ocom.ExecuteNonQuery();



                Ocom = maConnexionSql.reqExec("INSERT INTO prof (IDPROF, instrument, salaire) VALUES (@IDPROF, @instrument, @salaire)");
                Ocom.Parameters.AddWithValue("@IDPROF", id);
                Ocom.Parameters.AddWithValue("@instrument", instrument);
                Ocom.Parameters.AddWithValue("@salaire", salaire);
                Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }

        public static int recuperationDernierId()
        {
            maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
            maConnexionSql.openConnection();

            Ocom = maConnexionSql.reqExec("SELECT MAX(ID) FROM personne");
            MySqlDataReader reader = Ocom.ExecuteReader();

            int dernierId = 0;
            try
            {
                while (reader.Read())
                {
                    dernierId = (int)reader.GetValue(0);


                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (dernierId);

            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }

        public static void supprimerProf(int id)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("DELETE FROM personne WHERE ID = " + id);
                Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }


        public static void modifieDateSeance(string jour, string heure, int id)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("UPDATE seance SET TRANCHE='" + heure + "', JOUR='" + jour + "' WHERE seance.NUMSEANCE=" + id + " ;"); Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);

            }

        }

        public static List<TrancheHoraire> allHoraire()
        {

            List<TrancheHoraire> lesTranches = new List<TrancheHoraire>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("SELECT * FROM heure"); Ocom.ExecuteNonQuery();
                MySqlDataReader reader = Ocom.ExecuteReader();

                TrancheHoraire T;

                while (reader.Read())
                {
                    string libelle = (string)reader.GetValue(0);

                    T = new TrancheHoraire(libelle);
                    lesTranches.Add(T);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                return (lesTranches);
            }



            catch (Exception emp)
            {

                throw (emp);

            }

        }

        public static bool trancheDispo(int idProf, string jour, string heureDebut, string heureFin)
        {

            bool trancheHoraireDispo = false;

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("SELECT COUNT(*) " +
                                                "FROM seance S " +
                                                "WHERE S.JOUR = @jour " +
                                                "AND S.IDPROF = @idProf " +
                                                "AND	( " +
                                                        "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))<=(SELECT CAST(@heureDebut AS INT)) " +

                                                            "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) <= (SELECT CAST( @heureFin AS INT)) " +
                                                            "AND (SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) > (SELECT CAST( @heureDebut AS INT))) " +
                                                        "OR " +
                                                        "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))>=(SELECT CAST(@heureDebut AS INT)) " +
                                                           "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST( @heureFin AS INT)) " +
                                                          "AND (SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) < (SELECT CAST( @heureFin AS INT)))  " +
                                                         "OR " +

                                                         "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))<=(SELECT CAST(@heureDebut AS INT)) " +
                                                           "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST( @heureFin AS INT))) " +


                                                         "OR " +

                                                         "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))>=(SELECT CAST(@heureDebut AS INT)) " +
                                                           "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1))<= (SELECT CAST( @heureFin AS INT))) " +
                                                      ")");

                Ocom.Parameters.AddWithValue("@jour", jour);
                Ocom.Parameters.AddWithValue("@idProf", idProf);
                Ocom.Parameters.AddWithValue("@heureDebut", heureDebut);
                Ocom.Parameters.AddWithValue("@heureFin", heureFin);

                Ocom.ExecuteNonQuery();
                MySqlDataReader reader = Ocom.ExecuteReader();
                TrancheHoraire T;

                while (reader.Read())
                {

                    if ((Int64)reader.GetValue(0) == 0)
                    {
                        trancheHoraireDispo = false;
                    }
                    else
                    {
                        trancheHoraireDispo = true;
                    }

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (trancheHoraireDispo);
            }



            catch (Exception emp)
            {

                throw (emp);

            }

        }


        public static void insertSeance(int NumSeance, int idProf, string tranche, string jour, int niveau, int capacite)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("INSERT INTO seance (NumSeance, idProf, tranche, jour, niveau, capacite) VALUES (@NumSeance, @idProf, @tranche, @jour, @niveau, @capacite)");
                Ocom.Parameters.AddWithValue("@NumSeance", NumSeance);
                Ocom.Parameters.AddWithValue("@idProf", idProf);
                Ocom.Parameters.AddWithValue("@tranche", tranche);
                Ocom.Parameters.AddWithValue("@jour", jour);
                Ocom.Parameters.AddWithValue("@niveau", niveau);
                Ocom.Parameters.AddWithValue("@capacite", capacite);
                Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }

        public static int getNumSeance()
        {
            maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
            maConnexionSql.openConnection();

            Ocom = maConnexionSql.reqExec("SELECT NUMSEANCE FROM seance WHERE NUMSEANCE = (SELECT MAX(NUMSEANCE) FROM seance)");
            MySqlDataReader reader = Ocom.ExecuteReader();

            int dernierId = 0;
            try
            {
                while (reader.Read())
                {
                    dernierId = (int)reader.GetValue(0);


                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (dernierId);

            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }





        public static List<Eleve> GetAllEleves()
        {
            List<Eleve> eleves = new List<Eleve>();

            try
            {
                ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT  ID, IDELEVE, nom, prenom, tel, mail, adresse, bourse FROM eleve JOIN personne ON eleve.IDELEVE = personne.ID");//SELECT nom, prenom, tel, mail, adresse, instrument, salaire FROM prof JOIN personne ON prof.IDPROF = personne.ID
                MySqlDataReader reader = Ocom.ExecuteReader();

                Eleve e;

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    int ideleve = (int)reader.GetValue(1);
                    string nom = (string)reader.GetValue(2);
                    string prenom = (string)reader.GetValue(3);
                    int tel = (int)reader.GetValue(4);
                    string mail = (string)reader.GetValue(5);
                    string adresse = (string)reader.GetValue(6);
                    int bourse = (int)reader.GetValue(7);


                    //Instanciation d'un personne
                    e = new Eleve(id, nom, prenom, tel, mail, adresse, bourse);

                    eleves.Add(e);

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (eleves);
            }

            catch (Exception emp)
            {

                throw (emp);

            }


        }

        //afficher les trimestres
        public static List<Trimestres> GetAllTrimestres()
        {
            List<Trimestres> trimestres = new List<Trimestres>();

            try
            {

                ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT * FROM trim");
                MySqlDataReader reader = Ocom.ExecuteReader();

                Trimestres t;

                while (reader.Read())
                {
                    string libelle = (string)reader.GetValue(0);
                    string datefin = (string)reader.GetValue(1);

                    //Instanciation d'un personne
                    t = new Trimestres(libelle, datefin);

                    trimestres.Add(t);

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (trimestres);
            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }



        public static bool VerifierPaiementTrimestre(int idEleve, string libelleTrimestre)
        {
            bool resultat = false;
            try
            {
                ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT COUNT(*) as nbre FROM payer WHERE IDELEVE = @ideleve AND LIBELLE = @libelle AND PAYE = 1");
                Ocom.Parameters.AddWithValue("@ideleve", idEleve);
                Ocom.Parameters.AddWithValue("@libelle", libelleTrimestre);
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {


                    Int64 nbResultats = (Int64)reader.GetValue(0);

                    if (nbResultats > 0)
                    {
                        resultat = true;
                    }

                }

                reader.Close();

                maConnexionSql.closeConnection();

                

                //yyyyyyyyyyyyyyyyy

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return resultat;

        }






        //cheking Paiement
        public static Trimestres RecuperationDetailsPaiement(int idEleve, string libelle)
        {


            Trimestres detailsTrimestreEleve;
            Trimestres Trim = new Trimestres(0, "", "", 0);


            try
            {

                ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);



                string queryString = "SELECT * FROM payer where IDELEVE = @idEleve AND LIBELLE = @libelle";


                Ocom = maConnexionSql.reqExec(queryString);
                Ocom.Parameters.AddWithValue("@idEleve", idEleve);
                Ocom.Parameters.AddWithValue("@libelle", libelle);



                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int idElevePaiement = (int)reader.GetValue(0);
                    string libellePaiment = (string)reader.GetValue(1);
                    string datePaiement = (string)reader.GetValue(2);
                    int etatPaiement = (int)reader.GetValue(3);


                    Trim = new Trimestres(idElevePaiement, libellePaiment, datePaiement, etatPaiement);


                }



                reader.Close();

                maConnexionSql.closeConnection();


                return (Trim);


            }

            catch (Exception emp)
            {

                throw (emp);


            }

            return (Trim);


        }

        //insertion des trimestres payé
        public static void InsertionTrimestrePaye(int idEleve, string libelle)
        {

            try
            {

                ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                string queryString = "INSERT INTO payer (IDELEVE, LIBELLE, DATEPAEMENT, PAYE) VALUES (@idEleve, @libelle, NOW(), 1)";

                Ocom = maConnexionSql.reqExec(queryString);
                Ocom.Parameters.AddWithValue("@idEleve", idEleve);
                Ocom.Parameters.AddWithValue("@libelle", libelle);

                maConnexionSql.openConnection();
                Ocom.ExecuteNonQuery();
                maConnexionSql.closeConnection();

            }
            catch (Exception emp)
            {

                throw (emp);

            }

        }

        public static List<Eleve> EleveExclu(string jour, string heureDebut, string heureFin)
        {
            
            List<Eleve> elevesExclu = new List<Eleve>();

            Console.WriteLine("test 4");
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("SELECT P.ID, P.NOM, P.PRENOM, P.TEL, P.MAIL, P.ADRESSE " +
                                                "FROM inscription I " +
                                                "INNER JOIN seance S ON I.NUMSEANCE = S.NUMSEANCE " +
                                                "INNER JOIN personne P ON I.IDELEVE = P.ID " +
                                                "WHERE S.jour = @jour " +
                                                "AND( " +
                                                        "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))<=(SELECT CAST(@heureDebut AS INT)) " +

                                                            "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) <= (SELECT CAST( @heureFin AS INT)) " +
                                                            "AND (SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) > (SELECT CAST( @heureDebut AS INT))) " +
                                                        "OR " +
                                                        "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))>=(SELECT CAST(@heureDebut AS INT)) " +
                                                           "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST( @heureFin AS INT)) " +
                                                          "AND (SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) < (SELECT CAST( @heureFin AS INT)))  " +
                                                         "OR " +

                                                         "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))<=(SELECT CAST(@heureDebut AS INT)) " +
                                                           "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST( @heureFin AS INT))) " +


                                                         "OR " +

                                                         "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1))>=(SELECT CAST(@heureDebut AS INT)) " +
                                                           "AND( SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1))<= (SELECT CAST( @heureFin AS INT))) " +
                                                      ")");

                Ocom.Parameters.AddWithValue("@jour", jour);
                Ocom.Parameters.AddWithValue("@heureDebut", heureDebut);
                Ocom.Parameters.AddWithValue("@heureFin", heureFin);

                Ocom.ExecuteNonQuery();
                MySqlDataReader reader = Ocom.ExecuteReader();
                Eleve e;
                while (reader.Read())
                {
                    int ideleve = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    int tel = (int)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);


                    //Instanciation d'un personne
                    e = new Eleve(ideleve, nom, prenom, tel, mail, adresse);

                    elevesExclu.Add(e);

                }

                reader.Close();

                maConnexionSql.closeConnection();

                return (elevesExclu);
            }



            catch (Exception emp)
            {

                throw (emp);

            }

        }

        //ajouterCetEleve

        public static void AjouterCetEleve(int idProf, int idEleve, int numseance)
        {

            try
            {

                ConnexionSql maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                string queryString = "INSERT INTO inscription (IDPROF, IDELEVE, NUMSEANCE, DATEINSCRIPTION) VALUES (@idProf, @idEleve, @numseance, NOW())";
                Ocom = maConnexionSql.reqExec(queryString);
                Ocom.Parameters.AddWithValue("@idProf", idProf);
                Ocom.Parameters.AddWithValue("@idEleve", idEleve);
                Ocom.Parameters.AddWithValue("@numseance", numseance);
                

                maConnexionSql.openConnection();
                Ocom.ExecuteNonQuery();
                maConnexionSql.closeConnection();

            }
            catch (Exception emp)
            {

                throw (emp);

            }


        }



    }














}