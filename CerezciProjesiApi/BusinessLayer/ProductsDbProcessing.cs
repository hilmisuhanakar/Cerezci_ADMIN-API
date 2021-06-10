using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ProductsDbProcessing : ProductsDbContext
    {
        ProductsDbContext db;

        List<Products> list;
        public ProductsDbProcessing()
        {
            db = new ProductsDbContext();

            list = db.Products.ToList();
        }


        public List<Products> GetAllProducts()
        {
            return (list);
        }

        public List<Products> GetProductsFromName(string ProductName)
        {
            List<Products> ListOfProductNames = new List<Products>();

            foreach (var item in list)
            {
                if (item.ProductName.ToLower().Contains(ProductName.ToLower()))
                {
                    ListOfProductNames.Add(item);
                }
            }
            return (ListOfProductNames);
        }

        public Products GetAllProducts(int Id)
        {
            return (db.Products.Find(Id));
        }


        public Products CreatProducts(Products Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
            return Product;
        }

        public Products EditProducts(int Id, Products Product)
        {
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            return Product;
        }

        public void DeleteProducts(int Id)
        {
            db.Products.Remove(db.Products.Find(Id));
            db.SaveChanges();
        }

    }
}
