using NUnit.Framework;

namespace ProjetFinal.Tests
{
    public class SeanceTests
    {
        /// <summary>
        /// Teste sur l'ajout d'une séance de cours avec sa date et le nombre de personne max.
        /// </summary>
        [Test]
        public void AjouterUneSeanceDeCours()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10); 

            // Act
            gestionSeance.AjouterSeance(seance);

            // Assert
            Assert.IsTrue(gestionSeance.ListeSeances.Contains(seance));
        }
        /// <summary>
        /// Teste qui retire une séance de cours qui était déjà présente.
        /// </summary>
        [Test]
        public void RetirerUneSeanceDeCours()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            gestionSeance.AjouterSeance(seance);

            // Act
            gestionSeance.RetirerSeance(seance);

            // Assert
            Assert.IsFalse(gestionSeance.ListeSeances.Contains(seance));
        }
        /// <summary>
        /// Teste sur l'ajout d'un professeur dans une séance.
        /// </summary>
        [Test]
        public void AjouterProfesseurAUneSeance()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            Professeur professeur = new Professeur { Nom = "Dupont", Prenom = "Jean" };

            // Act
            gestionSeance.AjouterProfesseurASeance(seance, professeur);

            // Assert
            Assert.IsTrue(seance.Professeurs.Contains(professeur));
        }
        /// <summary>
        /// Teste qui retire un professeur d'une séance.
        /// </summary>
        [Test]
        public void RetirerProfesseurDeSeance()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            Professeur professeur = new Professeur { Nom = "Dupont", Prenom = "Jean" };
            gestionSeance.AjouterProfesseurASeance(seance, professeur);

            // Act
            gestionSeance.RetirerProfesseurDeSeance(seance, professeur);

            // Assert
            Assert.IsFalse(seance.Professeurs.Contains(professeur));
        }
        /// <summary>
        /// Teste qui ajoute un élève dans une séance de cours.
        /// </summary>
        [Test]
        public void AjouterEleveAUneSeance()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            Eleve eleve = new Eleve { Nom = "Durand", Prenom = "Marie" };

            // Act
            gestionSeance.AjouterEleveASeance(seance, eleve);

            // Assert
            Assert.IsTrue(seance.Eleves.Contains(eleve));
        }
        /// <summary>
        /// Teste qui retire un élève d'une séance de cours.
        /// </summary>
        [Test]
        public void RetirerEleveDeSeance()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            Eleve eleve = new Eleve { Nom = "Durand", Prenom = "Marie" };
            gestionSeance.AjouterEleveASeance(seance, eleve);

            // Act
            gestionSeance.RetirerEleveDeSeance(seance, eleve);

            // Assert
            Assert.IsFalse(seance.Eleves.Contains(eleve));
        }
        /// <summary>
        /// Teste qui ajoute une note a un élève d'une séance de cours.
        /// </summary>
        [Test]
        public void AjouterNoteAElevePourSeance()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            Eleve eleve = new Eleve { Nom = "Durand", Prenom = "Marie" };
            gestionSeance.AjouterEleveASeance(seance, eleve);
            Note note = new Note { Valeur = 15 };

            // Act
            gestionSeance.AjouterNoteAElevePourSeance(seance, eleve, note);

            // Assert
            Assert.IsTrue(eleve.Notes.Contains(note));
        }
        /// <summary>
        /// Teste qui retire une note mise a un élève dans une séance de cours.
        /// </summary>
        [Test]
        public void RetirerNoteDElevePourSeance()
        {
            // Arrange
            GestionSeance gestionSeance = new GestionSeance();
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            Eleve eleve = new Eleve { Nom = "Durand", Prenom = "Marie" };
            gestionSeance.AjouterEleveASeance(seance, eleve);
            Note note = new Note { Valeur = 15 };
            gestionSeance.AjouterNoteAElevePourSeance(seance, eleve, note);

            // Act
            gestionSeance.RetirerNoteDElevePourSeance(seance, eleve, note);

            // Assert
            Assert.IsFalse(eleve.Notes.Contains(note));
        }
        /// <summary>
        /// Teste qui vérifie si la seance est vide.
        /// </summary>
        [Test]
        public void VerifierSeance_SalleVide_RetourneFaux()
        {
            // Arrange
            var seance = new Seance(new DateTime(2024, 4, 10), 10);

            // Act
            var resultat = seance.VerifierNombreMaxAtteint();

            // Assert
            Assert.IsFalse(resultat, "La salle est vide, donc elle ne devrait pas être pleine.");
        }
        /// <summary>
        /// Teste qui vérifie si il y a au minimum un prof.
        /// </summary>
        [Tes t]
        public void VerifierPresenceDeMinimumUnProf_RetourneFaux()
        {
            // Arrange
            var profPresent = 1;

            // Act
            var seance = new Seance(new DateTime(2024, 4, 10), profPresent);

            // Assert
            Assert.IsFalse(seance.Professeurs.Count > 0, "Il doit y avoir au moins un professeur présent.");
        }
        /// <summary>
        /// Teste qui vérifie que dans un sénace qu'il y a au moin un élève.
        /// </summary>
        [Test]
        public void VerifierPresenceDeMinimumUnEleves_RetourneFaux()
        {
            // Arrange
            var elevesPresent = 20;

            // Act
            var seance = new Seance(new DateTime(2024, 4, 10), elevesPresent);

            // Assert
            Assert.IsFalse(seance.Eleves.Count > 0, "Il doit y avoir au moins un élève présent.");
        }
        /// <summary>
        /// Teste qui calcul la moyenne des notes d'une séance.
        /// </summary>
        [Test]
        public void CalculerLaMoyenneNotesDUneSeance()
        {
            // Arrange
            Seance seance = new Seance(new DateTime(2024, 4, 10), 10);
            seance.AjouterNote(new Note { Valeur = 10 });
            seance.AjouterNote(new Note { Valeur = 12 });
            seance.AjouterNote(new Note { Valeur = 14 });

            // Act
            double moyenne = seance.CalculerMoyenneNotes();

            // Assert
            Assert.AreEqual(12, moyenne, "La moyenne des notes de la séance est correcte.");
        }
        /// <summary>
        /// Teste qui vérifie la moyenne des notes d'un élève.
        /// </summary>
        [Test]
        public void CalculerMoyenneNotesUnEleve()
        {
            // Arrange
            Eleve eleve = new Eleve { Nom = "Durand", Prenom = "Marie" };
            eleve.AjouterNote(new Note { Valeur = 10 });
            eleve.AjouterNote(new Note { Valeur = 12 });
            eleve.AjouterNote(new Note { Valeur = 14 });

            // Act
            double moyenne = eleve.CalculerMoyenneNotes();

            // Assert
            Assert.AreEqual(12, moyenne, "La moyenne des notes de l'élève est correcte.");
        }
        /// <summary>
        /// Teste qui vérifie si il n'y a pas d'absence pendant une séance.
        /// </summary>
        [Test]
        public void VerifierPresenceDeTousLesElevesDansUneSeance_AvecAbsence_NotesAbsencesNonComptees()
        {
            // Arrange
            Seance seance = new Seance(new DateTime(2024, 4, 10), 5);
            Eleve eleve1 = new Eleve { Nom = "Durand", Prenom = "Marie" };
            Eleve eleve2 = new Eleve { Nom = "Dupont", Prenom = "Jean" };
            Eleve eleve3 = new Eleve { Nom = "Martin", Prenom = "Paul" };
            seance.AjouterEleve(eleve1);
            seance.AjouterEleve(eleve2);
            seance.AjouterEleve(eleve3);

            // Mock de la gestion des élèves
            var mockGestionEleve = new Mock<IGestionEleve>();
            mockGestionEleve.Setup(m => m.EstPresentDansSeance(It.IsAny<Eleve>(), It.IsAny<Seance>())).Returns(true);

            // Act
            var resultat = seance.VerifierPresenceDeTousLesEleves(mockGestionEleve.Object);

            // Assert
            Assert.IsTrue(resultat);
        }
    }
}




