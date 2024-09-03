﻿using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductUpdateByIdQeryHandler _getProductUpdateByIdQeryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(
            GetProductQueryHandler getProductQueryHandler, 
            CreateProductCommandHandler createProductCommandHandler,
            GetProductByIdQueryHandler getProductByIdQueryHandler,
            RemoveProductCommandHandler removeProductCommandHandler,
            GetProductUpdateByIdQeryHandler getProductUpdateByIdQeryHandler,
            UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductUpdateByIdQeryHandler = getProductUpdateByIdQeryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }


        public IActionResult GetProduct(int id) 
        {
            var values = _getProductByIdQueryHandler.Handle(new CQRSPattern.Queries.GetProductByIdQuery(id));
            return View(values);
        }


        public IActionResult DeleteProduct(int id) 
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductUpdateByIdQeryHandler.Handle(new CQRSPattern.Queries.GetProductUpdateByIdQuery(id));
            return View(values);    
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
