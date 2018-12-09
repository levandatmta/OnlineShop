using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ColorDao
    {
        OnlineShopDbContext db = null;
        public ColorDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Color> ListAll()
        {
            return db.Colors.ToList();
        }
        public Color GetById(long ID)
        {
            return db.Colors.Find(ID);
        }
        public long Create(Color Color)
        {
            db.Colors.Add(Color);
            db.SaveChanges();
            return Color.ID;
        }
        public bool Edit(Color Cl)
        {
            try
            {
                var Color = db.Colors.Find(Cl.ID);
                if (Color != null)
                {
                    Color.Name = Cl.Name;
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
                var Color = db.Colors.Find(ID);
                if (Color != null)
                {
                    try
                    {
                        db.Colors.Remove(Color);
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
