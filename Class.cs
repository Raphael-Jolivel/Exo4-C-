namespace ConsoleApp1;

#region Déclaration de la classe Classe
public class Classe
{
    #region Attributs privés
    private string nom;
    private string ecole;
    private string niveau;
    private List<Person> eleves = new List<Person>();
    #endregion

    #region Propriétés publiques
    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Ecole
    {
        get => ecole;
        set => ecole = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Niveau
    {
        get => niveau;
        set => niveau = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Person> Eleves
    {
        get => eleves;
        set => eleves = value ?? throw new ArgumentNullException(nameof(value));
    }
    #endregion
    
    #region Méthodes
    public void AjouterEleve(Person p)
    {
        Eleves.Add(p);
    }
    #endregion
}
#endregion