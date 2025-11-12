using System;
using SRC.Entity;
using SRC.Services;
using SRC.Vue;
using SRC.Repository;


namespace View
{
    public class MainVue
    {
        private readonly EtudiantVue _etudiantVue;
        private readonly IEtudiantRepository _etudiantRepository;

    public MainVue(IEtudiantService etudiantService, IEtudiantRepository etudiantRepository)
        {
            _etudiantVue = new EtudiantVue(etudiantService, etudiantRepository);
        }

        public static string SaisieChaine(string message) 
        {
            string? chaine;
            do
            {
                Console.WriteLine(message);
                chaine = Console.ReadLine();
            } 
            while (string.IsNullOrWhiteSpace(chaine));

            return chaine!;
        }

        public static int SaisieChoix(string message)
        {
            int choix;
            while (!int.TryParse(SaisieChaine(message), out choix))
            {
                Console.WriteLine("Veuillez entrer un nombre valide !");
            }
            return choix;
        }

        public static void Passer()
        {
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();
            Console.Clear();
        }

        public void Demarrer()
        {
            bool continuer = true;

            while (continuer)
            {
                _etudiantVue.AfficherMenu();

                int choix = SaisieChoix("Entrez votre choix : ");

                switch (choix)
                {
                    case 1:
                        _etudiantVue.SaisirEtudiant();
                        break;

                    case 2:
                        _etudiantVue.AfficherEtudiants();
                        break;

                    case 3:
                        _etudiantVue.AjouterNote();
                        break;

                    case 4:
                        Console.Write("Entrez le nom de l'étudiant : ");
                        string nom = Console.ReadLine() ?? "";
                        Console.Write("Entrez le prénom de l'étudiant : ");
                        string prenom = Console.ReadLine() ?? "";
                    
                        _etudiantVue.AfficherNotesEtudiantAvecAppreciations(nom, prenom);
                        break;

                    case 5:
                        _etudiantVue.AfficherMeilleurEtudiant();
                        break;

                    case 6:
                        _etudiantVue.AfficherMoyenneGenerale();
                        break;

                    case 7:
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }

                Passer();
            }

            Console.WriteLine("Fin du programme !");
        }
    }
}
