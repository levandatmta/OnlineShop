using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProducerDao
    {
        OnlineShopDbContext db = null;
        public ProducerDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Producer> ListAll()
        {
            return db.Producers.ToList();
        }
        //cn : connect
        public Producer GetById(long Id)
        {
            return db.Producers.Find(Id);
        }
        public long Create(Producer pr)
        {
            db.Producers.Add(pr);
            db.SaveChanges();
            return pr.ID;
        }
        public bool Edit(Producer pr)
        {
            var model = db.Producers.Find(pr.ID);
            if (model != null)
            {
                model.Name = pr.Name;
                model.Status = pr.Status;
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool Delete(long Id)
        {
            try
            {
                var pr = db.Producers.Find(Id);
                db.Producers.Remove(pr);
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
