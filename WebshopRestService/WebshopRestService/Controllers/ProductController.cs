﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopModel.ModelLayer;
using WebshopRestService.BusinessLogicLayer;
using WebshopRestService.DTOs;

namespace WebshopRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductData _productDataController;

        // Constructor with Dependency Injection
        public ProductController(IProductData productDataController)
        {
            _productDataController = productDataController;
        }

        // URL: api/products
        [HttpGet]
        public ActionResult<List<ProductDTORead>>? Get(string? prodType = "%")
        {
            ActionResult<List<ProductDTORead>> foundReturn;
            List<ProductDTORead>? foundProducts = null;
            //Retrieve data converted to DTO
            if (prodType != "%")
            {
                foundProducts = _productDataController.GetProductByType(prodType);
            }
            else
            {
                foundProducts = _productDataController.Get();
            }
            //evaluate
            if (foundProducts != null)
            {
                if (foundProducts.Count > 0)
                {
                    foundReturn = Ok(foundProducts); //OK found list statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204); //OK found list but no content 204
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500); //Internal server error   
            }
            return foundReturn; //send return to client
        }


        // URL: api/products/{id}
        [HttpGet, Route("{prodId}")]
        public ActionResult<ProductDTORead> Get(int prodId)
        {
            ActionResult<ProductDTORead> foundReturn;
            try
            {
                //Retieve data converted to DTO
                ProductDTORead? foundProductsById = _productDataController.Get(prodId);

                //Evaluate
                if (foundProductsById != null)
                {
                    foundReturn = Ok(foundProductsById); //OK found product by ID statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204); // OK not found, no content statuscode 204
                }
            }
            catch
            {
                foundReturn = new StatusCodeResult(500); // Internal server error   
            }
            return foundReturn; // Send return to client
        }

        //// URL: api/products/type/{prodType}
        //[HttpGet(template: "GetProductByType")]
        //public ActionResult<List<ProductDTORead>> GetProductByType(string prodType)
        //{
        //    ActionResult<List<ProductDTORead>> foundReturn;
        //    try
        //    {
        //        //Retieve data converted to DTO
        //        List<ProductDTORead> foundProductsByType = _productDataController.GetProductByType(prodType);

        //        //Evaluate
        //        if (foundProductsByType != null)
        //        {
        //            foundReturn = Ok(foundProductsByType); //OK found product by ID statuscode 200
        //        }
        //        else
        //        {
        //            foundReturn = new StatusCodeResult(204); // OK not found, no content statuscode 204
        //        }
        //    }
        //    catch
        //    {
        //        foundReturn = new StatusCodeResult(500); // Internal server error   
        //    }
        //    return foundReturn; // Send return to client
        //}

        // URL: api/products
        [HttpPost]
        public ActionResult<int> PostNewProduct(ProductDTORead productDTO)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (productDTO != null)
            {
                insertedId = _productDataController.Add(productDTO);
            }
            // Evaluate
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);
            }
            else if (insertedId == 0)
            {
                foundReturn = BadRequest();     // missing input
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            return foundReturn;
        }


        //JEG ER IKKE SIKKER PÅ DE FØLGENDE METODER GRRRRRRRRR

        [HttpDelete, Route("{prodId}")]
        public ActionResult Delete(int prodId)
        {
            ActionResult foundReturn;
            bool wasOk = _productDataController.Delete(prodId);
            if (wasOk)
            {
                foundReturn = Ok();
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            return foundReturn;
        }

        [HttpPut, Route("{prodId}")]
        public ActionResult<bool> Put(ProductDTORead productDTO)
        {
            ActionResult foundReturn;

            WebshopModel.ModelLayer.Product? product = ModelConversion.ProductDTOConversion.ToProduct(productDTO);

            if (productDTO != null)
            {
                bool wasOk = _productDataController.Put(productDTO);

                if (wasOk)
                {
                    foundReturn = Ok();
                }
                else
                {
                    foundReturn = new StatusCodeResult(500);
                }
            }
            else
            {
                foundReturn = BadRequest();
            }

            return foundReturn;
        }
    }
}
