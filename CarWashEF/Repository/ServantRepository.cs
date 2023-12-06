using CarWash.exception;
using CarWashEF.Data;
using CarWashEF.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarWashEF.Repository
{
    public static class ServantRepository
    {
        public static List<Servant> GetAll()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Servants.ToList();
            }
        }

        public static Servant GetById (int id)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Servants.Where(s => s.Id == id).First();
            }
        }

        public static Servant GetByName(string name)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Servants.Where(s => s.Name.Equals(name)).FirstOrDefault();
            }
        }

        public static Servant CreateServant (Servant servant)
        {
            if (GetByName(servant.Name) != null)
                throw new InsertEntityException("We have servant with such name");
            using (var dbContext = new AppDbContext())
            {
                dbContext.Servants.Add(servant);
                dbContext.SaveChanges();
                return GetByName(servant.Name);
            }
        }

        public static void DeleteById(int id)
        {
            var servantFromDb = GetById(id);
            using (var dbContext = new AppDbContext())
            {
                dbContext.Servants.Remove(servantFromDb);
                dbContext.SaveChanges();
            }
        }
    }
}
