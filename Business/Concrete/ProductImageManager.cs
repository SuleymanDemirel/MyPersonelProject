using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            //IResult result = BusinessRules.Run(CheckIfProductImageLimitExceded(productImage));
            //if (result != null)
            //{
            //    return result;
            //}
            productImage.ImagePath = FileHelper.Add(file);
            productImage.ImageDate = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }


        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(c => c.ProductId == id));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(), Messages.ProductsImagesListed);
        }

        public IDataResult<List<ProductImage>> GetProductImagesById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(result.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(id).Data);
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageLimitExceded(productImage));

            if (result != null)
            {
                return result;
            }

            productImage.ImagePath = FileHelper.Update(_productImageDal.Get(ci => ci.Id == productImage.Id).ImagePath, file);
            productImage.ImageDate = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }


        private IResult CheckIfProductImageLimitExceded(ProductImage productImage)
        {
            var result = _productImageDal.GetAll(c => c.ProductId == productImage.ProductId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<ProductImage>> CheckIfProductImageNull(int productId)
        {
            try
            {
                string path = @"\Images\logo.jpg";
                var result = _productImageDal.GetAll(c => c.ProductId == productId).Any();
                if (!result)
                {
                    List<ProductImage> productImage = new List<ProductImage>();
                    productImage.Add(new ProductImage { ProductId = productId, ImagePath = path, ImageDate = DateTime.Now });
                    return new SuccessDataResult<List<ProductImage>>(productImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == productId).ToList());
        }
//
      


    }
}
