using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }
        public List<Product> ListAllCn()
        {
            return db.Products.Where(x => x.Status == true).ToList();
        } 
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderBy(x => x.Price).Take(top).ToList();
        }
        public Product GetById(long Id)
        {
            return db.Products.Find(Id);
        }
        public long Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return p.ID;
        }
        public bool Edit(Product p)
        {
            try
            {
                var product = db.Products.Find(p.ID);
                if (product != null)
                {
                    product.Name = p.Name;
                    product.Image = p.Image;
                    product.Price = p.Price;
                    product.ProducerID = p.ProducerID;
                    product.Quantity = p.Quantity;
                    product.Status = p.Status;
                    product.Code = p.Code;
                    product.Discount = p.Discount;
                    product.Detail = p.Detail;
                    product.Description = p.Description;
                    product.CategoryID = p.CategoryID;
                    product.TopHot = p.TopHot;
                    product.Warranty = p.Warranty;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(long Id)
        {
            try
            {
                var result = db.Products.Find(Id);
                if (result != null) {
                    db.Products.Remove(result);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
