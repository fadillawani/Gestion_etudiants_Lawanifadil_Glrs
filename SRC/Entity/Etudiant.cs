using System;
namespace SRC.Entity;
public class Etudiant
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public List<Note> Notes { get; set; }

    public Etudiant(string nom, string prenom)
    {
        Nom = nom;
        Prenom = prenom;
        Notes = new List<Note>();
    }

    public double CalculerMoyenne()
    {
        if (Notes.Count == 0)
            return 0;

        double somme = 0;
        foreach (var note in Notes)
        {
            somme += note.Valeur;
        }
        return somme / Notes.Count;
    }

     public override string ToString()
        {
            return $"[  Prenom #{Nom}] Nom : {Prenom} {Nom}, Nombre de notes : {Notes.Count}";
        }
}

