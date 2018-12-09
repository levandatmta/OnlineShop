using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductSizeDao
    {
        OnlineShopDbContext db = null;
        public ProductSizeDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<ProductSize> ListAll()
        {
            return db.ProductSizes.ToList();
        }
        public ProductSize GetById(long ProductId, long SizeId)
        {
            return db.ProductSizes.Where(x => x.ProductID == ProductId && x.SizeID == SizeId).SingleOrDefault();
        }
        public bool Create(ProductSize ps)
        {
            db.ProductSizes.Add(ps);
            db.SaveChanges();
            if (ps.SizeID > 0 && ps.ProductID > 0) return true;
            else return false;
        }
        public bool Edit(ProductSize ps)
        {
            try
            {
                var size = db.ProductSizes.Where(x => x.ProductID == ps.ProductID && x.SizeID == ps.SizeID).SingleOrDefault();
                if (size != null)
                {
                    size.Status = ps.Status;
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
        public bool Delete(long ProductID, long SizeID)
        {
            try
            {
                var result = db.ProductSizes.Where(x => x.ProductID == ProductID && x.SizeID == SizeID).SingleOrDefault();
                if (result != null)
                {
                    try
                    {
                        db.ProductSizes.Remove(result);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

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
