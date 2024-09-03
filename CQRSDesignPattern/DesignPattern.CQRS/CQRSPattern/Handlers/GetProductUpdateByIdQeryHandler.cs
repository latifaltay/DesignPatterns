using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateByIdQeryHandler
    {
        private readonly Context _context;

        public GetProductUpdateByIdQeryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateQueryResult Handle(GetProductUpdateByIdQuery query)
        {
            var values = _context.Products.Find(query.Id);
            return new GetProductUpdateQueryResult
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Description = values.Description,
                Price = values.Price,
                Stock = values.Stock,
            };
            
        }
    }
}
