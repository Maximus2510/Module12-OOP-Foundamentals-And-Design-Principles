namespace Module12_OOP_Fundamentals_and_Design_Principles
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new DocumentCardRepository();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Search for document card");
                Console.WriteLine("2. Add new document card");
                Console.WriteLine("3. Update document card");
                Console.WriteLine("4. Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SearchForDocumentCard(repository);
                        break;
                    case "2":
                        AddNewDocumentCard(repository);
                        break;
                    case "3":
                        UpdateDocumentCard(repository);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        private static void SearchForDocumentCard(DocumentCardRepository repository)
        {
            Console.Write("Enter document number: ");
            var documentNumber = Console.ReadLine();

            var cards = repository.Search(documentNumber);

            if (cards.Count == 0)
            {
                Console.WriteLine("Document card not found.");
                return;
            }

            Console.WriteLine("Found document card(s):");

            for (var i = 0; i < cards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cards[i].GetType().Name}: {cards[i].DocumentNumber}");
            }

            Console.Write("Enter the index of the document card to view: ");

            if (!int.TryParse(Console.ReadLine(), out var selectedIndex) || selectedIndex < 1 || selectedIndex > cards.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            var selectedCard = cards[selectedIndex - 1];

            Console.WriteLine(selectedCard.ToString());
        }

        private static void AddNewDocumentCard(DocumentCardRepository repository)
        {
            Console.WriteLine("Select a document type:");
            Console.WriteLine("1. Patent");
            Console.WriteLine("2. Book");
            Console.WriteLine("3. Localized book");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddNewPatentCard(repository);
                    break;
                case "2":
                    AddNewBookCard(repository);
                    break;
                case "3":
                    AddNewLocalizedBookCard(repository);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }



        private static void AddNewPatentCard(DocumentCardRepository repository)
        {
            var patentCard = new PatentCard();

            Console.Write("Title: ");
            patentCard.Title = Console.ReadLine();

            Console.Write("Authors (comma separated list): ");
            patentCard.Authors = Console.ReadLine()?.Split(',');

            Console.Write("Date published (yyyy-mm-dd): ");
            patentCard.DatePublished = DateTime.Parse(Console.ReadLine());

            Console.Write("Expiration date (yyyy-mm-dd): ");
            patentCard.ExpirationDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Unique id: ");
            patentCard.UniqueId = Console.ReadLine();

            repository.Add(patentCard);

            Console.WriteLine($"Patent card {patentCard.DocumentNumber} created successfully.");
        }

        private static void AddNewBookCard(DocumentCardRepository repository)
        {
            Console.WriteLine("Adding a new book card...");

            Console.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();

            Console.Write("Enter title: ");
            var title = Console.ReadLine();

            Console.Write("Enter author(s) (separated by comma): ");
            var authors = Console.ReadLine().Split(',');

            Console.Write("Enter number of pages: ");
            var pages = int.Parse(Console.ReadLine());

            Console.Write("Enter publisher: ");
            var publisher = Console.ReadLine();

            Console.Write("Enter date published (yyyy-MM-dd): ");
            var publishedDate = DateTime.Parse(Console.ReadLine());

            var bookCard = new BookCard
            {
                ISBN = isbn,
                Title = title,
                Authors = authors,
                NumberOfPages = pages,
                Publisher = publisher,
                PublishedDate = publishedDate
            };

            repository.Add(bookCard);

            Console.WriteLine("New book card added.");
        }

        private static void AddNewLocalizedBookCard(DocumentCardRepository repository)
        {
            Console.WriteLine("Adding a new localized book card...");
            Console.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();

            Console.Write("Enter title: ");
            var title = Console.ReadLine();

            Console.Write("Enter author(s) (separated by comma): ");
            var authors = Console.ReadLine().Split(',');

            Console.Write("Enter number of pages: ");
            var pages = int.Parse(Console.ReadLine());

            Console.Write("Enter original publisher: ");
            var originalPublisher = Console.ReadLine();

            Console.Write("Enter country of localization: ");
            var country = Console.ReadLine();

            Console.Write("Enter local publisher: ");
            var localPublisher = Console.ReadLine();

            Console.Write("Enter date published (yyyy-MM-dd): ");
            var publishedDate = DateTime.Parse(Console.ReadLine());

            var localizedBookCard = new LocalizedBookCard
            {
                ISBN = isbn,
                Title = title,
                Authors = authors,
                NumberOfPages = pages,
                OriginalPublisher = originalPublisher,
                CountryOfLocalization = country,
                LocalPublisher = localPublisher,
                PublishedDate = publishedDate
            };

            repository.Add(localizedBookCard);

            Console.WriteLine("New localized book card added.");
        }

        private static void AddNewPatentCard(DocumentCardRepository repository)
        {
            Console.WriteLine("Adding a new patent card...");
            Console.Write("Enter title: ");
            var title = Console.ReadLine();

            Console.Write("Enter author(s) (separated by comma): ");
            var authors = Console.ReadLine().Split(',');

            Console.Write("Enter date published (yyyy-MM-dd): ");
            var publishedDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter expiration date (yyyy-MM-dd): ");
            var expirationDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter unique id: ");
            var uniqueId = Console.ReadLine();

            var patentCard = new PatentCard
            {
                Title = title,
                Authors = authors,
                PublishedDate = publishedDate,
                ExpirationDate = expirationDate,
                UniqueId = uniqueId
            };

            repository.Add(patentCard);

            Console.WriteLine("New patent card added.");
        }

        private static void UpdateDocumentCard(DocumentCardRepository repository)
        {
            Console.Write("Enter document number: ");
            var documentNumber = Console.ReadLine();

            var cards = repository.Search(documentNumber);

            if (cards.Count == 0)
            {
                Console.WriteLine("Document card not found.");
                return;
            }

            Console.WriteLine("Found document card(s):");

            for (var i = 0; i < cards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cards[i].GetType().Name}: {cards[i].DocumentNumber}");
            }

            Console.Write("Enter the index of the document card to update: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out var selectedIndex) || selectedIndex < 1 || selectedIndex > cards.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var selectedCard = cards[selectedIndex - 1];

            Console.WriteLine($"Updating document card {selectedCard.DocumentNumber} ({selectedCard.GetType().Name})...");

            switch (selectedCard)
            {
                case BookCard bookCard:
                    Console.Write("Enter ISBN: ");
                    bookCard.ISBN = Console.ReadLine();

                    Console.Write("Enter title: ");
                    bookCard.Title = Console.ReadLine();

                    Console.Write("Enter authors (comma-separated): ");
                    bookCard.Authors = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

                    Console.Write("Enter number of pages: ");
                    bookCard.NumberOfPages = int.Parse(Console.ReadLine());

                    Console.Write("Enter publisher: ");
                    bookCard.Publisher = Console.ReadLine();

                    Console.Write("Enter date published (yyyy-mm-dd): ");
                    bookCard.DatePublished = DateTime.Parse(Console.ReadLine());
                    break;

                case LocalizedBookCard localizedBookCard:
                    Console.Write("Enter ISBN: ");
                    localizedBookCard.ISBN = Console.ReadLine();

                    Console.Write("Enter title: ");
                    localizedBookCard.Title = Console.ReadLine();

                    Console.Write("Enter authors (comma-separated): ");
                    localizedBookCard.Authors = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

                    Console.Write("Enter number of pages: ");
                    localizedBookCard.NumberOfPages = int.Parse(Console.ReadLine());

                    Console.Write("Enter original publisher: ");
                    localizedBookCard.OriginalPublisher = Console.ReadLine();

                    Console.Write("Enter country of localization: ");
                    localizedBookCard.CountryOfLocalization = Console.ReadLine();

                    Console.Write("Enter local publisher: ");
                    localizedBookCard.LocalPublisher = Console.ReadLine();

                    Console.Write("Enter date published (yyyy-mm-dd): ");
                    localizedBookCard.DatePublished = DateTime.Parse(Console.ReadLine());
                    break;

                case PatentCard patentCard:
                    Console.Write("Enter title: ");
                    patentCard.Title = Console.ReadLine();

                    Console.Write("Enter authors (comma-separated): ");
                    patentCard.Authors = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

                    Console.Write("Enter date published (yyyy-mm-dd): ");
                    patentCard.DatePublished = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter expiration date (yyyy-mm-dd): ");
                    patentCard.ExpirationDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter unique id: ");
                    patentCard.UniqueId = Console.ReadLine();
                    break;
            }

            repository.Save(selectedCard);

            Console.WriteLine($"Document card {selectedCard.DocumentNumber} ({selectedCard.GetType().Name}) updated successfully.");
        }
    }
}