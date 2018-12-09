using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductColorDao
    {
        OnlineShopDbContext db = null;
        public ProductColorDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<ProductColor> ListAll()
        {
            return db.ProductColors.ToList();
        }
        public ProductColor GetById(long ProductID, long ColorID)
        {
            return db.ProductColors.Where(x => x.ProductID == ProductID && x.ColorID == ColorID).SingleOrDefault();
        }
        public bool Create(ProductColor pc)
        {
            try
            {
                db.ProductColors.Add(pc);
                db.SaveChanges();
                if (pc.ColorID > 0 && pc.ProductID > 0) return true;
                else return false;
            }
            catch {
                return false;
            }
        }
        public bool Edit(ProductColor pc)
        {
            try
            {
                var Color = db.ProductColors.Where(x => x.ProductID == pc.ProductID && x.ColorID == pc.ColorID).SingleOrDefault();
                if (Color != null)
                {
                    Color.Status = pc.Status;
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
        public bool Delete(long ProductID, long ColorID)
        {
            try
            {
                var result = db.ProductColors.Where(x => x.ProductID == ProductID && x.ColorID == ColorID).SingleOrDefault();
                if (result != null)
                {
                    try
                    {
                        db.ProductColors.Remove(result);
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
