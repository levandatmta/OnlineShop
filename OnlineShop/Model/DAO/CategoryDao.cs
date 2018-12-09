using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public List<Category> ListAllCn()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public Category GetById(long Id)
        {
            return db.Categories.Find(Id);
        }
        public long Create(Category ca)
        {
            db.Categories.Add(ca);
            db.SaveChanges();
            return ca.ID;
        }
        public bool Edit(Category ca)
        {
            try
            {
                var result = db.Categories.Find(ca.ID);
                if (result != null)
                {
                    result.Name = ca.Name;
                    result.Status = ca.Status;
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
        public bool Delete(long id)
        {
            try
            {
                var ca = db.Categories.Find(id);
                db.Categories.Remove(ca);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
