using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using Microsoft.VisualBasic;
using System.Collections;
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
                Price = x.Price,
                ProductName = x.ProductName,
                Stock = x.Stock,
            }).ToList();

            return values;
        }

    }
}