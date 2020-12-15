using System;
using AS2021_TPSIT_4H_BartoliniLiam_gestionepersonale.Models;

namespace AS2021_TPSIT_4H_BartoliniLiam_gestionepersonale
{
    class Program
    {
        static void Main(string[] args)
        {
            Dipendente dipendente = new Dipendente();
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
                    Console.WriteLine($"Accesso Eseguito come {dipendente.Nome} {dipendente.Cognome}");

                    // Imposto una bandierina che mi permette di capire se l'utente ha fatto il logIn
                    flag = true;
                    break;
                }
                else
                    Console.WriteLine("Accesso negato, ricontrollare Username e password!");
            }

            if (flag)
            {
                flag = false;

                Console.WriteLine(dipendente.VisualizzazioneDati());

                Console.WriteLine(dipendente.AggiungiDati(
                    "Francesca",
                    "Tiraferri",
                    "F",
                    "06/01/1980",
                    "6512356",
                    "ITTS Rimin O.Belluzzi L.DaVinci",
                    "4H",
                    "Rimini",
                    "Via Tambroni, 9"
                    ));

                Console.WriteLine(dipendente.ModificaDati
                    (
                        "User",
                        "Psw",
                        "4H"
                    ));

                while (true)
                {
                    Console.Write("Username: ");
                    strUser = Console.ReadLine();

                    Console.Write("Password: ");
                    strPass = Console.ReadLine();

                    if (dipendente.Autenticazione(strUser, strPass))
                    {
                        Console.WriteLine($"Accesso Eseguito come {dipendente.Nome} {dipendente.Cognome}");
                        flag = true;
                    }
                    else
                        Console.WriteLine("Accesso negato, ricontrollare Username e password");

                    if (flag)
                        break;
                }

                Console.WriteLine(dipendente.VisualizzazioneDati());
                Console.WriteLine(dipendente.StampaTesseraSanitaria());

                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}
