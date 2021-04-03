namespace Core.Entities
{
    public class Customer : EntityBase
    {
        public Customer(string document)
        {
            Document = document;
        }

        public string Document { get; set; }
    }
}