using System.Collections.Generic;
namespace SRC.Repository.Impl;

using SRC.Entity;
public class EtudiantRepository : IEtudiantRepository
{
    private readonly List<Etudiant> etudiants = new List<Etudiant>();
    

    public void addEtudiant(Etudiant etudiant)
    {
        etudiants.Add(etudiant);
    }

    public Etudiant? GetEtudiantByName(string nom, string prenom)
    {
        return etudiants.Find(e => e.Nom == nom && e.Prenom == prenom);
    }

    public List<Etudiant> ListerEtudiants()
    {
        return etudiants;
    }
}