using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcervatoirC.DAL;
using ConcervatoirC.Modele;

namespace ConcervatoirC.Controleur
{
    public class Pers
    {
       
        List<Prof> lesPers;

        public Pers()
        {
            lesPers = new List<Prof>();
        }

        public List<Prof> chargementPers()
        {
            lesPers = PersonneDAO.getAllProf();
            return (lesPers);
        }
        
       
        public bool AuthAdmin(string login, string mdp)
        {
            bool lesPers = PersonneDAO.connect(login,mdp);
            return (lesPers); 
        }

        public static List<Seances> chargementSeance(int idProf)
        {
            List<Seances> lesSeances = PersonneDAO.getAllSeance(idProf);
            return (lesSeances);
        }

        public static List<Eleve> chargementEleve(int numSeance)
        {
            List<Eleve> lesEleves = PersonneDAO.getAllEleve(numSeance);
            return (lesEleves);
        }
        public static List<Eleve> getAllEleves()
        {
            List<Eleve> lesEleves = PersonneDAO.getAllEleves();
            return (lesEleves);
        }
        public static List<Instrument> chargementInstrument()
        {
            List<Instrument> lesInstruments = PersonneDAO.getAllInstrument();
            return (lesInstruments);
        }

        public static void ajoutProf(int id, string nom, string prenom, int tel, string mail, string adresse, string instrument, double salaire)
        {
            PersonneDAO.ajoutProf(id, nom, prenom, tel, mail, adresse, instrument, salaire);
        }
        
        public static int recuperationDernierId()
        {
            int id = PersonneDAO.recuperationDernierId();
            return (id);
        }

        public void supprimerProf(int id)
        {
            PersonneDAO.supprimerProf(id);
        }

        public void modifieDateSeance(string jour, string heure, int id)
        {
            PersonneDAO.modifieDateSeance(jour, heure, id);
        }

        public Prof findProfById(int id)
        {
            return PersonneDAO.findProfById(id);
        }

        public List<TrancheHoraire> horaireDispo(int idProf, string jour)
        {

            
          
            List<TrancheHoraire> lesHoraires = PersonneDAO.allHoraire();
            List<TrancheHoraire> lesHorairesDispo = new List<TrancheHoraire>();


            foreach (TrancheHoraire tranche in lesHoraires)
            {
                //10h00-12h00
                string[] traiterTranche = tranche.ToString().Split('h');
                string heureDepart = traiterTranche[0];

                string[] traiterTrancheFin = traiterTranche[1].Split('-');
                string heureFin = traiterTrancheFin[1];

                bool estDispo = PersonneDAO.trancheDispo(idProf, jour, heureDepart, heureFin);

                if (estDispo == false)
                {
                    lesHorairesDispo.Add(tranche);
                }

            }

            return lesHorairesDispo;

        }


        public static void ajoutSeance(int NumSeance, int idProf,  string heure, string jour, int niveau, int capacite)
        {
            PersonneDAO.insertSeance(NumSeance, idProf, heure, jour, niveau, capacite);
        }
        
        public static int getNumSeance()
        {
            int dernierID= PersonneDAO.getNumSeance();
            return dernierID;
        }

        public List<Eleve> GetAllEleves()
        {
            List<Eleve> lesEleves = PersonneDAO.GetAllEleves();
            return (lesEleves);
        }

        //GetAllTrimestres
        public List<Trimestres> GetAllTrimestres(int idEleve)
        {
            List<Trimestres> lesTrimestres = PersonneDAO.GetAllTrimestres();
            List<Trimestres> lesTrimestresEleve = new List<Trimestres>();

            foreach (Trimestres unTrimestre in lesTrimestres)
            {
                //get le libelle de la classe trimestre
                string libelleTrimestre = unTrimestre.Libelle;
                bool VerifPaemment = PersonneDAO.VerifierPaiementTrimestre(idEleve, libelleTrimestre);

                if (VerifPaemment == true)
                {
                    Trimestres TrimPaye = PersonneDAO.RecuperationDetailsPaiement(idEleve, libelleTrimestre);
                    lesTrimestresEleve.Add(TrimPaye);
                }
                else
                {
                    lesTrimestresEleve.Add(unTrimestre);
                }

            }
            

            return (lesTrimestresEleve);
        }

        //insertion des trimestres payé
        public static void InsertionTrimestrePaye(int idEleve, string libelleTrimestre)
        {
            PersonneDAO.InsertionTrimestrePaye(idEleve, libelleTrimestre);
        }

        //Liste des eleves pas dispo
        public List<Eleve> EleveExclu(string jour, string tranche)
        {

            Console.WriteLine("Test 3");
            //10h00-12h00
            string[] traiterTranche = tranche.ToString().Split('h');
            string heureDebut = traiterTranche[0];

            string[] traiterTrancheFin = traiterTranche[1].Split('-');
            string heureFin = traiterTrancheFin[1];
            
               

            List<Eleve> lesEleves = PersonneDAO.EleveExclu(jour, heureDebut, heureFin);


            Console.WriteLine("count : " + lesEleves.Count);

            return (lesEleves);

        }

        // ajouterCetEleve
        public static void ajouterCetEleve(int idProf, int idEleve, int numseance)
        {
            PersonneDAO.AjouterCetEleve(idProf, idEleve, numseance);
        }


    }


}


