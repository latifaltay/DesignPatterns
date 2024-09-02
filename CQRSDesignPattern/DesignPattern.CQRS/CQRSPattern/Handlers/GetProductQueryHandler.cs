using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }


        public List<GetProductQueryResult> Handle() 
        {
            var values = _context.Products.Select(x => new GetProductQueryResult 
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Stock = x.Stock,
                Description = x.Description,
                Price = x.Price,
                Status = x.Status
            }).ToList();

            return values;
        }

    }
}
