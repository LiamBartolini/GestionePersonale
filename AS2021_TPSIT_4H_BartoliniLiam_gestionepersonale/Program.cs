using System;
using AS2021_TPSIT_4H_BartoliniLiam_gestionepersonale.Models;

namespace AS2021_TPSIT_4H_BartoliniLiam_gestionepersonale
{
    class Program
    {
        static void Main(string[] args)
        {
            // Credo un dipendente senza codice fiscale (verrà generato alla riga 62)
            Dipendente dipendente = new Dipendente();
            Dipendente.NuovoDipendente();

            // Creo un dipendente ed in automatico gli assegnoil codice fiscale
            Dipendente dipendente1 = new Dipendente(
                "Lorenzo",
                "Bartolini",
                "M",
                "02/11/1974",
                "32165448",
                "provaU",
                "provaP",
                "SCM",
                "Macchine a controllo numerico",
                "Rimini",
                "Via Tambroni, 9"
                );

            Dipendente.NuovoDipendente();

            bool flag = false;
            string strUser = "";
            string strPass = "";

            while (true)
            {
                Console.Write("Username: ");
                strUser = Console.ReadLine();

                Console.Write("Password: ");
                strPass = Console.ReadLine();

                if (dipendente.Autenticazione(strUser, strPass))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Accesso Eseguito come {dipendente.Nome} {dipendente.Cognome}");

                    // Imposto una bandierina che mi permette di capire se l'utente ha fatto il logIn
                    flag = true;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Accesso negato, ricontrollare Username e password!");
                    Console.ResetColor();
                }
            }

            Console.ResetColor();

            if (flag)
            {
                flag = false;

                // Stampo i dati riferiti ad un dipendente
                Console.WriteLine(dipendente.VisualizzazioneDati());

                // Aggiungo i dati e genero il CF
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(dipendente.AggiungiDati(
                    "Liam",
                    "Bartolini",
                    "M",
                    "29/01/2003",
                    "6512356",
                    "ITTS Rimin O.Belluzzi L.DaVinci",
                    "4H",
                    "Rimini",
                    "Via Tambroni, 9"
                    ));

                // Ne modifico modifico username psw e reparto (se scrivo [""] vegono lasciati i valori di default
                Console.WriteLine(dipendente.ModificaDati(
                        "liam",
                        "bartolini",
                        "5H"
                    ));

                Console.ResetColor();
                while (true)
                {
                    Console.Write("\nUsername: ");
                    strUser = Console.ReadLine();

                    Console.Write("Password: ");
                    strPass = Console.ReadLine();

                    if (dipendente.Autenticazione(strUser, strPass))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nAccesso Eseguito come {dipendente.Nome} {dipendente.Cognome}");
                        flag = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Accesso negato, ricontrollare Username e password!");
                    }

                    Console.ResetColor();

                    if (flag)
                        break;
                }

                Console.WriteLine("\n"+dipendente.VisualizzazioneDati());
                Console.WriteLine(dipendente.StampaTesseraSanitaria());
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }
}
