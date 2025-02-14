﻿using BusinessObjects;
namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
			try
			{
                using(var context = new MyDbContext())
                {
                    listProducts  = context.Products.ToList();
                }
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
            return listProducts;
        }
        public static Product FindProductById(int productId)
        {
            var product = new Product();
            try
            {
                using (var context = new MyDbContext())
                {
                    product = context.Products.SingleOrDefault(x => x.ProductId == productId);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return product;
        }
        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Products.SingleOrDefault(x => x.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