public class GestionSeance
{
    public List<Seance> ListeSeances { get; set; }

    public GestionSeance()
    {
        ListeSeances = new List<Seance>();
    }

    public void AjouterSeance(Seance seance)
    {
        ListeSeances.Add(seance);
    }

    public void RetirerSeance(Seance seance)
    {
        ListeSeances.Remove(seance);
    }

    public void AjouterProfesseurASeance(Seance seance, Professeur professeur)
    {
        seance.AjouterProfesseur(professeur);
    }

    public void RetirerProfesseurDeSeance(Seance seance, Professeur professeur)
    {
        seance.RetirerProfesseur(professeur);
    }

    public void AjouterEleveASeance(Seance seance, Eleve eleve)
    {
        seance.AjouterEleve(eleve);
    }

    public void RetirerEleveDeSeance(Seance seance, Eleve eleve)
    {
        seance.RetirerEleve(eleve);
    }

    public void AjouterNoteAElevePourSeance(Seance seance, Eleve eleve, Note note)
    {
        eleve.AjouterNotePourSeance(seance, note);
    }

    public void RetirerNoteDElevePourSeance(Seance seance, Eleve eleve, Note note)
    {
        eleve.RetirerNotePourSeance(seance, note);
    }
}

public class Seance
{
    public DateTime Date { get; set; }
    public int NombreMaxPlace { get; set; }
    public List<Professeur> Professeurs { get; set; }
    public List<Eleve> Eleves { get; set; }
    public List<Note> Notes { get; set; }

    public Seance(DateTime date, int nombreMaxPlace)
    {
        Date = date;
        NombreMaxPlace = nombreMaxPlace;
        Professeurs = new List<Professeur>();
        Eleves = new List<Eleve>();
        Notes = new List<Note>();
    }

    public bool VerifierNombreMaxAtteint()
    {
        return Eleves.Count >= NombreMaxPlace;
    }

    public double CalculerMoyenneNotes()
    {
        if (Notes.Count == 0)
            return 0;

        double total = 0;
        foreach (var note in Notes)
        {
            total += note.Valeur;
        }
        return total / Notes.Count;
    }

    public void AjouterProfesseur(Professeur professeur)
    {
        Professeurs.Add(professeur);
    }

    public void RetirerProfesseur(Professeur professeur)
    {
        Professeurs.Remove(professeur);
    }

    public void AjouterEleve(Eleve eleve)
    {
        Eleves.Add(eleve);
    }

    public void RetirerEleve(Eleve eleve)
    {
        Eleves.Remove(eleve);
    }

    public void AjouterNote(Note note)
    {
        Notes.Add(note);
    }
}

public class Professeur
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
}

public class Eleve
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public List<Note> Notes { get; set; }

    public Eleve()
    {
        Notes = new List<Note>();
    }

    public void AjouterNotePourSeance(Seance seance, Note note)
    {
        seance.AjouterNote(note);
        Notes.Add(note);
    }

    public void RetirerNotePourSeance(Seance seance, Note note)
    {
        seance.Notes.Remove(note);
        Notes.Remove(note);
    }

    public double CalculerMoyenneNotes()
    {
        if (Notes.Count == 0)
            return 0;

        double total = 0;
        foreach (var note in Notes)
        {
            total += note.Valeur;
        }
        return total / Notes.Count;
    }
}

public class Note
{
    public double Valeur { get; set; }
}
