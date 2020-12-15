using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_TPSIT_4H_BartoliniLiam_gestionepersonale.Models
{
    class Dipendente
    {
        char[] lettere = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        List<char> vocali = new List<char>() { 'A', 'E', 'I', 'O', 'U' };
        StringBuilder sb = new StringBuilder();

        string _nome;
        public string Nome { get => _nome; set => _nome = value; }

        string _cognome;
        public string Cognome { get => _cognome; set => _cognome = value; }

        string _sesso;
        public string Sesso { get => _sesso; set => _sesso = value; }

        DateTime _dataDiNascita;
        public DateTime DataDiNascita { get => _dataDiNascita; set => _dataDiNascita = Convert.ToDateTime(value); }

        string _numeroCellulare;
        public string NumeroCellulare { get => _numeroCellulare; set => _numeroCellulare = value; }

        string _userName;
        public string UserName { get => _userName; set => _userName = value; }

        string _password;
        public string Password { get => _password; private set => _password = value; }

        string _reparto;
        public string Reparto { get => _reparto; set => _reparto = value; }

        string _azienda;
        public string Azienda { get => _azienda; set => _azienda = value; }

        string _comune;
        public string Comune { get => _comune; set => _comune = value; }

        string _domicilio;
        public string Domicilio { get => _domicilio; set => _domicilio = value; }

        string _codiceFiscale;
        public string CodiceFiscale { get => _codiceFiscale; set => _codiceFiscale = value; }

        static int _dipendenti = 0;

        // Costruttore di default
        public Dipendente()
        {
            // Imposto username a psw per il primo accesso
            UserName = "UserName";
            Password = "Psw";
            DataDiNascita = Convert.ToDateTime("10/10/10");

            _dipendenti++;
        }

        public Dipendente(string nome, string cognome, string sesso, string data, string cellulare, string user, string psw, string azienda, string reparto, string comune, string domicilio)
        {
            Nome = nome;
            Cognome = cognome;
            Sesso = sesso;

            DataDiNascita = Convert.ToDateTime(data);
            NumeroCellulare = "+39 " + cellulare;

            UserName = user;
            Password = psw;

            Azienda = azienda;
            Reparto = reparto;

            Comune = comune;
            Domicilio = domicilio;

            // Calcolo il codice fiscale
            CalcoloCodiceFiscale();
            _dipendenti++;
        }

        public string AggiungiDati(string nome, string cognome, string sesso, string data, string cellulare, string azienda, string reparto, string comune, string domicilio)
        {
            Nome = nome;
            Cognome = cognome;
            Sesso = sesso;
            DataDiNascita = Convert.ToDateTime(data);
            NumeroCellulare = cellulare;
            Azienda = azienda;
            Reparto = reparto;
            Comune = comune;
            Domicilio = domicilio;

            CalcoloCodiceFiscale();
            return "Dati aggiunti correttamente, riaccedere al profilo!";
        }

        public string ModificaDati(string user, string psw, string reparto)
        {
            UserName = user;
            Password = psw;
            Reparto = reparto;

            return $"Modifica dati eseguita correttamente, riaccedere al profilo!";
        }

        public bool Autenticazione(string username, string password) => (UserName == username && Password == password) ? true : false;

        // Pulisco tutti i campi
        public string EliminazioneDati()
        {
            Nome = "";
            Cognome = "";

            // Inserisco una data finta per poterla elimare in fase di stampa
            DataDiNascita = Convert.ToDateTime("10/10/10");
            NumeroCellulare = "";

            UserName = "";
            Password = "";

            Reparto = "";

            Domicilio = "";
            CodiceFiscale = "";

            return "Dati Eliminati Correttamente";
        }

        public string VisualizzazioneDati()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Dipendente n°: \t\t{_dipendenti}");
            sb.AppendLine($"Nome:\t\t\t{Nome}");
            sb.AppendLine($"Cognome:\t\t{Cognome}");

            if (DataDiNascita.ToString() != "10/10/10")
                sb.AppendLine($"Data di Nascita:\t{DataDiNascita:dd/MM/yyyy}");
            else
                sb.AppendLine($"Data di Nascita:");

            sb.AppendLine($"Numero di Cellulare:\t{NumeroCellulare}");
            sb.AppendLine($"Reparto:\t\t{Reparto}");
            sb.AppendLine($"Comune:\t\t\t{Comune}");
            sb.AppendLine($"Domicilio:\t\t{Domicilio}");
            sb.AppendLine($"Codice Fiscale:\t\t{CodiceFiscale}");

            return sb.ToString();
        }

        public string StampaTesseraSanitaria()
        {
            StringBuilder sb = new StringBuilder();

            SetColor(ConsoleColor.Blue);

            sb.AppendLine("\t\t\tFronte\t\t\t\t\t ");
            sb.AppendLine("-----------------------------------------------------------------");
            sb.AppendLine($"|\t\tTESSERA SANITARIA\t\t\t\t|");
            sb.AppendLine($"|\t\t\tCodice {CodiceFiscale}\t\tSesso {Sesso} |");
            sb.AppendLine($"|\t\t\tFiscale\t\t\t\t\t|");
            sb.AppendLine($"|\t\t\t\t\t\t\t\t|");

            sb.AppendLine($"|\t\t\tCognome  {Cognome.ToUpper()}\t\t\t|");
            sb.AppendLine($"|\t\t\t\t\t\t\t\t|");

            sb.AppendLine($"|\t\t\tNome     {Nome.ToUpper()}\t\t\t|");
            sb.AppendLine($"|\t\t\t\t\t\t\t\t|");

            sb.AppendLine($"|Data di\t\tLuogo    {Comune.ToUpper()}\t\t\t\t|");
            sb.AppendLine($"|Scadenza\t\tdi nascita\t\t\t\t|");
            sb.AppendLine($"|\t\t\t\t\t\t\t\t|");

            sb.AppendLine($"|  {DateTime.Today.AddYears(18):dd/MM/yyyy}\t\t\t\t\t\t\t|");
            sb.AppendLine($"|\t\t\tProvinca {Comune.ToUpper()}\t\t\t\t|");
            sb.AppendLine($"|\t\t\t\t\t\t\t\t|");

            sb.AppendLine($"|\t\t\tData   {DataDiNascita:dd/MM/yyyy}\t\t\t|");
            sb.AppendLine($"|\t\t\tdi nascita\t\t\t\t|");
            sb.AppendLine("-----------------------------------------------------------------");
            sb.AppendLine("\n");


            sb.AppendLine("\t\t\tRetro\t\t\t\t\t   ");
            sb.AppendLine("-------------------------------------------------------------------");
            sb.AppendLine($"|\tTESSERA EUROPEA DI ASSICURAZIONE MALATTIA\t\t  |");
            sb.AppendLine($"|█████████████████████████████████████████████████████████████████|");
            sb.AppendLine($"|   ■■■   ││|│|││|||││||│││││||││||||│|│|│|││││||\t■\t  |");

            sb.AppendLine($"|3 Cognome\t\t\t\t\t\t\t  |");
            sb.AppendLine($"|{Cognome.ToUpper()}\t\t\t\t\t\t\t  |");

            sb.AppendLine($"|4 Nome\t\t\t\t\t\t5 Data di nascita |");
            sb.AppendLine($"|{Nome.ToUpper()}\t\t\t\t\t\t{DataDiNascita:dd/MM/yyyy}|");

            sb.AppendLine($"|6 identificazione personale\t7 identificazione dell'istituzione|");
            sb.AppendLine($"|{CodiceFiscale}\t\t\tSSN-MIN SALUTE - 500001   |");

            sb.AppendLine($"|8 identificazione tessera\t\t\t9 Scadenza\t  |");
            sb.AppendLine($"|NaN\t\t\t\t\t{DateTime.Today.AddYears(18):dd/MM/yyyy}\t\t  |");
            sb.AppendLine("-------------------------------------------------------------------");

            void SetColor(ConsoleColor color) { Console.BackgroundColor = color; }

            return sb.ToString();
        }

        public void CalcoloCodiceFiscale()
        {
            List<char> mesi = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T' };

            char[] cognomeChar = Cognome.ToUpper().ToCharArray();
            int contCognome = 0;

            char[] nomeChar = Nome.ToUpper().ToCharArray();
            int contNome = 0;

            int numConsonanti = ContaConsonanti(Cognome);

            //#####COGNOME######
            if (numConsonanti >= 3)
            {

                for (int i = 0; i < cognomeChar.Length; i++)
                {
                    if (contCognome < 3)
                    {
                        if (!vocali.Contains(cognomeChar[i]))
                        {
                            sb.Append(cognomeChar[i]);
                            contCognome++;
                        }
                    }
                }
            }
            else if (numConsonanti == 2)
            {
                for (int j = 0; j < cognomeChar.Length; j++)
                {
                    if (!vocali.Contains(cognomeChar[j]))
                    {
                        sb.Append(cognomeChar[j]);
                        contCognome++;
                    }
                }
            }
            else if (numConsonanti < 2)
            {
                for (int j = 0; j < cognomeChar.Length; j++)
                {
                    if (!vocali.Contains(cognomeChar[j]))
                    {
                        sb.Append(cognomeChar[j]);
                        contCognome++;
                        break;
                    }
                }
            }

            // Aggiungo eventuali vocali
            if (contCognome < 3)
            {
                for (int i = 0; i < cognomeChar.Length; i++)
                {
                    if (contCognome <= 3)
                    {
                        if (vocali.Contains(cognomeChar[i]))
                        {
                            sb.Append(cognomeChar[i]);
                            contCognome++;
                        }
                    }
                }
            }

            // Aggiungo eventuali 'X'
            if (contCognome < 3)
            {
                for (int i = contCognome; i < 3; i++)
                {
                    sb.Append('X');
                }
            }

            //########NOME###### |||| NECESSARIE 1a 3a 4a
            numConsonanti = ContaConsonanti(Nome);
            int contConsonanti = 0;

            bool exit = false;

            // Controllo il numero di consonanti e faccio gli oppurtuni calcoli
            if (numConsonanti >= 3)
            {
                for (int i = 0; i < nomeChar.Length; i++)
                {
                    if (contNome <= 3)
                    {
                        if (!vocali.Contains(nomeChar[i]))
                        {
                            // Se la consonante che trovo è la seconda consonante la devo saltare
                            if (contConsonanti != 1)
                            {
                                sb.Append(nomeChar[i]);
                                contNome++;
                                contConsonanti++;
                            }
                            else
                            {
                                // Va a cercare un'altra consonante nella parola se non la trova esce da tutto e va ad aggiungere le vocali o le 'X'
                                for (int k = i + 1; k < nomeChar.Length; k++)
                                {
                                    if (!vocali.Contains(nomeChar[k]))
                                    {
                                        sb.Append(nomeChar[k]);
                                        contNome++;
                                        contConsonanti++;
                                    }

                                    if (contNome == 3)
                                    {
                                        exit = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    // Se non trova altre consonanti esce dal ciclo
                    if (exit)
                        break;
                }
            }
            else if (numConsonanti == 2)
            {
                for (int j = 0; j < nomeChar.Length; j++)
                {
                    if (!vocali.Contains(nomeChar[j]))
                    {
                        sb.Append(nomeChar[j]);
                        contNome++;
                    }
                }
            }
            else if (numConsonanti < 2)
            {
                for (int j = 0; j < nomeChar.Length; j++)
                {
                    if (!vocali.Contains(nomeChar[j]))
                    {
                        sb.Append(nomeChar[j]);
                        contNome++;
                        break;
                    }
                }
            }

            bool flagNome = false;

            if (contCognome + contNome < 6)
            {
                // aggiungo eventuali vocali
                if (contNome < 3)
                {
                    for (int i = 0; i < nomeChar.Length; i++)
                    {
                        if (contNome + contCognome < 6)
                        {
                            if (contNome <= 3)
                            {
                                if (vocali.Contains(nomeChar[i]))
                                {
                                    sb.Append(nomeChar[i]);
                                    contNome++;
                                }
                            }
                            flagNome = true;
                        }
                    }
                }

                if (!flagNome)
                {
                    // Aggiungo eventuali 'X'
                    if (contNome < 3)
                    {
                        for (int i = 0; i < nomeChar.Length; i++)
                        {
                            if (vocali.Contains(nomeChar[i]))
                            {
                                sb.Append(nomeChar[i]);
                                contNome++;
                            }
                        }
                    }
                }
            }
            //##################

            // Aggiungo l'anno
            sb.Append($"{DataDiNascita:yy}");

            // Aggiungo il mese
            sb.Append($"{mesi[DataDiNascita.Month - 1]}");

            // Controllo il sesso e aggiungo il giorno
            if (Sesso == "M")
                sb.Append($"{DataDiNascita:dd}");
            else
                sb.Append($"{DataDiNascita.Day + 40}");

            // Aggiungo il comune
            sb.Append("H294");

            // Calcolo ed inserisco la lettera di controllo
            int controllChar = CalcoloLetteraControlloCF();
            sb.Append(lettere[controllChar]);

            CodiceFiscale = sb.ToString();
        }

        int CalcoloLetteraControlloCF()
        {
            int[] dispari = new int[] { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };

            char[] CFChar = sb.ToString().ToCharArray();

            int retVal = 0;

            int lenght = sb.ToString().Length;

            for (int i = 0; i < lenght; i++)
            {
                // Lo zero è considerato numero dispari
                if ((i + 1) == 1)
                {
                    for (int j = 0; j < lettere.Length; j++)
                    {
                        if (CFChar[i] == lettere[j])
                        {
                            retVal += dispari[j];
                            break;
                        }
                    }
                }
                else
                {
                    // Se è pari la posizione, la conversione al numero non richiede tabella
                    if ((i + 1) % 2 == 0)
                    {
                        // Controllo se è un numero altrimentro controllo la lettera
                        if (Char.IsNumber(CFChar[i]))
                        {
                            int.TryParse(CFChar[i].ToString(), out int parsed);
                            retVal += parsed;
                        }
                        else
                        {
                            for (int j = 0; j < lettere.Length; j++)
                            {
                                if (CFChar[i] == lettere[j])
                                {
                                    retVal += j;
                                    break;
                                }
                            }
                        }
                    }
                    else // La conversione per un numero in posizione dispari richiede la tabella di conversione (dispari[])
                    {
                        // Controllo se è un numero
                        if (Char.IsNumber(CFChar[i]))
                        {
                            int.TryParse(CFChar[i].ToString(), out int parsed);
                            retVal += dispari[parsed];
                        }
                        else
                        {
                            for (int j = 0; j < lettere.Length; j++)
                            {
                                if (CFChar[i] == lettere[j])
                                {
                                    retVal += dispari[j];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            // Ritorno il resto
            return retVal % 26;
        }

        int ContaConsonanti(string s)
        {
            int retVal = 0;
            char[] sChar = s.ToUpper().ToCharArray();

            for (int i = 0; i < sChar.Length; i++)
            {
                // Se nella lista non è presente la lettera considerata allora è una consonante
                if (!vocali.Contains(sChar[i]))
                    retVal++;
            }

            return retVal;
        }
    }
}
