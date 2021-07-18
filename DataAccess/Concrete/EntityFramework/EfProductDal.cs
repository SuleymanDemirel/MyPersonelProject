using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,CekilisDbContext>, IProductDal
    {

        public List<ProductDetailDto> GetProductDetails(Expression<Func<Product, bool>> filter = null) 
        {
            using (CekilisDbContext context = new CekilisDbContext())
            {
                
                var result = from p in filter == null ? context.Products : context.Products.Where(filter)
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             join  ı in context.ProductsImages
                             on p.ProductId equals ı.ProductId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice= p.UnitPrice,
                                 Description = p.Description,
                                 ImagePath = ı.ImagePath,
                                 CategoryId = p.CategoryId
                             };
                return result.ToList();

            }
        }
    }
}
