namespace ProgettoSettimanale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("\r\n /$$$$$$$                                                         /$$             \r\n| $$__  $$                                                       | $$             \r\n| $$  \\ $$ /$$$$$$ /$$$$$$$ /$$    /$$/$$$$$$ /$$$$$$$ /$$   /$$/$$$$$$   /$$$$$$ \r\n| $$$$$$$ /$$__  $| $$__  $|  $$  /$$/$$__  $| $$__  $| $$  | $|_  $$_/  /$$__  $$\r\n| $$__  $| $$$$$$$| $$  \\ $$\\  $$/$$| $$$$$$$| $$  \\ $| $$  | $$ | $$   | $$  \\ $$\r\n| $$  \\ $| $$_____| $$  | $$ \\  $$$/| $$_____| $$  | $| $$  | $$ | $$ /$| $$  | $$\r\n| $$$$$$$|  $$$$$$| $$  | $$  \\  $/ |  $$$$$$| $$  | $|  $$$$$$/ |  $$$$|  $$$$$$/\r\n|_______/ \\_______|__/  |__/   \\_/   \\_______|__/  |__/\\______/   \\___/  \\______/ \r\n                                                                                  \r\n                                                                                  \r\n                                                                                  \r\n");
            Console.WriteLine("******************* Il tuo calcolatore d'imposte preferito <3 *******************  \n\r -Guarda quanto devi piangere quest'anno \n\r -Premi un tasto per continuare");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Inserire il nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserire cognome");
            string cognome = Console.ReadLine();

            DateTime dataNascita;
            while (true)
            {
                Console.Write("Inserisci la data di nascita (formato GG/MM/AAAA):");
                string inputDataNascita = Console.ReadLine();

                if (DateTime.TryParseExact(inputDataNascita, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascita))
                {
                    if (CalcolaEta(dataNascita) >= 18)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Devi essere maggiorenne. Riprova.");
                    }
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Riprova.");
                }
            }
            string codiceFiscale;
            while (true)
            {
                Console.WriteLine("Inserire codice fiscale");
                codiceFiscale = Console.ReadLine();

                if (VerificaCodiceFiscale(codiceFiscale))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Codice fiscale di 16 cifre inserito non corretto, riprovare");
                }
            }


            string sesso;
            while (true)
            {
                Console.WriteLine("Inserire sesso (maschio, femmina, altro)");
                sesso = Console.ReadLine().ToLower();

                if (sesso == "maschio" || sesso == "femmina" || sesso == "altro")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sesso inserito non corretto, riprovare");
                }
            }

            Console.WriteLine("Inserire Comune di Residenza");
            string comuneResidenza = Console.ReadLine();

            double redditoAnnuale;
            while (true)
            {
                Console.WriteLine("Inserire reddito ");
                string redditoInput = Console.ReadLine();

                if (double.TryParse(redditoInput, out redditoAnnuale) && redditoAnnuale > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Inserire un valore numerico valido e maggiore di zero.");
                }
            }

            static int CalcolaEta(DateTime dataNascita)
            {
                DateTime oggi = DateTime.Now;
                int eta = oggi.Year - dataNascita.Year;

                if (oggi.Month < dataNascita.Month || (oggi.Month == dataNascita.Month && oggi.Day < dataNascita.Day))
                {
                    eta--;
                }

                return eta;
            }

            Contribuente contribuente1 = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            if (contribuente1.RedditoAnnuale > 0 && contribuente1.RedditoAnnuale <= 15000)
            {
                contribuente1.CalcoloImposte(0, 23, 0);
            }
            else if (contribuente1.RedditoAnnuale >= 15001 && contribuente1.RedditoAnnuale <= 28000)
            {
                contribuente1.CalcoloImposte(15001, 27, 3450);
            }
            else if (contribuente1.RedditoAnnuale >= 28001 && contribuente1.RedditoAnnuale <= 55000)
            {
                contribuente1.CalcoloImposte(28001, 38, 6960);
            }
            else if (contribuente1.RedditoAnnuale >= 55001 && contribuente1.RedditoAnnuale <= 75000)
            {
                contribuente1.CalcoloImposte(55001, 41, 17220);
            }
            else
            {
                contribuente1.CalcoloImposte(75001, 43, 25420);
            }

            contribuente1.MostraDati();
        }

        static bool VerificaCodiceFiscale(string codiceFiscale)
        {
            return codiceFiscale.Length == 16;
        }
        class Contribuente
        {
            string _nome;
            string _cognome;
            DateTime _dataNascita;
            string _codiceFiscale;
            string _sesso;
            string _comuneResidenza;
            double _redditoAnnuale;

            public string Nome
            {
                get { return _nome; }
                set { _nome = value; }
            }

            public string Cognome
            {
                get { return _cognome; }
                set { _cognome = value; }
            }

            public DateTime DataNascita
            {
                get { return _dataNascita; }
                set { _dataNascita = value; }
            }

            public string CodiceFiscale
            {
                get { return _codiceFiscale; }
                set { _codiceFiscale = value; }
            }
            public string Sesso
            {
                get { return _sesso; }
                set { _sesso = value; }

            }
            public string ComuneResidenza
            {
                get { return _comuneResidenza; }
                set { _comuneResidenza = value; }
            }

            public double RedditoAnnuale
            {
                get { return _redditoAnnuale; }
                set { _redditoAnnuale = value; }

            }

            public double TotTax { get; set; }

            public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double redditoAnnuale)
            {
                Nome = nome;
                Cognome = cognome;
                DataNascita = dataNascita;
                CodiceFiscale = codiceFiscale;
                Sesso = sesso;
                ComuneResidenza = comuneResidenza;
                RedditoAnnuale = redditoAnnuale;
            }

            public void CalcoloImposte(int rangeMin, int aliquota, int tassaFissa)
            {
                double eccedenza = RedditoAnnuale - rangeMin;
                double tax = eccedenza * aliquota / 100;
                TotTax = tax + tassaFissa;
            }

            public void MostraDati()
            {
                Console.WriteLine($"Contribuente: {Nome} {Cognome}");
                Console.WriteLine($"Nat* il: {DataNascita:dd/MM/yyyy} ");
                Console.WriteLine($"Codice fiscale {CodiceFiscale} ");
                Console.WriteLine($"Sesso {Sesso} ");
                Console.WriteLine($"Residente in: {ComuneResidenza} ");
                Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale} ");
                Console.WriteLine($"Imposta totale: {TotTax} ");
            }
        }
    }
}