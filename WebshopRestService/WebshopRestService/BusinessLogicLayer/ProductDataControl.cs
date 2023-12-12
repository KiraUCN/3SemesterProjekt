﻿using WebshopData.DatabaseLayer;
using WebshopModel.ModelLayer;
using WebshopRestService.DTOs;
using WebshopRestService.Logging;

namespace WebshopRestService.BusinessLogicLayer
{
    public class ProductDataControl : IProductData
    {
        private readonly IProductAccess _productAccess;

        public ProductDataControl(IProductAccess productAccess)
        {
            _productAccess = productAccess;
        }

        public int Add(ProductDTOWrite productToAdd)
        {
            int insertedId = 0;
            try
            {
                Product? foundProduct = ModelConversion.ProductDTOConversion.ToProduct(productToAdd);
                if (foundProduct != null)
                {
                    insertedId = _productAccess.CreateProduct(foundProduct);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int prodId)
        {
            try
            {
                bool deletionSuccessful = _productAccess.DeleteProduct(prodId);
                return deletionSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public ProductDTORead? Get(int prodId)
        {
            ProductDTORead? foundProductDTO;
            try
            {
                Product? foundProduct = _productAccess.GetProductById(prodId);
                foundProductDTO = ModelConversion.ProductDTOConversion.FromProduct(foundProduct);
            }
            catch(Exception ex)
            {
                foundProductDTO = null;
                Logger.LogError(ex);
            }
            return foundProductDTO;
        }

        public List<ProductDTORead> GetProductByType(string prodType)
        {
            List<ProductDTORead> foundProductsDTO;
            try
            {
                List<Product> foundProducts = _productAccess.GetProductByType(prodType);
                foundProductsDTO = ModelConversion.ProductDTOConversion.FromProductCollection(foundProducts);
            }
            catch(Exception ex)
            {
                //Instead of null - create a new empty list
                foundProductsDTO = new List<ProductDTORead>();
                Logger.LogError(ex);
            }
            return foundProductsDTO;
        }

        public List<ProductDTORead> Get()
        {
            List<ProductDTORead> foundDTOs;
            try
            {
                List<Product> foundProducts = _productAccess.GetProductAll();
                foundDTOs = ModelConversion.ProductDTOConversion.FromProductCollection(foundProducts);
            }
            catch (Exception ex)
            {
                foundDTOs = new List<ProductDTORead>();
                Logger.LogError(ex);
            }
            return foundDTOs;
        }

        public bool Put(ProductDTOWrite productToUpdate)
        {
            try
            {
                Product updatedProduct = ModelConversion.ProductDTOConversion.ToProduct(productToUpdate);

                if (updatedProduct != null)
                {
                    bool updateSuccessful = _productAccess.UpdateProduct(updatedProduct);
                    return updateSuccessful;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
