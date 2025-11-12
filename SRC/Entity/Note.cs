using System;
namespace SRC.Entity;
public class Note
{
    public double Valeur { get; set; }

    public Note(double valeur)
    {
        Valeur = valeur;
    }

    public string Appreciation()
    {
        if (Valeur >= 16) return "Excellent";
        else if (Valeur >= 14) return "Très bien";
        else if (Valeur >= 12) return "Bien";
        else if (Valeur >= 10) return "Passable";
        else return "Insuffisant";
    }
}
