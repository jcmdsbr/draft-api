namespace Core.Entities
{
    public class Product : EntityBase
    {
        public string BarCode { get; set; }

        public Product(int id, string barCode) : base(id)
        {
            BarCode = barCode;
        }
    }
}