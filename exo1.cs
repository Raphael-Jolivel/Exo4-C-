using System;
class Program
{
    static  void Mian(string[] args)
    {
        Console.WriteLine("Entrez votre age");
        int age = Convert.ToInt32(Console.ReadLine());
         
        Console.WriteLine("Entrez votre nom");
        string nom = Console.ReadLine();

        Console.WriteLine("Entrez votre prénom");
        string prenom = Console.ReadLine();

        Console.WriteLine("Entrez votre lieu de résidence");
        string adresse = Console.ReadLine();

        Console.WriteLine($"Bonjour{prenom + nom}");
        Console.Wirte($"tu as {age} ans et tu habites au {adresse}");

    }





}