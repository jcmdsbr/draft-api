namespace Core.Entities
{
    public class Product : EntityBase
    {
        public Product(string barCode)
        {
            BarCode = barCode;
        }

        public string BarCode { get; set; }
    }
}