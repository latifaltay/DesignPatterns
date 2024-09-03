namespace DesignPattern.CQRS.CQRSPattern.Commands
{
    public class CreateProductCommand
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
