using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.DAO
{
    public class AccountDao
    {
        OnlineShopDbContext db = null;
        public AccountDao()
        {
            db = new OnlineShopDbContext();
        }
        public IEnumerable<Account> ListAllPaging(string Searching,int Page, int PageSize)
        {
            IQueryable<Account> model = db.Accounts;
            if (!string.IsNullOrEmpty(Searching))
            {
                model = model.Where(x => x.Username.Contains(Searching) || x.Phone.Contains(Searching));
            }
            return model.OrderBy(x => x.ID).ToPagedList(Page, PageSize);
        }
        public List<Account> ListAll()
        {
            var result = db.Accounts.ToList();
            return result;
        }
        public Account GetByUsername(string Username)
        {
            var result = db.Accounts.SingleOrDefault(x => x.Username == Username);
            return result;
        }
        public Account GetById(long Id)
        {
            var result = db.Accounts.Find(Id);
            return result;
        }
        public int Login(string Username, string Password)
        {
            var result = db.Accounts.SingleOrDefault(x => x.Username == Username);
            if (result == null) return 0;
            else
            {
                if (result.Status == false) return -1;
                else
                {
                    if (result.Password == Password) return 1;
                    else return -2;
                }
            }
        }
        public long Create(Account ac)
        {
            if (ac.Type == null) ac.Type = 2;
            if (ac.Status == null) ac.Status = true;
            db.Accounts.Add(ac);
            db.SaveChanges();
            return ac.ID;
        }
        public bool Update(Account ac)
        {
            try
            {
                var result = db.Accounts.Find(ac.ID);
                result.Username = ac.Username;
                if (!string.IsNullOrEmpty(ac.Password))
                {
                    result.Password = ac.Password;
                }
                result.Image = ac.Image;
                ac.Status = result.Status;
                result.Name = ac.Name;
                result.Type = ac.Type;
                result.Phone = ac.Phone;
                result.Status = result.Status;
                result.Address = ac.Address;
                result.Birthday = ac.Birthday;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var acc = db.Accounts.Find(id);
            acc.Status = !acc.Status;
            db.SaveChanges();
            return !acc.Status;
        }
        public bool Delete(long ID)
        {
            try
            {
                var account = db.Accounts.Find(ID);
                db.Accounts.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }
    }
}
