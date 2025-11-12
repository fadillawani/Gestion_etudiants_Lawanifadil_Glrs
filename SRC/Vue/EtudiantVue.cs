using System;
using System.Collections.Generic;
using SRC.Entity;
using SRC.Repository;
using SRC.Services;

namespace SRC.Vue
{
    public class EtudiantVue
    {
       private readonly IEtudiantService _etudiantService;
    private readonly IEtudiantRepository _etudiantRepository;

    public EtudiantVue(IEtudiantService etudiantService, IEtudiantRepository etudiantRepository)
    {
        _etudiantService = etudiantService;
        _etudiantRepository = etudiantRepository;
    }

        public void SaisirEtudiant()
        {
            Console.Write("Entrez le nom de l'étudiant: ");
            string nom = Console.ReadLine() ?? "";
            Console.Write("Entrez le prénom de l'étudiant: ");
            string prenom = Console.ReadLine() ?? "";

            var etudiant = new Etudiant(nom, prenom);
            _etudiantRepository.addEtudiant(etudiant);

            Console.WriteLine($"✅ Étudiant {nom} {prenom} ajouté !");
        }

        public void AfficherEtudiants()
        {
            var etudiants = _etudiantRepository.ListerEtudiants();

            if (etudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant disponible.");
                return;
            }

            Console.WriteLine("\nListe des étudiants:");
            foreach (var etudiant in etudiants)
            {
                Console.WriteLine($"{etudiant.Nom} {etudiant.Prenom}");
            }
        }

        public void AjouterNote()
        {
            Console.Write("Entrez le nom de l'étudiant : ");
            string nom = Console.ReadLine() ?? "";
            Console.Write("Entrez le prénom de l'étudiant : ");
            string prenom = Console.ReadLine() ?? "";

            var etudiant = _etudiantRepository.GetEtudiantByName(nom, prenom);
            if (etudiant == null)
            {
                Console.WriteLine("⚠️ Étudiant introuvable !");
                return;
            }

            Console.Write("Entrez la valeur de la note à ajouter : ");
            string input = Console.ReadLine() ?? "0";
            if (double.TryParse(input, out double valeurNote))
            {
                _etudiantService.AjouterNote(nom, prenom, valeurNote);
                Console.WriteLine($"✅ Note {valeurNote} ajoutée à {nom} {prenom}.");
            }
            else
            {
                Console.WriteLine("⚠️ Valeur de note invalide.");
            }
        }

        public void AfficherMoyenneGenerale()
        {
            double moyenne = _etudiantService.AfficherMoyenneGenerale();
            Console.WriteLine($"\n📊 Moyenne générale de la classe : {moyenne:0.00}");
        }

        public void AfficherMeilleurEtudiant()
        {
            _etudiantService.AfficherMeilleurEtudiant();
        }

        public void AfficherNotesEtudiantAvecAppreciations( string nom, string prenom)
        {
            var etudiant = _etudiantRepository.GetEtudiantByName(nom, prenom);

            _etudiantService.AfficherNotesEtudiantAvecAppreciations(etudiant);
        }

        public void AfficherMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Ajouter un étudiant");
            Console.WriteLine("2. Ajouter une note à un étudiant");
            Console.WriteLine("3. Afficher les notes d'un étudiant avec appréciations");
            Console.WriteLine("4. Afficher le meilleur étudiant");
            Console.WriteLine("5. Afficher la moyenne générale");
            Console.WriteLine("6. Lister tous les étudiants");
            Console.WriteLine("0. Quitter");
            Console.Write("Choisissez une option: ");
        }
    }
}
