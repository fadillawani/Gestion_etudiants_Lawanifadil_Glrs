using System.Collections.Generic;
using SRC.Entity;
using SRC.Repository;

namespace SRC.Services.Impl;
 public class EtudiantsServices : IEtudiantService
{
    private readonly IEtudiantRepository etudiantRepository;
    public EtudiantsServices(IEtudiantRepository etudiantRepository)
    {
        this.etudiantRepository = etudiantRepository;
    }

    public void AjouterNote(string nom, string prenom, double valeurNote) 
    {
        var etudiant = etudiantRepository.GetEtudiantByName(nom, prenom);
        if (etudiant != null)
        {
            etudiant.Notes.Add(new Note(valeurNote));
            Console.WriteLine($"Note {valeurNote} ajoutée à {etudiant.Nom} {etudiant.Prenom}");
        }
}


    public void AfficherNotesEtudiantAvecAppreciations(Etudiant etudiant)
    {
        if (etudiant == null)
        {
            Console.WriteLine("Étudiant introuvable !");
            return;
        }

        if (etudiant.Notes.Count == 0)
        {
            Console.WriteLine($"Aucune note enregistrée pour {etudiant.Nom} {etudiant.Prenom}.");
            return;
        }

        Console.WriteLine($"\nNotes de {etudiant.Nom} {etudiant.Prenom} :");

        foreach (var note in etudiant.Notes)
        {
            Console.WriteLine($"Note : {note.Valeur} - Appréciation : {note.Appreciation()}");
        }
    }

    public void AfficherMeilleurEtudiant()
    {
        var etudiants = etudiantRepository.ListerEtudiants();
        Etudiant? meilleurEtudiant = null;
        double meilleureMoyenne = double.MinValue;

        foreach (var etudiant in etudiants)
        {
            double moyenne = etudiant.CalculerMoyenne();
            if (moyenne > meilleureMoyenne)
            {
                meilleureMoyenne = moyenne;
                meilleurEtudiant = etudiant;
            }
        }

        if (meilleurEtudiant != null)
        {
            Console.WriteLine($"\nMeilleur étudiant : {meilleurEtudiant.Nom} {meilleurEtudiant.Prenom} avec une moyenne de {meilleureMoyenne:F2}");
        }
        else
        {
            Console.WriteLine("Aucun étudiant trouvé.");
        }

    }
    
    public double AfficherMoyenneGenerale()
    {
        var etudiants = etudiantRepository.ListerEtudiants();
        double sommeMoyennes = 0;
        int nombreEtudiants = etudiants.Count;

        foreach (var etudiant in etudiants)
        {
            sommeMoyennes += etudiant.CalculerMoyenne();
        }

        double moyenneGenerale = nombreEtudiants > 0 ? sommeMoyennes / nombreEtudiants : 0;
        Console.WriteLine($"\nMoyenne générale de la classe : {moyenneGenerale:F2}");
        return moyenneGenerale;
    }
}


    