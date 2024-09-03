using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }


        public void Handle(UpdateProductCommand command)
        {
            var values = _context.Products.Find(command.ProductId);
            values.ProductName = command.ProductName;
            values.Price = command.Price;
            values.Status = true;
            values.Stock = command.Stock;
            values.Description = command.Description;
            _context.SaveChanges();
        }


    }
}