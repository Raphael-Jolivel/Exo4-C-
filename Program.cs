#region Imports
using System.Globalization;
using ConsoleApp1;
using System.Linq;
#endregion

#region Lien du fichier CSV
string path = @"C:\Cours#\CoursSupDeVinci_C#.csv";
string[] lignes = File.ReadAllLines(path); 
#endregion

#region Saisie des informations de la classe
Console.WriteLine("Entrez le nom de la classe :");
string nomClasse = Console.ReadLine();

Console.WriteLine("Entrez le nom de l'école :");
string nomEcole = Console.ReadLine();

Console.WriteLine("Entrez le niveau :");
string niveau = Console.ReadLine();

Classe maClasse = new Classe();
maClasse.Nom = nomClasse;
maClasse.Ecole = nomEcole;
maClasse.Niveau = niveau;
#endregion

#region Lecture et création des élèves depuis le CSV
for (int i = 1; i < lignes.Length; i++)
{
    string line = lignes[i];
    Person person = new Person();

    person.Lastname = line.Split(',')[1];
    person.Firstname = line.Split(',')[2];
    person.Birthdate = ConvertToDateTime(line.Split(',')[3]);
    person.Size = int.Parse(line.Split(',')[5]);

    List<string> details = line.Split(',')[4].Split(';').ToList();
    person.AdressDetails = new Detail(details[0], int.Parse(details[1]), details[2]);

    maClasse.AjouterEleve(person);
}
#endregion

#region Calcul et affichage des personnes de Nantes plus grandes que la moyenne
double tailleMoyenne = maClasse.Eleves.Average(p => p.Size);

List<Person> promoNantes = maClasse.Eleves
    .Where(p => p.AdressDetails.City.ToLower() == "nantes" && p.Size > tailleMoyenne)
    .OrderByDescending(p => p.Size)
    .ToList();

for (int i = 0; i < promoNantes.Count; i++)
{
    Person personne = promoNantes[i];
    double tailleMetre = personne.Size / 100.0;
    Console.WriteLine($"{i + 1} - {personne.Firstname} - {tailleMetre.ToString("0.00").Replace('.', ',')}");
}
#endregion

#region Affichage récapitulatif de la classe
Console.WriteLine($"Classe : {maClasse.Nom} | Ecole : {maClasse.Ecole} | Niveau : {maClasse.Niveau} | Nombre d'élèves : {maClasse.Eleves.Count}");
#endregion

#region Conversion date de naissance
DateTime ConvertToDateTime(string date)
{
    if (DateTime.TryParse(date, out DateTime birthdate))
    {
        return birthdate;
    }
    else
    {
        Console.WriteLine($"La date de naissance est mal renseignée");
        return DateTime.Now;
    }
}
#endregion
