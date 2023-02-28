namespace Module12_OOP_Fundamentals_and_Design_Principles
{
    public class DocumentCardRepository
    {
        private readonly string _storagePath;

        public DocumentCardRepository(string storagePath)
        {
            _storagePath = storagePath;
        }

        public void Add(DocumentCard card)
        {
            var json = JsonConvert.SerializeObject(card);
            var fileName = GetFileName(card);
            File.WriteAllText(fileName, json);
        }

        public void Update(DocumentCard card)
        {
            var fileName = GetFileName(card);
            var json = JsonConvert.SerializeObject(card);
            File.WriteAllText(fileName, json);
        }

        public List<DocumentCard> Search(string documentNumber)
        {
            var files = Directory.GetFiles(_storagePath, "*.json");
            var cards = new List<DocumentCard>();

            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var card = JsonConvert.DeserializeObject<DocumentCard>(json);

                if (card.DocumentNumber == documentNumber)
                {
                    cards.Add(card);
                }
            }
            return cards;
        }
    }
}
