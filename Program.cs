using System;

    //2/ // Énumération pour représenter les différents genres de livres
public enum GenreLivre
{
    ScienceFiction,
    Fiction,
    NonFiction,
    Autre 
}

//Partie 4 interface pour les objets (livres) empruntable
public interface LivreEmprunt
{
    void Emprunter();
    void Retourner();
}

//Partie 1 déclarer une classe livre argument (titre, année de publication et genre)
public class Livre {

    // 1/ déclaration des variable 
    public string Titre;
    public int AnneeDePublication;

    // erreur j'avais indqué string GenreLivre alors que c'est un objet. 
    public GenreLivre GenreLivre;

       // 1/bis Constructeur Livre et ses arguments
    //public Livre(string titre, int anneeDePublication, string genre)
    public Livre(string titre, int anneeDePublication, GenreLivre genre)
    {
        Titre = titre;
        AnneeDePublication = anneeDePublication;
        GenreLivre = genre;
    }

    //3 implémenter une méthode qui affiche les détails d'un livre
    public void AfficherDetails()
    {
        Console.WriteLine($"Titre: {Titre}");
        Console.WriteLine($"Année de publication: {AnneeDePublication}");
        Console.WriteLine($"Genre: {GenreLivre.ToString()}"); // Conversion explicite en string
    }
}  


//Partie 2 déclarer une classe livre argument (titre, année de publication et genre)
public class Membre
{
    // 1 attibuts et constructor
    public string Nom;
    public string Adresse;
    public int NbrMembre;

    // Constructeur
    public Membre(string nom, string adresse, int nbrMembre)
    {
        Nom = nom;
        Adresse = adresse;
        NbrMembre = nbrMembre;
    }


    // 2 implémenter une méthode qui affiche les détails
    public void AfficherDetails()
    {
        Console.WriteLine($"Nom du membre: {Nom}");
        Console.WriteLine($"Adresse du membre: {Adresse}");
        Console.WriteLine($"Numéro de membre: {NbrMembre}");
    }
}

/*Partie 3 déclarer une classe Bibliothèque (rattache classe Livre et membre)
public class Bibliotheque{
    private Livre[] livres;
    private Membre[] membres;
    private int nbrLivres;
    private int nbrMembres;

    // Constructor
    public Bibliotheque(int totaliteLivres, int totaliteMembres)
    {
        livres = new Livre[totaliteLivres];
        membres = new Membre[totaliteMembres];
        nbrLivres = 0;
        nbrMembres = 0;
    }

    // Méthode pour ajouter un livre à la bibliothèque
    public void AddLivre(Livre livre)
    {
        //ajout de livre par rapport à la taille du contenant (objet) => 
        if (nbrLivres < livres.Length)
        {
            livres[nbrLivres] = livre;
            nbrLivres++;
            Console.WriteLine("Ajout livre ");
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}*/



//partie 4 mofifier avec partie 6 classe LivreEmpruntable (en plus de herite classe Livre et interface Livre Emprunt)
public class LivreEmpruntable : Livre, LivreEmprunt {
    private bool estEmprunter;

    public LivreEmpruntable(string titre, int anneePublication, GenreLivre genre) : base(titre, anneePublication, genre)
    {
        estEmprunter = false;
    }

    public void Emprunter()
    {
        if (!estEmprunter)
        {
            estEmprunter = true;
            Console.WriteLine($"Le livre \"{Titre}\" a été emprunté.");
        }
        else
        {
            Console.WriteLine($"Le livre \"{Titre}\" est déjà emprunté.");
        }
    }

    public void Retourner()
    {
        if (estEmprunter)
        {
            estEmprunter = false;
            Console.WriteLine($"Le livre \"{Titre}\" a été retourné.");
        }
        else
        {
            Console.WriteLine($"Le livre \"{Titre}\" n'est pas actuellement emprunté.");
        }
    }
}

// Partie 5 Classe gestion des emprunts (class emprunt et retour)
public class GestionEmprunts
{
    public void EmprunterLivre(LivreEmprunt livre)
    {
        livre.Emprunter();
    }

    public void RetournerLivre(LivreEmprunt livre)
    {
        livre.Retourner();
    }
}


class Program
{
    static void Main(string[] args)
    {
        // partie 1 Exemple d'utilisation de la classe Livre
        Livre monLivre = new Livre("remy sans famille",1987, GenreLivre.Autre);
        monLivre.AfficherDetails();

        // partie 2 Exemple d'utilisation de la classe Membre
        Membre membre = new Membre("elodie nebulot", "8 rue robert", 67);
        membre.AfficherDetails();

        //partie 3 exemple d'emprunt et retour 
         LivreEmpruntable livre = new LivreEmpruntable("Fondation", 1951, GenreLivre.ScienceFiction);
         GestionEmprunts gestionnaire = new GestionEmprunts();
         gestionnaire.EmprunterLivre(livre); 
         gestionnaire.RetournerLivre(livre); 
    }
}



