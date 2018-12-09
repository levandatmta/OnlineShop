using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SizeDao
    {
        OnlineShopDbContext db = null;
        public SizeDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Size> ListAll()
        {
            return db.Sizes.ToList();
        }
        public Size GetById(long Id)
        {
            return db.Sizes.Find(Id);
        }
        public long Create(Size size)
        {
            db.Sizes.Add(size);
            db.SaveChanges();
            return size.ID;
        }
        public bool Edit(Size s)
        {
            try
            {
                var size = db.Sizes.Find(s.ID);
                if (size != null)
                {
                    size.Size1 = s.Size1;
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
        public bool Delete(long ID)
        {
            try
            {
                var result = db.Sizes.Find(ID);
                if (result != null)
                {
                    try
                    {
                        db.Sizes.Remove(result);
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
