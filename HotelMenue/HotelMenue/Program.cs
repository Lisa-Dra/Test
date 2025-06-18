
using System;

namespace HotelMenue
{
    internal class Program
    {
        static int maxCustomers = 100;
        static int roomCount = 10;
        static string[,] customers = new string[10, 5]{
    {"1", "Max", "Mustermann", "12 Musterweg", "j" },
    {"2", "Max", "Mustermann", "8 Augustinenweg", "n" },
    {"3", "Julia", "Musterfrau", "3 Ringstraße", "j" },
    {"4", "Lisa", "Meier", "14 Tulpenweg", "n"},
    {"5",  "Paul", "Huber", "10 Feldstraße", "j" },
    {"6",  "Anna", "Schmidt", "22 Bahnhofstraße", "n" },
    {"7",  "Tom", "Maier", "5 Wiesenweg", "n"},
    {"8",  "Laura", "Klein", "7 Gartenstraße", "j" },
    {"9",  "Michael", "Schulz", "88 Hauptstraße", "j" },
    {"10",  "Eva", "Berg", "1 Sonnenweg", "n" }
};
        static string[,] rooms = new string[roomCount, 5];
        static int customerCount = 10;
        static string status = "frei";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            InitializeRooms(roomCount);
            StartMenu();
        }
        static void StartMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("=== Hotel Vallora - Buchhaltungssystem === \n");
                Console.WriteLine("1. Kunden verwalten");
                Console.WriteLine("2. Zimmer verwalten");
                Console.WriteLine("3. Rechnung erstellen");
                Console.WriteLine("4. Statistiken anzeigen");
                Console.WriteLine("5. Programm beenden \n");
                Console.Write("Auswahl: ");
                String option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        CustomerManagement();
                        break;
                    case "2":
                        RoomManagement();
                        Console.WriteLine();
                        break;
                    case "3":
                        CreateBill();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Nicht bereitgestellt \n");
                        break;
                    case "5":
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Keine Option \n");
                        break;

                }
            }
        }
        static void CustomerManagement()
        {
            bool menu = false;
            while (!menu)
            {
                Console.WriteLine("=== Kundenverwaltung ===");
                Console.WriteLine();
                Console.WriteLine("1. Kunde hinzufügen");
                Console.WriteLine("2. Kundenliste anzeigen");
                Console.WriteLine("3. Kunden suchen");
                Console.WriteLine("4. Kunde bearbeiten");
                Console.WriteLine("5. Zurück zum hauptmenü");
                Console.WriteLine();
                Console.Write("Auswahl: ");

                var option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        DisplayCustomers();
                        break;
                    case "3":
                        SearchCustomer();
                        break;
                    case "4":
                        ChangeCustomer();
                        Console.WriteLine();
                        break;
                    case "5":
                        menu = true;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe \n");
                        break;
                }
            }
        }
        static void AddCustomer()
        {

            Console.WriteLine("=== Kunde hinzufügen === \n");
            Console.Write("Vorname: ");
            string firstName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Ungültige Eingabe");
                Console.Write("Vorname: ");
                firstName = Console.ReadLine();

            }

            Console.Write("Nachname: ");
            string lastName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Ungültige Eingabe");
                Console.Write("Nachname: ");
                lastName = Console.ReadLine();
            }

            Console.Write("Adresse: ");
            string address = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Ungültige Eingabe");
                Console.Write("Adresse: ");
                address = Console.ReadLine();
            }

            Console.Write("Stammkunde (j/n): ");
            string regular = Console.ReadLine();
            while (regular.ToLower() != "j" && regular.ToLower() != "n")
            {
                Console.WriteLine("Ungültige Eingabe");
                Console.Write("Stammkunde (j/n): ");
                regular = Console.ReadLine();
            }

            customers[customerCount, 0] = Convert.ToString(customerCount + 1);
            customers[customerCount, 1] = firstName;
            customers[customerCount, 2] = lastName;
            customers[customerCount, 3] = address;

            if (regular.ToLower() == "j")
            {
                customers[customerCount, 4] = "Stammkunde";
            }
            else
            {
                customers[customerCount, 4] = "kein Stammkunde";
            }

            customerCount++;
            Console.WriteLine();
            Console.WriteLine("Kunde erfolgreich hinzugefügt");
            Console.WriteLine("Drücken die eine Beliebige Taste um zur Kundenverwaltung zu kommen");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        static void SearchCustomer()
        {
          
                Console.WriteLine("Geben Sie (Teil von) Vor- oder Nachnamen der gesuchten Person ein: ");
                string searchedName = Console.ReadLine().Trim().ToLower();
                bool found = false;

                for (int i = 0; i < customerCount; i++)
                {
                    
                    string fullName = (customers[i, 1] + customers[i, 2]).Replace(" ", "").ToLower();

                    if (fullName.Contains(searchedName))
                    {
                        found = true;
                        Console.WriteLine($"{customers[i, 1]} {customers[i, 2]} – {customers[i, 3]} – " +
                                          $"{(customers[i, 4])}");
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Kein Kunde gefunden");
                }

                Console.WriteLine("Drücken Sie eine beliebige Taste, um zur Kundenverwaltung zurückzukehren.");
                Console.ReadKey();
                Console.Clear();
            

        }
        static void ChangeCustomer()
        {
            Console.WriteLine("Geben Sie eine Kundennummer ein: ");
            int customerSelected = Convert.ToInt32(Console.ReadLine());
            if (customers[customerSelected - 1, 0] != null)
            {
                for (int j = 0; j < customers.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write("[" + customers[customerSelected - 1, j] + "] ");
                    }
                    else
                    {
                        Console.Write(customers[customerSelected - 1, j] + " ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Neuer Vorname (Leer lassen bei keiner Änderung): ");
                string firstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    customers[customerSelected - 1, 1] = firstName;
                }
                Console.WriteLine("Neuer Nachname (Leer lassen bei keiner Änderung): ");
                string lastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    customers[customerSelected - 1, 2] = lastName;
                }
                Console.WriteLine("Neue Adresse (Leer lassen bei keiner Änderung): ");
                string address = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(address))
                {
                    customers[customerSelected - 1, 3] = address;
                }
                Console.WriteLine("Stammkunde: (Leer lassen bei keiner Änderung): ");
                string regular = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(regular))
                {
                    while (regular.ToLower() != "j" && regular.ToLower() != "n")
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Console.Write("Stammkunde: (Leer lassen bei keiner Änderung): ");
                        regular = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(regular))
                        {
                            return;
                        }
                    }

                    if (regular.ToLower() == "j")
                    {
                        customers[customerSelected - 1, 4] = "Stammkunde: Ja";
                    }
                    else if (regular.ToLower() == "n")
                    {
                        customers[customerSelected - 1, 4] = "Stammkunde: Nein";
                    }
                }

                Console.WriteLine("Kunde erfolgreich bearbeitet");
            }
            else
            {
                Console.WriteLine("Kunde nicht vorhanden");
            }
            Console.WriteLine("Drücken die eine Beliebige Taste um zur Kundenverwaltung zu kommen");
            Console.ReadKey();
            Console.Clear();

        }
        static void DisplayCustomers()
        {
            for (int i = 0; i < customerCount; i++)
            {
                for (int j = 0; j < customers.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write("[" + customers[i, j] + "] ");
                    }
                    else
                    {
                        Console.Write(customers[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void RoomManagement()
        {

            bool menu = false;
            while (!menu)
            {
                Console.WriteLine("=== Zimmerverwaltung ===");
                Console.WriteLine();
                Console.WriteLine("1. Zimmerliste anzeigen");
                Console.WriteLine("2. Zimmer buchen/stornieren");
                Console.WriteLine("3. Zimmerpreise anpassen");
                Console.WriteLine("4. Zurück zum hauptmenü");
                Console.WriteLine();
                Console.Write("Auswahl: ");

                var option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        DisplayRooms();
                        break;
                    case "2":
                        BookRoom();
                        break;
                    case "3":
                        ChangePrize();
                        Console.WriteLine();
                        break;
                    case "4":
                        menu = true;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe \n");
                        break;
                }
            }

        }
        static void InitializeRooms(int roomCount)
        {
            for (int i = 0; i < roomCount; i++)
            {
                rooms[i, 0] = $"Zimmer {i + 1} : ";
                if (i <= 0.05 * roomCount)
                {
                    rooms[i, 1] = "Suite ";
                    rooms[i, 2] = "250 Euro pro Nacht ";
                }
                else if (i <= 0.35 * roomCount)
                {
                    rooms[i, 1] = "Doppelzimmer ";
                    rooms[i, 2] = "120 Euro pro Nacht ";
                }
                else
                {
                    rooms[i, 1] = "Einzelzimmer ";
                    rooms[i, 2] = "80 Euro pro Nacht ";
                }
                rooms[i, 3] = status;


            }

        }
        static void DisplayRooms()
        {
            Console.WriteLine("=== Zimmerübersicht ===");

            Console.WriteLine("{0,-12} | {1,-14} | {2,-19} | {3,-6}", "Zimmernr.", "Zimmertyp", "Preis", "Status");
            Console.WriteLine(new string('-', 60));

            for (int i = 0; i < rooms.GetLength(0); i++)
            {
                string zimmernr = rooms[i, 0];
                string zimmertyp = rooms[i, 1];
                string prize = rooms[i, 2];
                string status = rooms[i, 3];

                if (status == "frei")
                    status = "FREI";
                else if (status == "belegt")
                    status = "BELEGT";

                Console.WriteLine("{0,-12} | {1,-14} | {2,-19} | {3,-8}", zimmernr, zimmertyp, prize, status);
            }

            Console.WriteLine();
        }


        static void BookRoom()
        {
            Console.WriteLine("=== Zimmer buchen/stornieren ===");
            DisplayRooms();
            Console.WriteLine("Geben Sie eine Zimmernummer ein \n");
            Console.Write("Auswahl: ");


            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("Ungültige Eingabe.");
                return;
            }

            while (!(roomNumber - 1 < roomCount && roomNumber - 1 >= 0))
            {
                Console.WriteLine("Ungültige Zimmernummer");
                Console.WriteLine("Geben Sie eine Zimmernummer ein \n");

                Console.Write("Auswahl: ");
                if (!int.TryParse(Console.ReadLine(), out roomNumber))
                {
                    Console.WriteLine("Ungültige Eingabe.");
                    return;
                }
            }

            if (customerCount == 0)
            {
                Console.WriteLine("Keine Kunden zur Buchung zur Verfügung");
                Console.WriteLine("Drücken Sie eine Taste um zur Zimmerverwaltung zu gelangen!");
                Console.ReadKey();
                Console.Clear();
                RoomManagement();
                return;
            }

            if (rooms[roomNumber - 1, 3] == "frei")
            {
                Console.WriteLine("Geben Sie die Kundennummer ein: ");
                string customerNumber = Console.ReadLine();
                bool customerExists = false;
                for (int i = 0; i < customerCount; i++)
                {
                    if (customers[i, 0] == customerNumber)
                    {
                        customerExists = true;
                        break;
                    }
                }

                if (!customerExists)
                {
                    Console.WriteLine("Kunde nicht gefunden!");
                    return;
                }


                bool alreadyBooked = false;
                for (int j = 0; j < roomCount; j++)
                {
                    if (rooms[j, 4] == customerNumber)
                    {
                        alreadyBooked = true;
                        break;
                    }
                }

                if (alreadyBooked)
                {
                    Console.WriteLine("Kunde hat bereits ein Zimmer gebucht!");
                    return;
                }


                rooms[roomNumber - 1, 3] = "belegt";
                rooms[roomNumber - 1, 4] = customerNumber;
                Console.WriteLine("Buchung erfolgreich!");
            }
            else
            {
                Console.WriteLine("Dieses Zimmer ist bereits belegt! \nWollen Sie die Buchung stornieren? (j/n)");
                string answer = Console.ReadLine();

                while (answer.ToLower() != "j" && answer.ToLower() != "n")
                {
                    Console.WriteLine("Ungültige Auswahl. Geben Sie Ihre Antwort ein (j/n):");
                    answer = Console.ReadLine();
                }

                if (answer.ToLower() == "n")
                {
                    Console.WriteLine("Buchung abgebrochen, drücken Sie eine Taste um zur Zimmerverwaltung zu gelangen!");
                    Console.ReadKey();
                    Console.Clear();
                    RoomManagement();
                }
                else
                {
                    rooms[roomNumber - 1, 3] = "frei";
                    rooms[roomNumber - 1, 4] = null;
                    Console.WriteLine("Zimmer storniert, drücken Sie eine Taste um mit der Buchung fortzufahren!");
                    Console.ReadKey();
                    Console.Clear();
                    BookRoom();
                }
            }
        }

        static void ChangePrize()
        {
            Console.WriteLine("=== Preis ändern ===");
            DisplayRooms();
            Console.WriteLine("Geben Sie eine Zimmernummer ein:");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            if (roomNumber > 0 || roomNumber <= roomCount)
            {
                Console.WriteLine("Geben Sie den neuen Preis ein");
                string prize = Console.ReadLine();
                rooms[roomNumber - 1, 2] = prize + " Euro pro Nacht";
            }
        }
        static void CreateBill()
        {
            Console.WriteLine("=== Rechnung erstellen ===");

            if (customerCount == 0)
            {
                Console.WriteLine("Keine Kunden vorhanden!");
                Console.WriteLine("Drücken Sie eine Taste um zur Kundenverwaltung zu gelangen");
                Console.ReadKey();
                Console.Clear();
                CustomerManagement();
                return;
            }

            Console.WriteLine("Kunden: ");
            DisplayCustomers();
            Console.Write("Wählen Sie eine Kundennummer: ");
            string customerNumber = Console.ReadLine();

            int customerIndex = -1;
            for (int i = 0; i < customerCount; i++)
            {
                if (customers[i, 0] == customerNumber)
                {
                    customerIndex = i;
                    break;
                }
            }

            if (customerIndex == -1)
            {
                Console.WriteLine("Kunde nicht gefunden!");
                Console.ReadKey();
                return;
            }

            int roomIndex = -1;
            for (int i = 0; i < roomCount; i++)
            {
                if (rooms[i, 4] == customerNumber)
                {
                    roomIndex = i;
                    break;
                }
            }

            if (roomIndex == -1)
            {
                Console.WriteLine("Kunde hat keine Übernachtung gebucht.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Write("Wie viele Übernachtungen? ");
            int nights = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wie viel € in Zusatzleistungen? ");
            double additionalPrize = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Drücken Sie eine Taste, um die Rechnung anzuzeigen");
            Console.ReadKey();
            Console.Clear();

            PrintBill(customerIndex, roomIndex, nights, additionalPrize);

            Console.WriteLine("Drücken Sie eine Taste, um zum Hauptmenü zu gelangen");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrintBill(int customerIndex, int roomIndex, int nights, double additionalPrize)
        {
            string priceText = rooms[roomIndex, 2];
            double pricePerNight = Convert.ToDouble(priceText.Split(' ')[0]);

            double overnightTotal = nights * pricePerNight;
            double subtotal = overnightTotal + additionalPrize;

            bool isRegular = customers[customerIndex, 4] == "Stammkunde: Ja";
            double discount = isRegular ? subtotal * 0.10 : 0;
            double netto = subtotal - discount;
            double tax = netto * 0.20;
            double brutto = netto + tax;

            Console.WriteLine("=== Vallora Inn ===");
            Console.WriteLine("RECHNUNG\n");

            Console.WriteLine($"Kunde: {customers[customerIndex, 1]} {customers[customerIndex, 2]}");
            Console.WriteLine($"Zimmer: {customers[customerIndex, 0]}");
            Console.WriteLine($"Nächte: {nights}");
            Console.WriteLine($"Datum: {DateTime.Now:dd.MM.yyyy}\n");

            Console.WriteLine("{0,-30}{1,10:F2} €", "Zimmerpreis pro Nacht:", pricePerNight);
            Console.WriteLine("{0,-30}{1,10:F2} €", $"Zimmerkosten ({nights} Nächte):", overnightTotal);
            Console.WriteLine("{0,-30}{1,10:F2} €", "Zusatzleistungen:", additionalPrize);
            Console.WriteLine(new string('-', 45));

            Console.WriteLine("{0,-30}{1,10:F2} €", "Zwischensumme:", subtotal);

            if (isRegular)
            {
                Console.WriteLine("{0,-30}{1,10:F2} €", "Rabatt (Stammkunde -10%):", -discount);
            }

            Console.WriteLine(new string('-', 45));
            Console.WriteLine("{0,-30}{1,10:F2} €", "Nettobetrag:", netto);
            Console.WriteLine("{0,-30}{1,10:F2} €", "Mehrwertsteuer (20%):", tax);
            Console.WriteLine(new string('-', 45));
            Console.WriteLine("{0,-30}{1,10:F2} €", "Gesamtbetrag (Brutto):", brutto);
            Console.WriteLine(new string('=', 45));
        }
    }

}
