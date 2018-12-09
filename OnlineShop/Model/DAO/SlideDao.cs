using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SlideDao
    {
        OnlineShopDbContext db = null;
        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.ToList();
        }
        public List<Slide> ListAllCn()
        {
            return db.Slides.Where(x => x.Status == true).ToList();
        }
        public List<Slide> ListNewSlide(int top)
        {
            return db.Slides.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public Slide GetById(long ID)
        {
            return db.Slides.Find(ID);
        }
        public long Create(Slide sl)
        {
            db.Slides.Add(sl);
            db.SaveChanges();
            return sl.ID;
        }
        public bool Edit(Slide sl)
        {
            try
            {
                var Slide = db.Slides.Find(sl.ID);
                if (Slide != null)
                {
                    Slide.Image = sl.Image;
                    Slide.Link = sl.Link;
                    Slide.Status = sl.Status;
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
                var result = db.Slides.Find(ID);
                if (result != null)
                {
                    db.Slides.Remove(result);
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
