using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCYaJia.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public IQueryable<Product> Get前10筆商品資料()
        {
            return this.All().Take(10);
        }

        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}