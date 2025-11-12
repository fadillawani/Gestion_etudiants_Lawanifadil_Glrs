using System.Collections.Generic;
using SRC.Entity;
namespace SRC.Services;

public interface IEtudiantService
{
    void AjouterNote(string nom, string prenom, double valeurNote);
    void AfficherNotesEtudiantAvecAppreciations(Etudiant etudiant);
    void AfficherMeilleurEtudiant();
     double AfficherMoyenneGenerale();

}