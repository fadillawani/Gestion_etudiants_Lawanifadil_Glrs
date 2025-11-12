using System.Collections.Generic;
namespace SRC.Repository;
using SRC.Entity;

public interface IEtudiantRepository
{
    void addEtudiant(Etudiant etudiant);
    Etudiant? GetEtudiantByName(string nom, string prenom);

    List<Etudiant> ListerEtudiants();
}